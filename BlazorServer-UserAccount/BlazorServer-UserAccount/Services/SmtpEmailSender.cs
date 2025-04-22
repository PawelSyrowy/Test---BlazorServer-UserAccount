using System.Net;
using System.Net.Mail;
using BlazorServer_UserAccount.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BlazorServer_UserAccount.Services
{
    public class SmtpEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IConfiguration _config;

        public SmtpEmailSender(IConfiguration config)
        {
            _config = config;
        }

        // Implementing the SendEmailAsync method
        public async Task SendEmailAsync(ApplicationUser user, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_config["Smtp:Host"])
            {
                Port = int.Parse(_config["Smtp:Port"]),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_config["Smtp:Username"]),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            mail.To.Add(user.Email);
            await client.SendMailAsync(mail);
        }

        // Implementing the SendPasswordResetCodeAsync method
        public async Task SendPasswordResetCodeAsync(ApplicationUser user, string subject, string resetLink)
        {
            var client = new SmtpClient(_config["Smtp:Host"])
            {
                Port = int.Parse(_config["Smtp:Port"]),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_config["Smtp:Username"]),
                Subject = subject,
                Body = resetLink,
                IsBodyHtml = true
            };

            mail.To.Add(user.Email);
            await client.SendMailAsync(mail);
        }

        // Implementing the SendPasswordResetLinkAsync method
        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string subject, string resetLink)
        {
            var client = new SmtpClient(_config["Smtp:Host"])
            {
                Port = int.Parse(_config["Smtp:Port"]),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_config["Smtp:Username"]),
                Subject = subject,
                Body = resetLink,
                IsBodyHtml = true
            };

            mail.To.Add(user.Email);
            await client.SendMailAsync(mail);
        }

        // Implementing the SendConfirmationLinkAsync method
        public async Task SendConfirmationLinkAsync(ApplicationUser user, string subject, string confirmationLink)
        {
            var client = new SmtpClient(_config["Smtp:Host"])
            {
                Port = int.Parse(_config["Smtp:Port"]),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_config["Smtp:Username"]),
                Subject = subject,
                Body = confirmationLink,
                IsBodyHtml = true
            };

            mail.To.Add(user.Email);
            await client.SendMailAsync(mail);
        }
    }
}
