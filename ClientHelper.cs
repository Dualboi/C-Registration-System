using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Methods for mapping data from <see cref="SqliteDataReader"/> to <see cref="Client"/> object.
    /// </summary>
    public static class DataReaderExtensions
    {
        /// <summary>
        /// Maps <see cref="SqliteDataReader"/> row to a full <see cref="Client"/> object.
        /// </summary>
        /// <param name="reader">The data reader containing client data.</param>
        /// <returns>A fully populated <see cref="Client"/> object.</returns>
        public static Client MapToClient(SqliteDataReader reader)
        {
            return new Client
            {
                ClientID = reader.GetInt32(0),
                Forename = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                Surname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                EmailAddress = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                PhoneNumber = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                Address = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                City = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                Postcode = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                Software = !reader.IsDBNull(8) && reader.GetInt32(8) == 1,
                LaptopsPC = !reader.IsDBNull(9) && reader.GetInt32(9) == 1,
                Games = !reader.IsDBNull(10) && reader.GetInt32(10) == 1,
                OfficeTools = !reader.IsDBNull(11) && reader.GetInt32(11) == 1,
                Accessories = !reader.IsDBNull(12) && reader.GetInt32(12) == 1
            };
        }

        /// <summary>
        /// Maps a <see cref="SqliteDataReader"/> row to a <see cref="Client"/> object with only forename/surname.
        /// </summary>
        /// <param name="reader">The data reader containing client data.</param>
        /// <returns>A <see cref="Client"/> object with limited data.</returns>
        public static Client MapToUsername(SqliteDataReader reader)
        {
            return new Client
            {
                Forename = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                Surname = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
            };
        }

        /// <summary>
        /// Maps a <see cref="SqliteDataReader"/> row to a <see cref="Client"/> object for login purposes.
        /// </summary>
        /// <param name="reader">The data reader containing client data.</param>
        /// <returns>A <see cref="Client"/> object with login-related data.</returns>
        public static Client MapToLogin(SqliteDataReader reader)
        {
            return new Client
            {
                ClientID = reader.GetInt32(0),
                Forename = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                Surname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                EmailAddress = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                PhoneNumber = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                Address = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                City = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                Postcode = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                Software = !reader.IsDBNull(9) && reader.GetInt32(9) == 1,
                LaptopsPC = !reader.IsDBNull(10) && reader.GetInt32(10) == 1,
                Games = !reader.IsDBNull(11) && reader.GetInt32(11) == 1,
                OfficeTools = !reader.IsDBNull(12) && reader.GetInt32(12) == 1,
                Accessories = !reader.IsDBNull(13) && reader.GetInt32(13) == 1,
            };
        }   
    }

    /// <summary>
    /// Provides helper methods to generate data tables for displaying client information.
    /// </summary>
    public static class ClientDataHelper
    {
        /// <summary>
        /// Generates a data table containing detailed client information.
        /// </summary>
        /// <param name="client">The client whose data will populate the table.</param>
        /// <returns>A <see cref="DataTable"/> representing the client's information.</returns>
        public static DataTable GenerateClientDataTable(Client client)
        {
            DataTable resultTable = new();

            resultTable.Columns.Add("Field");
            resultTable.Columns.Add("Value");

            resultTable.Rows.Add("Forename", client.Forename);
            resultTable.Rows.Add("Surname", client.Surname);
            resultTable.Rows.Add("EmailAddress", client.EmailAddress);
            resultTable.Rows.Add("PhoneNumber", client.PhoneNumber);
            resultTable.Rows.Add("Address", client.Address);
            resultTable.Rows.Add("City", client.City);
            resultTable.Rows.Add("Postcode", client.Postcode);
            resultTable.Rows.Add("Software", client.Software);
            resultTable.Rows.Add("LaptopsPC", client.LaptopsPC);
            resultTable.Rows.Add("Games", client.Games);
            resultTable.Rows.Add("OfficeTools", client.OfficeTools);
            resultTable.Rows.Add("Accessories", client.Accessories);

            return resultTable;
        }

        /// <summary>
        /// Generates a data table containing information for multiple clients.
        /// </summary>
        /// <param name="clients">A list of clients to include in the table.</param>
        /// <returns>A <see cref="DataTable"/> representing the clients' information.</returns>
        public static DataTable GenerateAdminDataTable(List<Client> clients)
        {
            DataTable resultTable = new();

            // Define table columns.
            resultTable.Columns.Add("ClientID", typeof(int));
            resultTable.Columns.Add("Forename", typeof(string));
            resultTable.Columns.Add("Surname", typeof(string));
            resultTable.Columns.Add("EmailAddress", typeof(string));
            resultTable.Columns.Add("PhoneNumber", typeof(string));
            resultTable.Columns.Add("Address", typeof(string));
            resultTable.Columns.Add("City", typeof(string));
            resultTable.Columns.Add("Postcode", typeof(string));
            resultTable.Columns.Add("Software", typeof(bool));
            resultTable.Columns.Add("LaptopsPC", typeof(bool));
            resultTable.Columns.Add("Games", typeof(bool));
            resultTable.Columns.Add("OfficeTools", typeof(bool));
            resultTable.Columns.Add("Accessories", typeof(bool));

            // Populate table rows.
            foreach (var client in clients)
            {
                DataRow row = resultTable.NewRow();
                row["ClientID"] = client.ClientID;
                row["Forename"] = client.Forename;
                row["Surname"] = client.Surname;
                row["EmailAddress"] = client.EmailAddress;
                row["PhoneNumber"] = client.PhoneNumber;
                row["Address"] = client.Address;
                row["City"] = client.City;
                row["Postcode"] = client.Postcode;
                row["Software"] = client.Software;
                row["LaptopsPC"] = client.LaptopsPC;
                row["Games"] = client.Games;
                row["OfficeTools"] = client.OfficeTools;
                row["Accessories"] = client.Accessories;

                resultTable.Rows.Add(row);
            }
            return resultTable;
        }
    }
}

