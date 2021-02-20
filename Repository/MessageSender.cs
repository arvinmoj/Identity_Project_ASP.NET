using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Repository
{
    public class MessageSender : IMessageSender
    {
        public MessageSender() : base()
        {
        }

        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            // SmtpClient
            using (var client = new SmtpClient())
            {
                // NetworkCredential
                var credentials = new NetworkCredential()
                {
                    // Enter email and password without ex: @gmail.com
                    UserName = "arvinmojaverian@hotmail.com",
                    Password = "Arvinmoj!1q2w3e!",
                };

                client.Credentials = credentials;
                client.Host = "smtp-mail.outlook.com";
                client.Port = 587;
                client.EnableSsl = true;

                // MailMessage
                using var emailMessage = new MailMessage()
                {
                    To = { new MailAddress(toEmail)},
                    // Enter email with ex: @gmail.com
                    From =  new MailAddress("arvinmojaverian@hotmail.com") ,
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml,
                };

                // Send Email 
                client.Send(emailMessage);

            }

            return Task.CompletedTask;

        }
    }
}
