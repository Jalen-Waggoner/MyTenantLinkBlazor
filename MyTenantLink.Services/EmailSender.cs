using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace MyTenantLink.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = _configuration.GetValue<string>("EmailSettings:apiKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration.GetValue<string>("EmailSettings:DefaultFrom:Address"), _configuration.GetValue<string>("EmailSettings:DefaultFrom:Name"));
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = client.SendEmailAsync(msg);

            return Task.CompletedTask;
        }
    }
}
