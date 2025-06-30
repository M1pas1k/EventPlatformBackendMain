using WebApplication.Application.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace WebApplication.Infrastructure.Email
{
    public class EmailSender(IConfiguration config) : IEmailSender
    {
        private readonly IConfiguration _config = config;

        public async Task SendAsync(string email, string subject, string content, CancellationToken ct)
        {
            var body = new TextPart("plain") { Text = content };
            var sender = new MailboxAddress(_config["SmtpSettings:SenderName"], _config["SmtpSettings:SenderEmail"]);
            var reciever = new MailboxAddress("", email);
            var message = new MimeMessage();

            message.From.Add(sender);
            message.To.Add(reciever);
            message.Subject = subject;
            message.Body = body;

            using var client = new SmtpClient();

            var smpt = _config["SmtpSettings:Server"];
            var port = int.Parse(_config["SmtpSettings:Port"] ?? throw new ArgumentNullException("Smpt port configuration missing"));
            await client.ConnectAsync(smpt, port, MailKit.Security.SecureSocketOptions.Auto, ct);
            await client.AuthenticateAsync(_config["SmtpSettings:Username"], _config["SmtpSettings:Password"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

        public async Task SendAsync(IEnumerable<string> emails, string subject, string content, CancellationToken ct)
        {
            foreach (var email in emails)
            {
                await SendAsync(email, subject, content, ct);
            }
        }

    }
}
