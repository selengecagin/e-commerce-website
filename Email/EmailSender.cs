using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Linq.Expressions;

namespace e_commerce_website.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Options.SendGridKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress("selengecagin.pr@gmail.com", "Selenge"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage,
            };
            message.AddTo(new EmailAddress(email));
            try
            {
                return client.SendEmailAsync(message);
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public EmailOptions Options { get; set; }
        public EmailSender(IOptions <EmailOptions> emailOptions) {
            Options = emailOptions.Value;
        }
    }
}
