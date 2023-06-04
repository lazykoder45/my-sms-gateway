using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MySmsGateway.Services
{
    public class NotificationService
    {
        private readonly IConfiguration configuration;
        private readonly string defaultSenderName;
        private readonly string defaultSenderEmail;
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpUser;
        private readonly string smtpPassword;
        public NotificationService(IConfiguration configuration)
        {
            this.configuration = configuration;
            var defaultEmailSenderNode = configuration.GetSection("AppConfig:EmailSenderConfig:Default");
            this.defaultSenderName = defaultEmailSenderNode.GetSection("SenderName").Value;
            this.defaultSenderEmail = defaultEmailSenderNode.GetSection("SenderEmail").Value;
            var smtpConfig = configuration.GetSection("AppConfig:SmtpConfig");
            this.smtpHost = smtpConfig.GetSection("Host").Value;
            this.smtpPort = int.Parse(smtpConfig.GetSection("Port").Value);
            this.smtpUser = smtpConfig.GetSection("UserName").Value;
            this.smtpPassword = smtpConfig.GetSection("Password").Value;
        }

        private EmailSender GetSender(string senderKey)
        {
            if (!string.IsNullOrEmpty(senderKey))
            {
                var defaultEmailSenderNode = configuration.GetSection($"AppConfig:EmailSenderConfig:{senderKey}");
                if (defaultEmailSenderNode.Exists())
                {
                    var name = defaultEmailSenderNode.GetSection("SenderName").Value;
                    var email = defaultEmailSenderNode.GetSection("SenderEmail").Value;
                    return new EmailSender(name, email);
                }
            }

            return new EmailSender(defaultSenderName, defaultSenderEmail);
        }

        public async Task SendEmail(string subject, string mailBody, string toEmail, string toName = "", string senderKey = "")
        {
            var sender = GetSender(senderKey);
            using var message = new MimeMessage();
            message.From.Add(new MailboxAddress(sender.Name, sender.Email));
            message.To.Add(new MailboxAddress(toName, toEmail));
            message.Subject = subject;
            var bodyBuilder = new BodyBuilder { HtmlBody = mailBody };
            message.Body = bodyBuilder.ToMessageBody();
            using var client = new SmtpClient();
            await client.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(userName: smtpUser, password: smtpPassword);

            Console.WriteLine("Sending email");
            await client.SendAsync(message);
            Console.WriteLine("Email sent");

            await client.DisconnectAsync(true);
        }
    }

    public record EmailSender(string Name, string Email);
}
