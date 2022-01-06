using API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace API.Services
{
    public class EmailService : IEmailService
    {
        IConfiguration config;
        ILogger<EmailService> logger;
        public EmailService(IConfiguration config, ILogger<EmailService> logger)
        {
            this.config = config;
            this.logger = logger;
        }

        public async Task<(bool,string)> SendEmailAsync(string recevierEmail,string subject,string body){
            return await Task.Run(()=>SendEmail(recevierEmail,subject,body));
        }

        public (bool,string) SendEmail(string recevierEmail,string subject,string body)
        {
            try
            {
                //sender email data
                string address = config["EmailCredential:Address"];
                string password = config["EmailCredential:Password"];
                // Credentials
                var credentials = new System.Net.NetworkCredential(address, password);
                // Mail message
                var mail = new System.Net.Mail.MailMessage()
                {
                    From = new System.Net.Mail.MailAddress($"noreply{address}"),
                    Subject = subject,
                    Body = body
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new System.Net.Mail.MailAddress(recevierEmail));
                // Smtp client
                var client = new System.Net.Mail.SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                logger.LogTrace($"EmailManager - SendEmail - email was sent to {recevierEmail}");
                return (true, null);
            }
            catch (System.Exception e)
            {
                logger.LogTrace($"EmailManager - SendEmail - error during sending email to {recevierEmail}. {e.Message}");
                return (false, e.Message);
            }
        }
    }
}