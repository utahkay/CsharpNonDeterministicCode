using Machine.Specifications;

namespace NonDeterministicCode.Tests
{
    [Subject(typeof(SendPasswordResetEmail))]
    public class When_sending_a_password_reset_email 
        : With_an_automocked<SendPasswordResetEmail>
    {
        Because of = () => ClassUnderTest.Send("kay-johansen", 
            "kay-johansen@pluralsight.com");

        It should_create_a_tracking_file_with_random_token = () => 
            GetTestDouble<IResetPasswordConfirmationRepository>()
            .Verify(x => x.CreateTrackingFile("kay-johansen", Moq.It.IsAny<string>()));

        It should_send_the_email = () => GetTestDouble<IMailRequester>()
            .Verify(x => x.Request(
                MailTemplates.PasswordResetEmail,
                Moq.It.IsAny<string>(),
                "kay-johansen@pluralsight.com"));
    }
}
