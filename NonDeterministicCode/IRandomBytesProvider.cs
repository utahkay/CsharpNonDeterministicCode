namespace NonDeterministicCode
{
    public interface IRandomBytesProvider
    {
        void GetBytes(byte[] data);
    }
}