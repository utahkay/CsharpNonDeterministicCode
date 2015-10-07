namespace NonDeterministicCode
{
    public interface IResetPasswordConfirmationRepository
    {
        void CreateTrackingFile(string userHandle, string token);
    }
}