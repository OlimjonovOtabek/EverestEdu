using EverestEduApplication.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace EverestEdu.Infrastructure.Providers
{
    public class HashProvider : IHashProvider
    {
        public string GetHash(string value)
        {
            const int keySize = 14;
            const int iterations = 35000;

            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(value),
                new byte[0],
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}
