using Microsoft.Data.Sqlite;
using Programming_03_Assignment;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Testing
{
    /// <summary>
    /// This file tests the ClientHelper.cs file and the methods relating to it as a integration test.
    /// </summary>
    public class ClientHelperTester : IDisposable
    {
        private readonly DatabaseHelper _dbHelper;

        public ClientHelperTester()
        {
            // Initialize the DatabaseHelper instance
            _dbHelper = new DatabaseHelper();
            InitializeDatabaseSchema(); // Ensure the database schema is created
        }

        /// <summary>
        /// Creates a private method used for cleaning the database.
        /// </summary>
        /// <param name="emailAddress">The user's email address.</param>
        private void CleanupDatabase(string emailAddress)
        {
            using var conn = _dbHelper.GetConnection();
            conn.Open();
            using var cmd = new SqliteCommand("DELETE FROM Clients WHERE EmailAddress = @EmailAddress", conn);
            cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// creates a database schema to create the structure of the database for sqlite.
        /// </summary>
        private void InitializeDatabaseSchema()
        {
            using var conn = _dbHelper.GetConnection();
            conn.Open();
            using var cmd = new SqliteCommand(@"
                CREATE TABLE IF NOT EXISTS Clients (
                    ClientID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Forename TEXT NOT NULL,
                    Surname TEXT NOT NULL,
                    EmailAddress TEXT NOT NULL UNIQUE,
                    PhoneNumber TEXT NOT NULL,
                    HashedPassword TEXT NOT NULL,
                    Address TEXT,
                    City TEXT,
                    Postcode TEXT,
                    Software BOOLEAN,
                    LaptopsPC BOOLEAN,
                    Games BOOLEAN,
                    OfficeTools BOOLEAN,
                    Accessories BOOLEAN
                );", conn);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Tests MapToClient method.
        /// </summary>
        [Fact]
        public void MapToClientTest()
        {
            /// Arrange: Create a password and its hashed version.
            string password = "SecurePassword123!";
            string hashedPassword = PasswordHasher.HashPassword(password);

            /// Arrange: Set up the new client.
            var newClient = new Client
            {
                ClientID = 1,
                Forename = "Jane",
                Surname = "Doe",
                EmailAddress = "timmydoe@example.com",
                PhoneNumber = "0987654321",
                HashedPassword = hashedPassword,
                Address = "456 Another St",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Act: Insert the new client into the database.
            using var conn = _dbHelper.GetConnection();
            conn.Open();

            /// Act: Create a transaction session to perform the SQL script.
            using var transaction = conn.BeginTransaction();

            /// Act: Inserts the client info using SQL to ensure correct formatting to work with the mapping.
            using (var cmd = new SqliteCommand(@"
        INSERT INTO Clients (ClientID, Forename, Surname, EmailAddress, Password, PhoneNumber,
Address, City, Postcode, Software, LaptopsPC, Games, OfficeTools, Accessories)
        VALUES (@ClientID, @Forename, @Surname, @EmailAddress, @HashedPassword, @PhoneNumber,
@Address, @City, @Postcode, @Software, @LaptopsPC, @Games, @OfficeTools, @Accessories);", conn, transaction))
            {

                /// Arrange: Adding the value from newClient in the same format 
                /// as the mapped sections to add into the database.
                cmd.Parameters.AddWithValue("@ClientID", newClient.ClientID);
                cmd.Parameters.AddWithValue("@Forename", newClient.Forename);
                cmd.Parameters.AddWithValue("@Surname", newClient.Surname);
                cmd.Parameters.AddWithValue("@EmailAddress", newClient.EmailAddress);
                cmd.Parameters.AddWithValue("@HashedPassword", newClient.HashedPassword);
                cmd.Parameters.AddWithValue("@PhoneNumber", newClient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", newClient.Address);
                cmd.Parameters.AddWithValue("@City", newClient.City);
                cmd.Parameters.AddWithValue("@Postcode", newClient.Postcode);
                cmd.Parameters.AddWithValue("@Software", newClient.Software);
                cmd.Parameters.AddWithValue("@LaptopsPC", newClient.LaptopsPC);
                cmd.Parameters.AddWithValue("@Games", newClient.Games);
                cmd.Parameters.AddWithValue("@OfficeTools", newClient.OfficeTools);
                cmd.Parameters.AddWithValue("@Accessories", newClient.Accessories);
                cmd.ExecuteNonQuery();
            }

            /// Retrieve data from the database using the email address.
            var retrieveCmd = new SqliteCommand(@"
        SELECT ClientID, Forename, Surname, EmailAddress, PhoneNumber, 
               Address, City, Postcode, 
               Software, LaptopsPC, Games, OfficeTools, Accessories
        FROM Clients
        WHERE EmailAddress = @EmailAddress;", conn, transaction);
            retrieveCmd.Parameters.AddWithValue("@EmailAddress", newClient.EmailAddress);

            using var reader = retrieveCmd.ExecuteReader();

            /// Assert: Error catcher for no data found for the matching client.
            Assert.True(reader.Read(), "No data found for the inserted client.");

            /// Act: Map the data to a Client object.
            var mappedClient = DataReaderExtensions.MapToClient(reader);

            /// Assert: Verify the mapping is correct by comparing 
            /// the mapped data in the database to the expected mapped data.
            Assert.NotNull(mappedClient);
            Assert.Equal(newClient.ClientID, mappedClient.ClientID);
            Assert.Equal(newClient.Forename, mappedClient.Forename);
            Assert.Equal(newClient.Surname, mappedClient.Surname);
            Assert.Equal(newClient.EmailAddress, mappedClient.EmailAddress);
            Assert.Equal(newClient.PhoneNumber, mappedClient.PhoneNumber);
            Assert.Equal(newClient.Address, mappedClient.Address);
            Assert.Equal(newClient.City, mappedClient.City);
            Assert.Equal(newClient.Postcode, mappedClient.Postcode);
            Assert.Equal(newClient.Software, mappedClient.Software);
            Assert.Equal(newClient.LaptopsPC, mappedClient.LaptopsPC);
            Assert.Equal(newClient.Games, mappedClient.Games);
            Assert.Equal(newClient.OfficeTools, mappedClient.OfficeTools);
            Assert.Equal(newClient.Accessories, mappedClient.Accessories);

            /// Rollback transaction to clean up test data.
            transaction.Rollback();
        }


        /// <summary>
        /// Tests MapToUsernameTests.
        /// </summary>
        [Fact]
        public void MapToUsernameTest()
        {
            /// Gets database connection.
            using var conn = _dbHelper.GetConnection();
            conn.Open();

            /// Starts a database transaction session.
            using var transaction = conn.BeginTransaction();

            /// Arrange: Creates a new client.
            var newClient = new Client
            {
                ClientID = 3,
                Forename = "John",
                Surname = "Williams",
                EmailAddress = "johnwilliams@example.com",
                PhoneNumber = "0789564231",
                HashedPassword = PasswordHasher.HashPassword("Password789!"),
                Address = "987 Oak Street",
                City = "Sampletown",
                Postcode = "EF45 6GH",
                Software = false,
                LaptopsPC = true,
                Games = true,
                OfficeTools = false,
                Accessories = true,
            };

            /// Arrange: Inserts client in a transaction using SQL to ensure correct order for mapping later.
            using (var cmd = new SqliteCommand(@"
        INSERT INTO Clients (Forename, Surname, EmailAddress, Password, PhoneNumber, Address, City, 
Postcode, Software, LaptopsPC, Games, OfficeTools, Accessories)
        VALUES (@Forename, @Surname, @EmailAddress, @HashedPassword, @PhoneNumber, @Address, @City,
@Postcode, @Software, @LaptopsPC, @Games, @OfficeTools, @Accessories);", conn, transaction))
            {
                /// Arrange: Uses the value of newClient for each field to add it into the database table.
                cmd.Parameters.AddWithValue("@Forename", newClient.Forename);
                cmd.Parameters.AddWithValue("@Surname", newClient.Surname);
                cmd.Parameters.AddWithValue("@EmailAddress", newClient.EmailAddress);
                cmd.Parameters.AddWithValue("@HashedPassword", newClient.HashedPassword);
                cmd.Parameters.AddWithValue("@PhoneNumber", newClient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", newClient.Address);
                cmd.Parameters.AddWithValue("@City", newClient.City);
                cmd.Parameters.AddWithValue("@Postcode", newClient.Postcode);
                cmd.Parameters.AddWithValue("@Software", newClient.Software);
                cmd.Parameters.AddWithValue("@LaptopsPC", newClient.LaptopsPC);
                cmd.Parameters.AddWithValue("@Games", newClient.Games);
                cmd.Parameters.AddWithValue("@OfficeTools", newClient.OfficeTools);
                cmd.Parameters.AddWithValue("@Accessories", newClient.Accessories);
                cmd.ExecuteNonQuery();
            }

            /// Retrieve data from the database by using the email.
            var retrieveCmd = new SqliteCommand("SELECT Forename, Surname FROM Clients WHERE Forename = @Forename",
                conn, transaction);
            retrieveCmd.Parameters.AddWithValue("@Forename", newClient.Forename);

            using var reader = retrieveCmd.ExecuteReader();
            /// Assert: Error catcher for no user found with the matching email.
            Assert.True(reader.Read(), "No client found in database.");

            /// Act: Calling the MapToUsername method to map the data from mappedClient.
            var mappedClient = DataReaderExtensions.MapToUsername(reader);

            /// Assert: verify that the mapped Forename and Surname are correctly mapped by
            /// comparing the mapped data with the original data from new client.
            Assert.Equal(newClient.Forename, mappedClient.Forename);
            Assert.Equal(newClient.Surname, mappedClient.Surname);

            /// Rollback to avoid locking other tests.
            transaction.Rollback();
        }

        /// <summary>
        /// Tests MapToLogin.
        /// </summary>
        [Fact]
        public void MapToLoginTest()
        {
            /// Gets database connection.
            using var conn = _dbHelper.GetConnection();
            conn.Open();

            /// Starts a database transaction session.
            using var transaction = conn.BeginTransaction(); // Start transaction

            /// Arrange: Creates a new client.
            var newClient = new Client
            {
                ClientID = 4,
                Forename = "Jane",
                Surname = "Smith",
                EmailAddress = "janesmith@example.com",
                PhoneNumber = "1234567890",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword1223!"),
                Address = "123 Main St",
                City = "Test City",
                Postcode = "12345",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = false,
                Accessories = true
            };

            /// Arrange: Inserts client in a transaction using SQL to ensure correct order for mapping later.
            using (var cmd = new SqliteCommand(@"
        INSERT INTO Clients (ClientID, Forename, Surname, EmailAddress, Password, PhoneNumber,
Address, City, Postcode, Software, LaptopsPC, Games, OfficeTools, Accessories)
        VALUES (@ClientID, @Forename, @Surname, @EmailAddress, @HashedPassword, @PhoneNumber,
@Address, @City, @Postcode, @Software, @LaptopsPC, @Games, @OfficeTools, @Accessories);", conn, transaction))
            {
                /// Arrange: Uses the value of newClient for each field to add it into the database table.
                cmd.Parameters.AddWithValue("@ClientID", newClient.ClientID);
                cmd.Parameters.AddWithValue("@Forename", newClient.Forename);
                cmd.Parameters.AddWithValue("@Surname", newClient.Surname);
                cmd.Parameters.AddWithValue("@EmailAddress", newClient.EmailAddress);
                cmd.Parameters.AddWithValue("@HashedPassword", newClient.HashedPassword);
                cmd.Parameters.AddWithValue("@PhoneNumber", newClient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", newClient.Address);
                cmd.Parameters.AddWithValue("@City", newClient.City);
                cmd.Parameters.AddWithValue("@Postcode", newClient.Postcode);
                cmd.Parameters.AddWithValue("@Software", newClient.Software);
                cmd.Parameters.AddWithValue("@LaptopsPC", newClient.LaptopsPC);
                cmd.Parameters.AddWithValue("@Games", newClient.Games);
                cmd.Parameters.AddWithValue("@OfficeTools", newClient.OfficeTools);
                cmd.Parameters.AddWithValue("@Accessories", newClient.Accessories);
                cmd.ExecuteNonQuery();
            }

            /// Retrieve data from the database by using the email.
            var retrieveCmd = new SqliteCommand(@"
        SELECT ClientID, Forename, Surname, EmailAddress, PhoneNumber, 
               NULL AS UnusedColumn, Address, City, Postcode, 
               Software, LaptopsPC, Games, OfficeTools, Accessories
        FROM Clients
        WHERE EmailAddress = @EmailAddress;", conn, transaction);
            retrieveCmd.Parameters.AddWithValue("@EmailAddress", newClient.EmailAddress);

            using var reader = retrieveCmd.ExecuteReader();

            Assert.True(reader.Read(), "No client found in database.");

            /// Act: Map the data from the mappedClient by calling the MapToLogin method.
            var mappedClient = DataReaderExtensions.MapToLogin(reader);

            /// Assert: verify that the mapped data are correctly mapped by
            /// comparing the mapped data with the original data from new client.
            Assert.Equal(newClient.EmailAddress, mappedClient.EmailAddress);
            Assert.Equal(newClient.PhoneNumber, mappedClient.PhoneNumber);
            Assert.Equal(newClient.ClientID, mappedClient.ClientID);
            Assert.Equal(newClient.Forename, mappedClient.Forename);
            Assert.Equal(newClient.Surname, mappedClient.Surname);

            /// Rollback to avoid locking other tests.
            transaction.Rollback();
        }

        /// <summary>
        /// Tests GenerateClientDataTable.
        /// </summary>
        [Fact]
        public void GenerateClientDataTableTest()
        {
            /// Arrange: Creates a new client.
            var newClient = new Client
            {
                Forename = "Mike",
                Surname = "Johnson",
                EmailAddress = "mikejohnson@example.com",
                PhoneNumber = "9876543210",
                Address = "456 Another St",
                City = "Test City",
                Postcode = "67890",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = false,
                Accessories = true
            };

            /// Act: Generates a data table by calling the GenerateClientDataTable
            /// method with the data of newClient.
            var dataTable = ClientDataHelper.GenerateClientDataTable(newClient);

            /// Assert: Verify the DataTable contains the correct values
            /// Assert: Checks the number of rows are equal to 12 being the amount of data fields in neewClient.
            Assert.Equal(12, dataTable.Rows.Count);
            /// Assert: verify that the dataTable has the Forename field.
            Assert.Equal("Forename", dataTable.Rows[0]["Field"]);
            /// Assert: verify that the dataTable contains the Forename of newClient.
            Assert.Equal(newClient.Forename, dataTable.Rows[0]["Value"]);
        }

        /// <summary>
        /// Tests the GenerateAdminDataTable method.
        /// </summary>
        [Fact]
        public void GenerateAdminDataTableTest()
        {
            /// Arrange: Create a list of new clients to ensure two clients data can be displayed.
            var clients = new List<Client>
            {
                new Client
                {
                    ClientID = 1,
                    Forename = "Alice",
                    Surname = "Brown",
                    EmailAddress = "alicebrown@example.com",
                    PhoneNumber = "1231231234",
                    Address = "123 Street",
                    City = "Test City",
                    Postcode = "11111",
                    Software = true,
                    LaptopsPC = true,
                    Games = true,
                    OfficeTools = false,
                    Accessories = true
                },
                new Client
                {
                    ClientID = 2,
                    Forename = "Bob",
                    Surname = "Green",
                    EmailAddress = "bobgreen@example.com",
                    PhoneNumber = "9879879876",
                    Address = "456 Avenue",
                    City = "Test City",
                    Postcode = "22222",
                    Software = false,
                    LaptopsPC = true,
                    Games = true,
                    OfficeTools = true,
                    Accessories = false
                }
            };

            /// Arrange: Generate DataTable from list of Clients by calling the GernateAdminDataTable method.
            var dataTable = ClientDataHelper.GenerateAdminDataTable(clients);

            /// Assert: Verify the DataTable has correct values of the two clients.
            Assert.Equal(2, dataTable.Rows.Count);
            /// Assert: verify that there is a client ID in the table.
            Assert.Equal(1, dataTable.Rows[0]["ClientID"]);
            /// Assert: verify that the first clients Forname is correctly inputed into the table.
            Assert.Equal("Alice", dataTable.Rows[0]["Forename"]);
            /// Assert: verify that the second clients Forname is correctly inputed into the table.
            Assert.Equal("Green", dataTable.Rows[1]["Surname"]);
        }

        /// <summary>
        /// Uses the dispose method to delete data from the database added for testing.
        /// </summary>
        public void Dispose()
        {
            /// Clean up after each test
            CleanupDatabase("janesmith@example.com");
            CleanupDatabase("alicebrown@example.com");
            CleanupDatabase("bobgreen@example.com");
            CleanupDatabase("timmydoe@example.com");
        }

    }
}