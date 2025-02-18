using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Programming_03_Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Programming_03_Assignment.ValidationHelper;

namespace Project_Testing
{
    /// <summary>
    /// This file contains a set of tests for the ValidationHelper.cs file.
    /// </summary>
    public class ValidationHelperTester : IDisposable
    {
        private readonly DatabaseHelper _dbHelper;

        public ValidationHelperTester()
        {
            /// Initialize the DatabaseHelper instance.
            _dbHelper = new DatabaseHelper();
            InitializeDatabaseSchema(); /// Ensure the database schema is created.
        }


        /// <summary>
        /// creates a private method to clean database of email addresses to be called for testing.
        /// </summary>
        /// <param name="emailAddress">The Clients email.</param>
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
        /// Tests RegistrationData class.
        /// </summary>
        [Fact]
        public void RegistrationDataTest()
        {
            /// Arrange: Create valid registration data.
            var validData = new RegistrationData
            {
                Forename = "John",
                Surname = "Doe",
                Email = "john.doe@example.com",
                EmailConfirm = "john.doe@example.com",
                Password = "StrongPass123!",
                PasswordConfirm = "StrongPass123!",
                PhoneNumber = "1234567890",
                Address = "123 Main Street",
                City = "Test City",
                Postcode = "AB12 3CD",
                Software = true,
                LaptopsPC = false,
                Games = true,
                OfficeTools = false,
                Accessories = true
            };

            /// Act: Validate the data.
            var errors = Validate(validData);

            /// Assert: Expect no errors.
            Assert.Empty(errors);
        }

        /// <summary>
        /// Integration test for the Validate method.
        /// </summary>
        [Fact]
        public void IntegrationtTestValidate()
        {
            /// Arrange: Create invalid registration data.
            var invalidData = new RegistrationData
            {
                Forename = "John",
                Surname = "Doe",
                Email = "john.doe@example",
                EmailConfirm = "john.doe@wrong.com", /// Mismatched emails
                Password = "weakpass",
                PasswordConfirm = "differentpass", /// Mismatched passwords
                PhoneNumber = "abc123", /// Invalid phone number
                Address = "12", /// Too short
                City = "123City", /// Invalid characters
                Postcode = "!@#123" /// Invalid characters
            };

            /// Act: Validate the data.
            var errors = Validate(invalidData);

            /// Assert: Expect specific errors which shows the Validation method has correctly validated the data.
            Assert.Contains("Emails do not match.", errors);
            Assert.Contains("Invalid email format.", errors);
            Assert.Contains("Passwords do not match.", errors);
            Assert.Contains(
                "Password is not strong enough. It must be at least 8 characters long and include uppercase letters," +
                " lowercase letters, numbers, and special characters.",
                errors);
            Assert.Contains("Phone number must contain only digits and be at least 10 characters long.", errors);
            Assert.Contains("Address must be at least 5 characters long.", errors);
            Assert.Contains("City can only contain letters and spaces.", errors);
            Assert.Contains("Postcode must be 4 to 10 alphanumeric characters (letters, digits, or spaces).", errors);
        }


        /// <summary>
        /// Tests IsValidEmail method.
        /// </summary>
        [Fact]
        public void IsValidEmailTest()
        {
            /// Arrange: Define the email regex patterns.
            var validEmail = "marksmith@gmail.com";
            var invalidEmail = "marksmith@com";
            var invalidEmail2 = "marksmith.com";

            /// Act: Check if the regex correctly identifies emails.
            bool isValidEmail = Regexes.EmailRegex().IsMatch(validEmail);
            bool isInvalidEmail = Regexes.EmailRegex().IsMatch(invalidEmail);
            bool isInvalidEmail2 = Regexes.EmailRegex().IsMatch(invalidEmail2);


            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidEmail, $"The email '{validEmail}' should be recognized as an email.");
            Assert.False(isInvalidEmail, $"The email '{invalidEmail}' should not be recognized as an email.");
            Assert.False(isInvalidEmail2, $"The email '{invalidEmail2}' should not be recognized as an email.");
        }

        /// <summary>
        /// Tests IsStrongPassword method.
        /// </summary>
        [Fact]
        public void IsStrongPasswordTest()
        {
            /// Arrange: Define test passwords.
            var validPassword = "StrongPass123!";
            var invalidPassword = "weak";/// Too short, no special character.
            var invalidPassword2 = "NoSpecial123";/// Missing special character.
            var invalidPassword3 = "nouppercase!123";/// Missing uppercase letter.
            var invalidPassword4 = "NOLOWERCASE!123";/// Missing lowercase letter.
            var invalidPassword5 = "NoDigits!";/// Missing digits.

            /// Use reflection to access the private IsStrongPassword method.
            var method = typeof(ValidationHelper)
                .GetMethod("IsStrongPassword", System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Static);

            /// Act: Invoke the private method for each test password.
            bool isValidPassword = (bool)method.Invoke(null, new object[] { validPassword });
            bool isInvalidPassword = (bool)method.Invoke(null, new object[] { invalidPassword });
            bool isInvalidPassword2 = (bool)method.Invoke(null, new object[] { invalidPassword2 });
            bool isInvalidPassword3 = (bool)method.Invoke(null, new object[] { invalidPassword3 });
            bool isInvalidPassword4 = (bool)method.Invoke(null, new object[] { invalidPassword4 });
            bool isInvalidPassword5 = (bool)method.Invoke(null, new object[] { invalidPassword5 });


            /// Assert: Verify results with added error catchers for easy error catching.
            Assert.True(isValidPassword, $"The password '{validPassword}' should be recognized as a strong password.");
            Assert.False(isInvalidPassword, $"The password '{invalidPassword}' should not be recognized as a strong password.");
            Assert.False(isInvalidPassword2, $"The password '{invalidPassword2}' should not be recognized as a strong password.");
            Assert.False(isInvalidPassword3, $"The password '{invalidPassword3}' should not be recognized as a strong password.");
            Assert.False(isInvalidPassword4, $"The password '{invalidPassword4}' should not be recognized as a strong password.");
            Assert.False(isInvalidPassword5, $"The password '{invalidPassword5}' should not be recognized as a strong password.");
        }

        /// <summary>
        /// Removes any testing data added to the database.
        /// </summary>
        public void Dispose()
        {
            //CleanupDatabase("janedoe@example.com");
        }
    }
}
