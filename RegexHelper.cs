using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Provides a centralised collection regex used in the application.
    /// </summary>
    public static partial class Regexes
    {
        /// <summary>
        /// Matches a valid email format.
        /// Ensures the string has no spaces, alongside including a single "@" and a domain (e.g. domain.com).
        /// </summary>
        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public static partial Regex EmailRegex();

        /// <summary>
        /// Matches a valid UK phone number.
        /// Ensures the string contains only digits and is greater than or equal to 10 characters.
        /// </summary>
        [GeneratedRegex(@"^\d{10,}$")]
        public static partial Regex PhoneNumberRegex();

        /// <summary>
        /// Matches valid city names.
        /// Ensures the string contains only upper/lowercase letters and spaces.
        /// </summary>
        [GeneratedRegex(@"^[A-Za-z\s]+$")]
        public static partial Regex CityRegex();

        /// <summary>
        /// Matches valid UK postcode formats.
        /// Ensures the string contains only alphanumeric characters/spaces, and ranges from 6 to 8 characters long.
        /// </summary>
        [GeneratedRegex(@"^[A-Za-z0-9\s]{6,8}$")]
        public static partial Regex PostcodeRegex();

        /// <summary>
        /// Matches string containing at least one uppercase letter.
        /// Used for password strength validation.
        /// </summary>
        [GeneratedRegex(@"[A-Z]")]
        public static partial Regex UpperCaseRegex();

        /// <summary>
        /// Matches string containing at least one lowercase letter.
        /// Used for password strength validation.
        /// </summary>
        [GeneratedRegex(@"[a-z]")]
        public static partial Regex LowerCaseRegex();

        /// <summary>
        /// Matches string containing at least one digit.
        /// Used for password strength validation.
        /// </summary>
        [GeneratedRegex(@"\d")]
        public static partial Regex DigitRegex();

        /// <summary>
        /// Matches string containing at least one special character.
        /// Used for password strength validation.
        /// </summary>
        [GeneratedRegex(@"[\W_]")]
        public static partial Regex SpecialCharRegex();

        /// <summary>
        /// Matches email addresses associated with admin accounts.
        /// Ensures the email is in the correct format (e.g. "name@SME.com").
        /// </summary>
        [GeneratedRegex(@"^[a-zA-Z0-9._%+\-]+@SME\.com$")]
        public static partial Regex AdminEmailRegex();
    }
}
