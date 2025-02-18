using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Validation utility helper for user registration.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Represents the data used for registration.
        /// </summary>
        public class RegistrationData
        {
            public string Forename { get; set; } = string.Empty;
            public string Surname { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string EmailConfirm { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string PasswordConfirm { get; set; } = string.Empty;
            public string PhoneNumber { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public string City { get; set; } = string.Empty;
            public string Postcode { get; set; } = string.Empty;
            public bool Software { get; set; }
            public bool LaptopsPC { get; set; }
            public bool Games { get; set; }
            public bool OfficeTools { get; set; }
            public bool Accessories { get; set; }
        }

        /// <summary>
        /// Validates user registration data and returns a list of error messages if validation fails.
        /// </summary>
        /// <param name="data">The registration data.</param>
        /// <returns>A list of error messages if not valid, otherwise it returns valid if the list is empty.</returns>
        public static List<string> Validate(RegistrationData data)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(data.Forename) ||
            string.IsNullOrWhiteSpace(data.Surname) ||
            string.IsNullOrWhiteSpace(data.Email) ||
            string.IsNullOrWhiteSpace(data.EmailConfirm) ||
            string.IsNullOrWhiteSpace(data.Password) ||
            string.IsNullOrWhiteSpace(data.PasswordConfirm) ||
            string.IsNullOrWhiteSpace(data.Address) ||
            string.IsNullOrWhiteSpace(data.City) ||
            string.IsNullOrWhiteSpace(data.Postcode))
            {
                errors.Add("Please fill in all required fields.");
                return errors;
            }

            // Validate email match.
            if (!string.Equals(data.Email, data.EmailConfirm))
            {
                errors.Add("Emails do not match.");
            }

            // Validate email format.
            if (!IsValidEmail(data.Email))
            {
                errors.Add("Invalid email format.");
            }

            // Validate password match.
            if (!string.Equals(data.Password, data.PasswordConfirm))
            {
                errors.Add("Passwords do not match.");
            }

            // Validate password strength.
            if (!IsStrongPassword(data.Password))
            {
                errors.Add("Password is not strong enough. " +
                           "It must be at least 8 characters long and " +
                           "include uppercase letters, lowercase letters, numbers, and special characters.");
            }

            // Validate phone number format.
            if (!string.IsNullOrWhiteSpace(data.PhoneNumber))
            {
                if (!Regexes.PhoneNumberRegex().IsMatch(data.PhoneNumber))
                {
                    errors.Add("Phone number must contain only digits and be at least 10 characters long.");
                }
            }

            // Validate address length.
            if (!string.IsNullOrWhiteSpace(data.Address) && data.Address.Length < 5)
            {
                errors.Add("Address must be at least 5 characters long.");
            }

            // Validate city format.
            if (!string.IsNullOrWhiteSpace(data.City))
            {
                if (!Regexes.CityRegex().IsMatch(data.City))
                {
                    errors.Add("City can only contain letters and spaces.");
                }
            }

            // Validate postcode format.
            if (!string.IsNullOrWhiteSpace(data.Postcode))
            {
                if (!Regexes.PostcodeRegex().IsMatch(data.Postcode))
                {
                    errors.Add("Postcode must be 4 to 10 alphanumeric characters (letters, digits, or spaces).");
                }
            }
            return errors;
        }

        /// <summary>
        /// Validates an email address format using a predefined regex.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns><c>true</c> if the email format is valid; otherwise, <c>false</c>.</returns>
        private static bool IsValidEmail(string email)
        {
            return Regexes.EmailRegex().IsMatch(email);
        }

        /// <summary>
        /// Checks whether a password meets the defined criteria.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns><c>true</c> if the password is strong; otherwise <c>false</c>.</returns>
        private static bool IsStrongPassword(string password)
        {
            if (password.Length < 8) return false;
            if (!Regexes.UpperCaseRegex().IsMatch(password)) return false;
            if (!Regexes.LowerCaseRegex().IsMatch(password)) return false;
            if (!Regexes.DigitRegex().IsMatch(password)) return false;
            if (!Regexes.SpecialCharRegex().IsMatch(password)) return false;
            return true;
        }
    }
}
