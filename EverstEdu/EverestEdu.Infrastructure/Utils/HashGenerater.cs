using System.Security.Cryptography;
using System.Text;

namespace EverestEdu.Infrastructure.Utils
{
    public class HashGenerater
    {
        public static string Generate(string password)
        {
            const int keySize = 14;
            const int iterations = 35000;

            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                new byte[0],
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}
