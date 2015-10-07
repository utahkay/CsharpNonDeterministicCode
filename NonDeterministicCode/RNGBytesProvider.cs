using System.Security.Cryptography;

namespace NonDeterministicCode
{
    public class RNGBytesProvider : IRandomBytesProvider
    {
        public void GetBytes(byte[] data)
        {
            new RNGCryptoServiceProvider().GetBytes(data);
        }
    }
}