namespace Stud_io.Application.Services.Interfaces
{
    public interface IMailKitEmailService
    {
        void SendEmail(string to, string subject, string html, string from);
    }
}
