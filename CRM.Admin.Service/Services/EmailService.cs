using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CRM.Admin.Service.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings");
            using (var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            })
            {
                client.Credentials = new NetworkCredential(smtpSettings["SenderEmail"], smtpSettings["SenderPassword"]);
                client.EnableSsl = bool.Parse(smtpSettings["UseSsl"]);
                //client.TargetName = "STARTTLS/smtp.gmail.com";
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings["SenderEmail"]),
                    Subject = subject,
                    Body = body,
                };
                mailMessage.To.Add(toEmail);
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
