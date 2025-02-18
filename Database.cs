using Microsoft.Data.Sqlite;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Manages the current session state (i.e., logged in Client ID).
    /// </summary>
    public static class SessionManager
    {
        /// <summary>
        /// Gets or sets the current client ID that is logged in.
        /// </summary>
        public static int CurrentClientID { get; set; } // Assuming UserId is an integer

        /// <summary>
        /// Clears the current session by resetting client ID.
        /// </summary>
        public static void ClearSession()
        {
            CurrentClientID = 0;
        }
    }

    /// <summary>
    /// Contains CRUD methods to interact with SQLite database.
    /// </summary>
    public class DatabaseHelper
    {
        private readonly string connectionString;

        /// <summary>
        /// Intialises a new instance of the <see cref="DatabaseHelper"/> class with connectionString.
        /// </summary>
        public DatabaseHelper()
        {
            connectionString = "Data Source=Clients.db";
        }

        /// <summary>
        /// Opens new SQLite connection.
        /// </summary>
        /// <returns>An open <see cref="SqliteConnection"/> object.</returns>
        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }

        /// <summary>
        /// Validates if submitted email address already exists.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns><c>true</c> if the email exists; otherwise <c>false</c>.</returns>
        public bool EmailExists(string email)
        {
            using var conn = GetConnection();
            conn.Open();
            string query = "SELECT COUNT(*) FROM Clients WHERE EmailAddress = @EmailAddress";

            using var cmd = new SqliteCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmailAddress", email);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }


        /// <summary>
        /// Validates submitted user data against SQLite database.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's plaintext password.</param>
        /// <returns>A <see cref="Client"/> object if validation succeeds.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the credentials are invalid.</exception>
        public Client ValidateUser(string email, string password)
        {
            using var conn = GetConnection();
            conn.Open();
            string query = @"SELECT ClientID, Forename, Surname, EmailAddress, PhoneNumber, Password, Address, City, Postcode,
                             Software, LaptopsPC, Games, OfficeTools, Accessories 
                             FROM Clients 
                             WHERE EmailAddress = @EmailAddress";

            using var cmd = new SqliteCommand(query, conn);

            cmd.Parameters.AddWithValue("@EmailAddress", email);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string storedHash = reader.GetString(5);

                // Validates password matches hashed password.
                if (!PasswordHasher.VerifyPassword(password, storedHash))
                {
                    throw new InvalidOperationException("Invalid email or password.");
                }

                bool isAdminEmail = Regexes.AdminEmailRegex().IsMatch(reader.GetString(3));

                var client = DataReaderExtensions.MapToLogin(reader);
                client.IsAdmin = isAdminEmail;

                return client;
            }

            throw new InvalidOperationException("Invalid email or password.");
        }

        /// <summary>
        /// Inserts a new client into SQLite database.
        /// </summary>
        /// <param name="client">The <see cref="Client"/> object to insert.</param>
        /// <returns>The number of rows affected.</returns>
        public int InsertClient(Client client)
        {
            using var conn = GetConnection();
            conn.Open();

            // Hash the password before inserting.
            string hashedPassword = PasswordHasher.HashPassword(client.HashedPassword);

            string sql = @"INSERT INTO Clients
                            (Forename, Surname, EmailAddress, Password, PhoneNumber, Address, City, Postcode, Software, LaptopsPC, Games, OfficeTools, Accessories) 
                            VALUES 
                            (@Forename, @Surname, @EmailAddress, @Password, @PhoneNumber, @Address, @City, @Postcode, @Software, @LaptopsPC, @Games, @OfficeTools, @Accessories)";

            using var cmd = new SqliteCommand(sql, conn);

            // Add special parameter for the hashed password.
            cmd.Parameters.AddWithValue("@Password", hashedPassword);

            // Dynamically add parameters for all client properties.
            foreach (var property in typeof(Client).GetProperties())
            {
                string paramName = $"@{property.Name}";
                object value = property.GetValue(client) ?? DBNull.Value;
                cmd.Parameters.AddWithValue(paramName, value ?? DBNull.Value);
            }

            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves a client by <c>unique</c> ID.
        /// </summary>
        /// <param name="clientID">The ID of the client to retrieve.</param>
        /// <returns>A <see cref="Client"/> object.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the client is not found.</exception>
        public Client GetClientById(int clientID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT Forename, Surname FROM Clients WHERE ClientID = @ClientID";

                using var cmd = new SqliteCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClientID", clientID);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return DataReaderExtensions.MapToUsername(reader);
                }
            }

            throw new InvalidOperationException($"User with ID {clientID} not found.");
        }

        /// <summary>
        /// Retrieves user data from SQLite database.
        /// </summary>
        /// <param name="clientId">The client ID of the user.</param>
        /// <param name="forename">The forename of the user.</param>
        /// <returns>A <see cref="Client"/> list.</returns>
        /// <exception cref="Exception">Throws an error if user data is not retrieved.</exception>
        public List<Client> GetUserData(int? clientId = null, string? forename = null)
        {
            List<Client> dataList = [];
            string query = @"SELECT ClientID, Forename, Surname, EmailAddress, PhoneNumber, Address, City, Postcode,
                            Software, LaptopsPC, Games, OfficeTools, Accessories FROM Clients";

            // Build the WHERE clause dynamically based on the input parameters
            List<string> conditions = [];

            if (clientId.HasValue)
            {
                conditions.Add("ClientID = @ClientID");
            }

            if (!string.IsNullOrEmpty(forename))
            {
                conditions.Add("Forename LIKE @Forename");
            }

            if (conditions.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", conditions);
            }

            try
            {
                using var conn = GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand(query, conn);

                if (clientId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@ClientID", clientId.Value);
                }
                if (!string.IsNullOrEmpty(forename))
                {
                    cmd.Parameters.AddWithValue("@Forename", "%" + forename + "%");
                }

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataList.Add(DataReaderExtensions.MapToClient(reader));
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching user data.", ex);
            }

            return dataList;
        }

        /// <summary>
        /// Retrieves sorted user data from SQLite database.
        /// </summary>
        /// <param name="field">The column name to be sorted (i.e., Forename).</param>
        /// <param name="order">The sort order (i.e., "ASC" and "DESC" for ascending/descending respectively.</param>
        /// <returns>A list of <see cref="Client"/> objects sorted as specified.</returns>
        /// <exception cref="ArgumentException">Thrown if the specified field is not valid or if the field/order values are null or empty.</exception>
        public List<Client> GetSortedData(string field, string order)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(order))
            {
                throw new ArgumentException("Field and order cannot be null or empty.");
            }

            // Ensure the field name is a valid column in the SQLite database "Clients" table.
            List<string> validFields =
            [
                "ClientID", "Forename", "Surname", "EmailAddress", "PhoneNumber",
                "Address", "City", "Postcode", "Software", "LaptopsPC", "Games",
                "OfficeTools", "Accessories"
            ];

            if (!validFields.Contains(field)) 
            {
                throw new ArgumentException("Invalid field name.");
            }

            // Validate the order value to prevent SQL injection.
            if (!string.Equals(order, "ASC", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(order, "DESC", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Sort order must be 'ASC' or 'DESC'.");
            }

            string query = $"SELECT ClientID, Forename, Surname, EmailAddress, PhoneNumber, Address, City, Postcode, " +
                           $"Software, LaptopsPC, Games, OfficeTools, Accessories FROM Clients ORDER BY {field} {order}";

            List<Client> clients = [];

            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqliteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            // Read each record and add to the clients list.
            while (reader.Read())
            {
                clients.Add(DataReaderExtensions.MapToClient(reader));
            }

            return clients;
        }

        /// <summary>
        /// Deletes a client by their <c>unique</c> ID.
        /// </summary>
        /// <param name="clientID">The client ID of the user.</param>
        public void DeleteClient(int clientID)
        {
            using var conn = GetConnection();
            conn.Open();
            string query = "DELETE FROM Clients WHERE ClientID = @ClientID";

            using var cmd = new SqliteCommand(query, conn);
            cmd.Parameters.AddWithValue("@ClientID", clientID);

            cmd.ExecuteNonQuery();
        }
    }
}

