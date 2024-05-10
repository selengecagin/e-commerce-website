using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace e_commerce_website.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
        public EmailOptions Options { get; set; }
        public EmailSender(IOptions <EmailOptions> emailOptions) {
            Options = emailOptions.Value;
        }
    }
}
