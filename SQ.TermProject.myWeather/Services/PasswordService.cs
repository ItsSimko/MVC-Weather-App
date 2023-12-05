using System.Text;
using System.Security.Cryptography;
using System.Text;

namespace SQ.TermProject.myWeather.Services
{
    public class PasswordService
    {
        private const int SaltLength = 16;

        public static string SaltHashBytes(string passwordBytes, string salt)
        {
            string combined = passwordBytes + salt;
            return combined;
        }

        public static string GenerateSalt(int length)
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

        public static string GetSha256Hash(string input)
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
    }
}
