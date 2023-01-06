using System;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Framework.Email;
using Interfaces.Common;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;


namespace Services.Common
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ApplicationDbContext dbContext, ILogger<NotificationService> logger,
            IEmailConfiguration emailConfiguration)
        {
            _dbContext = dbContext;
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string emailTo, string message, string subject)
        {
            try
            {
                var email = _emailConfiguration.SmtpUsername;
                var password = _emailConfiguration.SmtpPassword;

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(_emailConfiguration.UserNameFrom, _emailConfiguration.AddressFrom));
                emailMessage.To.Add(new MailboxAddress("", emailTo));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                    await client.AuthenticateAsync(email, password);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Email не отправлен. Ошибка: " + e.Message);
                return false;
            }
        }
    }
}