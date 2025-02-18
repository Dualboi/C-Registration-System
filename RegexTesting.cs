using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming_03_Assignment;

namespace Project_Testing
{
    /// <summary>
    /// This file contains multiple unit tests for the RegexHelper.cs file.
    /// </summary>
    public class RegexTesting
    {
        /// <summary>
        /// Tests EmailRegex.
        /// </summary>
        [Fact]
        public void EmailRegexTesting()
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
        /// Tests PhoneNumberRegex.
        /// </summary>
        [Fact]
        public void PhoneNumberRegexTesting()
        {
            /// Arrange: Defines the Phone number regex patterns.
            var validNumber = "1234567891";
            var invalidNumber = "123456789i";
            var invalidNumber2 = "1234";

            /// Act: Check if the regex correctly identifies phone numbers.
            bool isValidNumber = Regexes.PhoneNumberRegex().IsMatch(validNumber);
            bool isInvalidEmail = Regexes.PhoneNumberRegex().IsMatch(invalidNumber);
            bool isInvalidEmail2 = Regexes.PhoneNumberRegex().IsMatch(invalidNumber2);

            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidNumber, $"The Phone number '{validNumber}' should be recognized as a Phone number.");
            Assert.False(isInvalidEmail, $"The Phone number '{invalidNumber}' should not be recognized as a Phone number.");
            Assert.False(isInvalidEmail2, $"The Phone number '{invalidNumber2}' should not be recognized as a Phone number.");
        }

        /// <summary>
        /// Tests CityRegex.
        /// </summary>
        [Fact]
        public void CityRegexTesting()
        {
            /// Arrange: Define the city number regex patterns.
            var validCity = "London";
            var invalidCity = "London1";

            /// Act: Check if the regex correctly identifies the correct regex.
            bool isValidCity = Regexes.CityRegex().IsMatch(validCity);
            bool isInvalidCity = Regexes.CityRegex().IsMatch(invalidCity);

            /// Assert: Verify the regex behavior is correct with error messages for easy error recognition.
            Assert.True(isValidCity, $"The city '{validCity}' should be recognized as a valid city.");
            Assert.False(isInvalidCity, $"The city '{invalidCity}' should not be recognized as a valid city.");
        }

        /// <summary>
        /// Tests PostcodeRegex.
        /// </summary>
        [Fact]
        public void PostcodeRegexTesting()
        {
            /// Arrange: Define the Postcode regex patterns.
            var validPost = "YO1 7AE";
            var validPost1 = "CH5 3QWWW";
            var invalidPost = "CH5 3QWWWW";
            var invalidPost1 = "CH5";
            var invalidPost2 = "CH5 3QW/";

            /// Act: Check if the regex correctly identifies Postcodes.
            bool isValidPost = Regexes.PostcodeRegex().IsMatch(validPost);
            bool isValidPost1 = Regexes.PostcodeRegex().IsMatch(validPost1);
            bool isInvalidPost = Regexes.PostcodeRegex().IsMatch(invalidPost);
            bool isInvalidPost1 = Regexes.PostcodeRegex().IsMatch(invalidPost1);
            bool isInvalidPost2 = Regexes.PostcodeRegex().IsMatch(invalidPost2);


            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidPost, $"The Post Code '{validPost}' should be recognized as a valid Post Code.");
            Assert.True(isValidPost, $"The Post Code '{validPost1}' should be recognized as a valid Post Code.");
            Assert.False(isInvalidPost, $"The Post Code '{invalidPost}' should not be recognized as a valid Post Code.");
            Assert.False(isInvalidPost1, $"The Post Code '{invalidPost1}' should not be recognized as a valid Post Code.");
            Assert.False(isInvalidPost2, $"The Post Code '{invalidPost2}' should not be recognized as a valid Post Code.");
        }

        /// <summary>
        /// Tests UpperCaseRegex.
        /// </summary>
        [Fact]
        public void UpperCaseRegexTesting()
        {
            /// Arrange: Define the uppercase regex patterns.
            var validUpper = "A";
            var invalidUpper = "a";

            /// Act: Check if the regex correctly identifies the characters.
            bool isValidUpper = Regexes.UpperCaseRegex().IsMatch(validUpper);
            bool isInvalidUpper = Regexes.UpperCaseRegex().IsMatch(invalidUpper);

            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidUpper, $"The character '{validUpper}' should be recognized as a uppercase character.");
            Assert.False(isInvalidUpper, $"The character '{invalidUpper}' should not be recognized as a uppercase character.");
        }

        /// <summary>
        /// Tests LowerCaseRegex.
        /// </summary>
        [Fact]
        public void LowerCaseRegexTesting()
        {
            /// Arrange: Define the Lowercase regex pattern.
            var validLower = "a";
            var invalidLower = "A";

            /// Act: Check if the regex correctly identifies the character.
            bool isValidUpper = Regexes.LowerCaseRegex().IsMatch(validLower);
            bool isInvalidUpper = Regexes.LowerCaseRegex().IsMatch(invalidLower);

            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidUpper, $"The character '{validLower}' should be recognized as a Lowercase character.");
            Assert.False(isInvalidUpper, $"The character '{invalidLower}' should not be recognized as a Lowercase character.");
        }

        /// <summary>
        /// Tests DigitRegex.
        /// </summary>
        [Fact]
        public void DigitRegexTesting()
        {
            /// Arrange: Define the digit regex patterns.
            var validDigit = "1";
            var invalidDigit = "a";
            var invalidDigit1 = "#";
            var invalidDigit2 = " ";

            /// Act: Check if the regex correctly identifies the character
            bool isValidDigit = Regexes.DigitRegex().IsMatch(validDigit);
            bool isInvalidDigit = Regexes.DigitRegex().IsMatch(invalidDigit);
            bool isInvalidDigit1 = Regexes.DigitRegex().IsMatch(invalidDigit1);
            bool isInvalidDigit2 = Regexes.DigitRegex().IsMatch(invalidDigit2);

            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidDigit, $"The character '{validDigit}' should be recognized as a Digit.");
            Assert.False(isInvalidDigit, $"The character '{invalidDigit}' should not be recognized as a Digit.");
            Assert.False(isInvalidDigit1, $"The character '{invalidDigit1}' should not be recognized as a Digit.");
            Assert.False(isInvalidDigit2, $"The character '{invalidDigit2}' should not be recognized as a Digit.");
        }

        /// <summary>
        /// Tests SpecialCharRegex.
        /// </summary>
        [Fact]
        public void SpecialCharRegexTesting()
        {
            /// Arrange: Define the special character regex patterns.
            var validSpecial = "#";
            var invalidSpecial = "a";

            /// Act: Check if the regex correctly identifies the special characters.
            bool isValidSpecial = Regexes.SpecialCharRegex().IsMatch(validSpecial);
            bool isInvalidSpecial = Regexes.SpecialCharRegex().IsMatch(invalidSpecial);

            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidSpecial, $"The character '{validSpecial}' should be recognized as a special character.");
            Assert.False(isInvalidSpecial, $"The character '{invalidSpecial}' should not be recognized as a special character.");
        }


        /// <summary>
        /// Tests AdminEmailRegex.
        /// </summary>
        [Fact]
        public void AdminEmailRegexTesting()
        {
            /// Arrange: Define the admin email regex pattern.
            var validAdminEmail = "marksmith@SME.com";
            var invalidAdminEmail = "marksmith@gmail.com";

            /// Act: Check if the regex correctly identifies admin emails.
            bool isValidAdminEmail = Regexes.AdminEmailRegex().IsMatch(validAdminEmail);
            bool isInvalidAdminEmail = Regexes.AdminEmailRegex().IsMatch(invalidAdminEmail);

            /// Assert: Verify the regex behavior with error messages for easy error recognition.
            Assert.True(isValidAdminEmail, $"The email '{validAdminEmail}' should be recognized as an admin email.");
            Assert.False(isInvalidAdminEmail, $"The email '{invalidAdminEmail}' should not be recognized as an admin email.");
        }
    }
}