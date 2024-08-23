namespace FinalProjectAPI.EmailTemplate
{
    public interface IEmailSendmessage
    {
      void  SendEmailmessage(string email, string subject , string message);
    }
}
