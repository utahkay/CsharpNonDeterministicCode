using System.Security.Cryptography;
using System.Text;

namespace NonDeterministicCode
{
    public class CryptoService : ICryptoService
    {
        public string GenerateRandomNumericString()
        {
            const int keyLength = 16;
            var randomBytes = new byte[keyLength];
            new RNGCryptoServiceProvider().GetBytes(randomBytes);
            var sb = new StringBuilder();
            foreach (var randomByte in randomBytes)
                sb.Append("0123456789"[randomByte % "0123456789".Length]);
            return sb.ToString();
        }
    }
}