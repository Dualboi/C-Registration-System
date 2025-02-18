using System;
using System.Security.Cryptography;

namespace Programming_03_Assignment
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Hashes a password using PBKDF2 with a SHA256 hash and a random salt.
        /// </summary>
        /// <param name="password">The plaintext password to hash.</param>
        /// <returns>A Base64-encoded string containing the salt and hash for storage.</returns>
        public static string HashPassword(string password)
        {
            // Generate a salt.
            byte[] salt = RandomNumberGenerator.GetBytes(16); // Generate a 16-byte salt

            // Derive the hash using PBKDF2.
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Combine the salt and hash.
            byte[] hashBytes = new byte[salt.Length + hash.Length];
            Array.Copy(salt, 0, hashBytes, 0, salt.Length);
            Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);

            // Return Base64-encoded result.
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Verifies a password against a stored hash.
        /// </summary>
        /// <param name="password">The plaintext password to verify.</param>
        /// <param name="storedHash">The Base64-encoded stored hash containing the salt/hash.</param>
        /// <returns><c>true</c> if the password matches stored hash; otherwise <c>false</c>.</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            // Decode the stored hash.
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extract the salt.
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, salt.Length);

            // Derive the salt using same method.
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Compare the stored hash with the derived hash in constant time.
            for (int i = 0; i < hash.Length; i++)
            {
                if (hashBytes[i + salt.Length] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
