using System.Text;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TermProject.myWeather.Services
{
    /// <summary>
    /// methods for password hashing and salting.
    /// </summary>
    public class PasswordService
    {
        private const int SaltLength = 16;

        /// <summary>
        /// Concatenates password bytes with a salt string.
        /// </summary>
        /// <param name="passwordBytes">The password bytes to combine.</param>
        /// <param name="salt">The salt string to append to the password.</param>
        /// <returns>The concatenated string of password bytes and salt.</returns>
        public static string SaltHashBytes(string passwordBytes, string salt)
        {
            string combined = passwordBytes + salt;
            return combined;
        }

        /// <summary>
        /// Generates a random salt of a specified length.
        /// </summary>
        /// <param name="length">The length of the salt to generate.</param>
        /// <returns>A string representing the generated salt.</returns>
        public static string GenerateSalt(int length)
        {
            try 
            {
                byte[] salt = new byte[length];
                using (var rng = new RNGCryptoServiceProvider())
                {

                    rng.GetNonZeroBytes(salt);

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < salt.Length; i++)
                    {
                        builder.Append(salt[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                LoggerService.Log("Exception thrown: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Computes the SHA256 hash of an input string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA256 hash of the input string.</returns>
        public static string GetSha256Hash(string input)
        {
            try
            {
                string canonicalized = input.Trim();
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(canonicalized));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception ex)
            {
                LoggerService.Log("Exception thrown: " + ex);
                return null;
            }

        }
    }
}
