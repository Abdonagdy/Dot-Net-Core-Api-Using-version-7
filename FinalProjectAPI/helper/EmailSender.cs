using MimeKit;
using System.Security.Authentication;
using System.Text;

namespace FinalProjectAPI.helper
{
    public class EmailSender
    {

        public async void SendEmail(string recipientEmail, List<string> cc, string mailSubject, StringBuilder sb_message)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("support@mize.com.sa"));
            emailToSend.To.Add(MailboxAddress.Parse(recipientEmail));
            if (cc.Count > 0)
            {
                foreach (var item in cc)
                {
                    if (!string.IsNullOrEmpty(item))
                        emailToSend.Cc.Add(MailboxAddress.Parse(item));
                }
            }

            emailToSend.Subject = mailSubject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = sb_message.ToString()
            };
            //send email
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.LocalDomain = "mize.com.sa";
                emailClient.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                emailClient.CheckCertificateRevocation = false;
                emailClient.Connect("smtppro.zoho.com", 465, true);//587//465
                emailClient.Authenticate("crm@mize.com.sa", "sz5JqvwXAVky");
                await emailClient.SendAsync(emailToSend);
                emailClient.Disconnect(true);

            }

        }

    }
}
