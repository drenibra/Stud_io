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
            //email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            var sender = new MailboxAddress(string.Empty, "studio.qendrastudentore@gmail.com");
            email.From.Add(sender);
            email.Subject = subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = html };
            email.Body = new TextPart(TextFormat.Html) { Text = "<html>\r\n        <body>\r\n            <h1>Pershendetje Rrezart</h1>\r\n            <p>Kjo email eshte derguar nga Studio - Qendra Studentore</p>\r\n        </body>\r\n        </html> " };

            // send email using
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("rh52741@ubt-uni.net", "Rreziubt124");
            smtp.Send(email);
            smtp.Disconnect(true);
        }


    }
}
