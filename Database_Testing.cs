using Programming_03_Assignment;
using Microsoft.Data.Sqlite;
using Xunit;
using System;

namespace Project_Testing
{
    /// <summary>
    /// A series of integration and unit tests for multiple files that rely on each other to function including: DatabaseHelper.cs, 
    /// PasswordHasher.cs, Clients.cs, and ValidationHelper.cs.
    /// </summary>
    public class DatabaseHelperTests : IDisposable
    {
        /// <summary>
        /// Creates a read only var of method DatabaseHelper for tests that require database functionality.
        /// </summary>
        private readonly DatabaseHelper _dbHelper;

        /// <summary>
        /// Calls DatabaseHelper to initilise a database schema to use for testing.
        /// </summary>
        public DatabaseHelperTests()
        {
            /// Initialise the DatabaseHelper instance
            _dbHelper = new DatabaseHelper();
            InitializeDatabaseSchema(); /// Ensure the database schema is created
        }


        /// <summary>
        /// creates a private method to clean the database by using email addresses as the primary key, 
        /// to ensure a clean database for each test case.
        /// </summary>
        /// <param name="emailAddress">The user's email address.</param>
        private void CleanupDatabase(string emailAddress)
        {
            /// Gets connection to the database.
            using var conn = _dbHelper.GetConnection();
            conn.Open();
            /// Creates the logic that when called deletes a users info using the email address asigned to then.
            using var cmd = new SqliteCommand("DELETE FROM Clients WHERE EmailAddress = @EmailAddress", conn);
            cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// creates a database schema to create the structure of the database for sqlite.
        /// </summary>
        private void InitializeDatabaseSchema()
        {
            /// Opens a connection to the database to create a new table schema if there is not one already existing of same value.
            using var conn = _dbHelper.GetConnection();
            conn.Open();
            using var cmd = new SqliteCommand(@"
                CREATE TABLE IF NOT EXISTS Clients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
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
        /// Tests the database has a connection to the local SQLite server.
        /// </summary>
        [Fact]
        public void TestDatabaseConnection()
        {
            /// Act: Calls _dbHelper to get connection to the server.
            using (var conn = _dbHelper.GetConnection())
            {
                conn.Open();
                /// Assert: Uses systems data to ensure the connection is equal to true.
                Assert.Equal(System.Data.ConnectionState.Open, conn.State);
            }
        }

        /// <summary>
        /// Tests the database gets initialised.
        /// </summary>
        [Fact]
        public void TestInitializeDatabase()
        {
            /// Arrange: Creates a new client by filling the database schema with appropriate data.
            var testClient = new Client
            {
                Forename = "Database",
                Surname = "Tester",
                EmailAddress = "dbtester@example.com",
                PhoneNumber = "5555555555",
                HashedPassword = PasswordHasher.HashPassword("Password123"),
                Address = "123 Test Address",
                City = "Test City",
                Postcode = "TEST123",
                Software = true,
                LaptopsPC = true,
                Games = true,
                OfficeTools = false,
                Accessories = false
            };

            /// Act: Inserts the new client by calling _dbHelper.
            int result = _dbHelper.InsertClient(testClient);
            ///: Assert: Checks that the result of insertion has a value greater than 0 to check 
            ///data is now in the database schema.
            Assert.True(result > 0);
        }

        /// <summary>
        /// integration tests the ValidateUsers method, VerifyPassword Method and uses the 
        /// PaswordHasher.cs as they rely on each other to function.
        /// </summary>
        [Fact]
        public void TestingValidateUser()
        {
            /// Act: Calls _dbHelper to get connection to the server.
            using var conn = _dbHelper.GetConnection();
            conn.Open();

            /// Arrange: creates a var of type string called password.
            string password = "SecurePassword123!";

            /// Arrange: parses the password string through the HashPassword method to encrypt it, 
            /// and transfers the newly encryped password to a string called hashedPassword
            string hashedPassword = PasswordHasher.HashPassword(password);

            /// Arrange: Adds a test client into the database with the correctly hashed password from before.
            var newClient = new Client
            {
                Forename = "Jane",
                Surname = "Doe",
                EmailAddress = "janedoe@example.com",
                PhoneNumber = "0987654321",
                HashedPassword = hashedPassword,
                Address = "Scrope Avenue",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Act: Insert the client into the database.
            _dbHelper.InsertClient(newClient);

            /// Act: Now call the ValidateUser method with the email and password created before.
            var client = _dbHelper.ValidateUser("janedoe@example.com", hashedPassword);

            /// Assert: Verify that the returned client is correct and matches the inserted data.
            Assert.NotNull(client);  /// Ensure that the client is returned
            Assert.Equal("Jane", client.Forename);  /// Check the Forename
            Assert.Equal("Doe", client.Surname);  /// Check the Surname

            /// Act: Validates the password by using PasswordHasher.VerifyPassword method.
            bool isPasswordValid = PasswordHasher.VerifyPassword(password, newClient.HashedPassword);

            /// Assert: That the password is valid.
            Assert.True(isPasswordValid, "The password should be valid and match the stored hash.");
        }

        /// <summary>
        /// Tests the InsertClient method.
        /// </summary>
        [Fact]
        public void TestInsertClient()
        {
            /// Arrange: Ensure the database is clean before new test.
            CleanupDatabase("janedoe@example.com");

            /// Arrange: Creates new user called newClient.
            var newClient = new Client
            {
                Forename = "Jane",
                Surname = "Doe",
                EmailAddress = "janedoe@example.com",
                PhoneNumber = "0987654321",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword123!"),
                Address = "456 Another St",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Act: Inserts the newly made client by calling the InsertClient method.
            int result = _dbHelper.InsertClient(newClient);

            /// Assert: Verify that the result is greater then 0 to ensure a client has been inserted.
            Assert.True(result > 0, "Client insertion failed.");
        }

        /// <summary>
        /// integration tests for the DeleteClient method and uses the GetClientById method.
        /// </summary>
        [Fact]
        public void TestDeleteClient()
        {
            CleanupDatabase("janedoe@example.com"); /// Ensure no previous data exists.
            InitializeDatabaseSchema(); /// Reset schema if necessary.

            /// Arrange: Create a new client and insert it into the database.
            var uniqueEmail = $"janedoe_{Guid.NewGuid()}@example.com";
            var newClient = new Client
            {
                Forename = "Jane",
                Surname = "Doe",
                EmailAddress = uniqueEmail,
                PhoneNumber = "0987654321",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword123!"),
                Address = "456 Another St",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Arrange: Creates new user called newClient.
            int actualClientID = _dbHelper.InsertClient(newClient);
            Assert.True(actualClientID > 0, "Client insertion failed.");

            try
            {
                /// Act: Delete the client by calling the DeleteClient method.
                _dbHelper.DeleteClient(actualClientID);

                /// Assert: Verify that the client is deleted by attempting to retrieve it again.
                InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                {
                    _dbHelper.GetClientById(actualClientID); /// This should throw an exception
                });

                /// Assert: That there is no user found by verifying the error message of no user found.
                Assert.Equal($"User with ID {actualClientID} not found.", exception.Message);
            }
            finally
            {
                /// Act: Cleanup in case of test failure
                _dbHelper.DeleteClient(actualClientID);
            }
            /// Remove the test client from the database

        }

        /// <summary>
        /// Tests the GetClientByID method.
        /// </summary>
        [Fact]
        public void TestGetClientByID()
        {
            /// Cleanup any existing data with the same email address.
            CleanupDatabase("janedoe@example.com");

            /// Ensure schema is initialized.
            InitializeDatabaseSchema();

            /// Arrange: Create a new client with a unique email.
            var uniqueEmail = $"janedoe_{Guid.NewGuid()}@example.com";
            var newClient = new Client
            {
                Forename = "Jane",
                Surname = "Doe",
                EmailAddress = uniqueEmail,
                PhoneNumber = "0987654321",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword123!"),
                Address = "456 Another St",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Arrange: Insert the client into the database by calling the InsertCLient method.
            int actualClientID = _dbHelper.InsertClient(newClient);

            /// Act: Now retrieve the client by ID by calling the GetClientById method with actualClientID.
            var retrievedClient = _dbHelper.GetClientById(actualClientID);

            /// Assert: Verify that the client is not null and that the forename and surname match the client inserted originally.
            Assert.NotNull(retrievedClient);
            Assert.Equal("Jane", retrievedClient.Forename);
            Assert.Equal("Doe", retrievedClient.Surname);

            /// Remove the test clients from the database.
            _dbHelper.DeleteClient(actualClientID);
        }

        /// <summary>
        /// Tests GetUserData method.
        /// </summary>
        [Fact]
        public void TestGetUserData()
        {
            /// Get a connection from the server using _dbHelper.
            using var conn = _dbHelper.GetConnection();
            conn.Open();

            /// Arrange: Create a new client and insert it into the database.
            var newClient = new Client
            {
                Forename = "tim",
                Surname = "jim",
                EmailAddress = "timjim@example.com",
                PhoneNumber = "0987654321",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword123!"),
                Address = "456 Another St",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Act: Insert the client into the database using the InsertClientMethod.
            int actualClient = _dbHelper.InsertClient(newClient);
            Assert.True(actualClient > 0, "Client insertion failed.");
            Console.WriteLine($"Inserted client with ID: {actualClient}");

            /// Act: Retrieve user data by the inserted client ID by using the GetUserData method.
            var clientList = _dbHelper.GetUserData(actualClient);
            Console.WriteLine($"Retrieved {clientList.Count} clients for client ID: {actualClient}");

            /// Assert: Validate that the returned data matches the inserted client.
            Assert.NotNull(clientList);
            Client client = Assert.Single(clientList); /// Only one client should be returned.
            var retrievedClient = clientList.First();

            /// Asser: Verify that the data retrieved is equal to the data inserted.
            Assert.Equal("tim", retrievedClient.Forename);
            Assert.Equal("jim", retrievedClient.Surname);
            Assert.Equal("timjim@example.com", retrievedClient.EmailAddress);
            Assert.Equal("0987654321", retrievedClient.PhoneNumber);
            Assert.Equal("456 Another St", retrievedClient.Address);
            Assert.Equal("Test City", retrievedClient.City);
            Assert.Equal("CD34 5EF", retrievedClient.Postcode);
            Assert.True(retrievedClient.Software);
            Assert.False(retrievedClient.LaptopsPC);
            Assert.True(retrievedClient.Games);
            Assert.True(retrievedClient.OfficeTools);
            Assert.False(retrievedClient.Accessories);


        }

        /// <summary>
        /// Tests GetSortedData Method.
        /// </summary>
        [Fact]
        public void TestGetSortedData()
        {
            /// Arrange: Create multiple test clients and insert them into the database for sorting later.
            var newClient1 = new Client
            {
                Forename = "Jane",
                Surname = "Doe",
                EmailAddress = "janedoe@example.com",
                PhoneNumber = "0987654321",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword123!"),
                Address = "456 Another St",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Arrange: Create multiple test clients and insert them into the database for sorting later.
            var newClient2 = new Client
            {
                Forename = "John",
                Surname = "Davis",
                EmailAddress = "johndoe@example.com",
                PhoneNumber = "0987654323",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword234!"),
                Address = "245 Another St",
                City = "Test2 City",
                Postcode = "CD54 5EF",
                Software = false,
                LaptopsPC = false,
                Games = true,
                OfficeTools = false,
                Accessories = false
            };

            /// Arrange: Create multiple test clients and insert them into the database for sorting later.
            var newClient3 = new Client
            {
                Forename = "Charlie",
                Surname = "Smith",
                EmailAddress = "charlie.davis@example.com",
                PhoneNumber = "5555555555",
                HashedPassword = PasswordHasher.HashPassword("Password789!"),
                Address = "789 Oak St",
                City = "City C",
                Postcode = "67890",
                Software = true,
                LaptopsPC = true,
                Games = true,
                OfficeTools = false,
                Accessories = true
            };

            /// Arrange: Insert the clients into the database by calling the InsertClient method.
            int actualClient1 = _dbHelper.InsertClient(newClient1);
            int actualClient2 = _dbHelper.InsertClient(newClient2);
            int actualClient3 = _dbHelper.InsertClient(newClient3);

            try
            {
                /// Act: Retrieve sorted data (e.g., sorted by Surname in ascending order).
                var sortedClients = _dbHelper.GetSortedData("Surname", "ASC");

                /// Assert: Verify that the data is correctly sorted by Surname in ascending order.
                Assert.NotNull(sortedClients);
                /// Assert: Verify the total number of clients returned.
                Assert.Equal(3, sortedClients.Count);

                /// Assert: verify the sorted clients are correctly sorted by verifying the positioning of the sorted clients.
                Assert.Equal("Davis", sortedClients[0].Surname);
                Assert.Equal("Doe", sortedClients[1].Surname);
                Assert.Equal("Smith", sortedClients[2].Surname);

                /// Act: Retrieve sorted data in descending order.
                var sortedClientsDesc = _dbHelper.GetSortedData("Surname", "DESC");

                /// Assert: Verify that the data is correctly sorted by Surname in descending order.
                Assert.NotNull(sortedClientsDesc);
                /// Assert: Verify the total number of clients returned.
                Assert.Equal(3, sortedClientsDesc.Count);

                /// Assert: verify the sorted clients are correctly sorted by verifying the positioning of the sorted clients.
                Assert.Equal("Smith", sortedClientsDesc[0].Surname);
                Assert.Equal("Doe", sortedClientsDesc[1].Surname);
                Assert.Equal("Davis", sortedClientsDesc[2].Surname);

            }
            finally
            {
                /// Remove the test clients from the database
                _dbHelper.DeleteClient(actualClient1);
                _dbHelper.DeleteClient(actualClient2);
                _dbHelper.DeleteClient(actualClient3);
            }
        }

        /// <summary>
        /// Integration test for Accessories.
        /// </summary>
        [Fact]
        public void TestAccessories()
        {
            /// Arrange: Create a new client with a unique email.
            var uniqueEmail = $"janedoe_{Guid.NewGuid()}@example.com";
            var AccessoriesNewClient = new Client
            {
                Forename = "Jane",
                Surname = "Doe",
                EmailAddress = uniqueEmail,
                PhoneNumber = "0987654321",
                HashedPassword = PasswordHasher.HashPassword("SecurePassword123!"),
                Address = "456 Another St",
                City = "Test City",
                Postcode = "CD34 5EF",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = true,
                Accessories = false
            };

            /// Act: Insert the client into the database by calling the InsertClient method.
            int actualAccessoriesClient = _dbHelper.InsertClient(AccessoriesNewClient);
            Assert.True(actualAccessoriesClient > 0, "Client insertion failed.");
            Console.WriteLine($"Inserted client with ID: {actualAccessoriesClient}");

            /// Act: Retrieve user data by the inserted client ID by calling the GetUserData method.
            var clientList = _dbHelper.GetUserData(actualAccessoriesClient);
            Console.WriteLine($"Retrieved {clientList.Count} clients for client ID: {actualAccessoriesClient}");

            /// Assert: Validate that the returned data matches the inserted client.
            Assert.NotNull(clientList);
            Client client = Assert.Single(clientList); /// Only one client should be returned
            var retrievedClient = clientList.First();

            /// Assert: verify that the Accessories retreived matches the Accessories inserted.
            Assert.True(retrievedClient.Software);
            Assert.False(retrievedClient.LaptopsPC);
            Assert.True(retrievedClient.Games);
            Assert.True(retrievedClient.OfficeTools);
            Assert.False(retrievedClient.Accessories);

            /// Remove data inserted into the database.
            _dbHelper.DeleteClient(actualAccessoriesClient);
        }

        /// <summary>
        /// Removes any testing data added to the database.
        /// </summary>
        public void Dispose()
        {
            CleanupDatabase("janedoe@example.com");
            CleanupDatabase("marksmith@example.com");
            CleanupDatabase("dbtester@example.com");
            CleanupDatabase("marksmith@SME.com");
            CleanupDatabase("timjim@example.com");
            CleanupDatabase("johndoe@example.com");
            CleanupDatabase("charlie.davis@example.com");
        }
    }
}
