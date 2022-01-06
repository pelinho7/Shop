using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IEmailService
    {
        (bool, string) SendEmail(string recevierEmail, string subject, string body);
        Task<(bool, string)> SendEmailAsync(string recevierEmail, string subject, string body);
    }
}