using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NonDeterministicCode
{
    public class SendPasswordResetEmail
    {
        readonly IMailRequester mailRequester;
        readonly IResetPasswordConfirmationRepository resetPasswordConfirmationRepository;
        const string ResetPasswordUri = "http://forgotpassword.ps.com?token=";
        const int KeyLength = 16;

        public SendPasswordResetEmail(IMailRequester mailRequester, IResetPasswordConfirmationRepository resetPasswordConfirmationRepository)
        {
            this.mailRequester = mailRequester;
            this.resetPasswordConfirmationRepository = resetPasswordConfirmationRepository;
        }

        public void Send(string userHandle, string userEmailAddress)
        {
            var uri = GenerateTokenUri(userHandle);
            mailRequester.Request(MailTemplates.PasswordResetEmail, uri, userEmailAddress);
        }

        public string GenerateTokenUri(string userHandle)
        {
            var token = GenerateRandomNumericString(KeyLength);
            resetPasswordConfirmationRepository.CreateTrackingFile(userHandle, token);
            return ResetPasswordUri + token;
        }

        public static string GenerateRandomNumericString(int length)
        {
            var randomBytes = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(randomBytes);
            var sb = new StringBuilder();
            foreach (var randomByte in randomBytes)
                sb.Append("0123456789"[randomByte % "0123456789".Length]);
            return sb.ToString();
        }
    }
}
