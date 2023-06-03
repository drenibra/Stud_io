using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Services.Implementations
{
    public class MailKitEmailService : IMailKitEmailService
    {

        public void SendEmail(string to, string subject, string html, string from)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = html };
            email.Body = new TextPart(TextFormat.Html) { Text = "<html>\r\n        <body>\r\n            <h1>Test</h1>\r\n            <p>Hello},</p>\r\n        </body>\r\n        </html> " };

            // send email using
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("studio.qendrastudentore", "AlmaBleonaDreniFatiRrezi");
            smtp.Send(email);
            smtp.Disconnect(true);
        }


    }
}
