using System.Security.Cryptography;
using System.Text;

namespace NonDeterministicCode
{
    public class SendPasswordResetEmail
    {
        readonly IMailRequester mailRequester;
        readonly IResetPasswordConfirmationRepository resetPasswordConfirmationRepository;
        public const string ResetPasswordUri = "http://forgotpassword.ps.com?token=";

        public SendPasswordResetEmail(IMailRequester mailRequester, IResetPasswordConfirmationRepository resetPasswordConfirmationRepository)
        {
            this.mailRequester = mailRequester;
            this.resetPasswordConfirmationRepository = resetPasswordConfirmationRepository;
        }

        public void Send(string userHandle, string userEmailAddress)
        {
            var token = GenerateRandomNumericString();
            resetPasswordConfirmationRepository.CreateTrackingFile(userHandle, token);
            var uri = ResetPasswordUri + token;
            mailRequester.Request(MailTemplates.PasswordResetEmail, uri, userEmailAddress);
        }

        public static string GenerateRandomNumericString()
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
