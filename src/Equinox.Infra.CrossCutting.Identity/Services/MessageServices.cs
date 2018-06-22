using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Equinox.Infra.CrossCutting.Identity.Services
{

    public class AuthEmailMessageSender : IEmailSender
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public AuthEmailMessageSender(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.From.Add(new MailboxAddress(_emailConfiguration.FromName, _emailConfiguration.FromAddress));

            mimeMessage.Subject = subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            mimeMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = message
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);

                //Remove any OAuth functionality as we won't be using it. 
                //emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                await emailClient.SendAsync(mimeMessage);

                await emailClient.DisconnectAsync(true);
            }
        }
    }

    public class AuthSMSMessageSender : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
