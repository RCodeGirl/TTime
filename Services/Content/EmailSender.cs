using DomainModel.Framework.Email;
using MailKit.Net.Smtp;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Content;
using DomainModel.Content;
using Microsoft.AspNetCore.Http;


namespace Services.Content
{
    public class EmailSender : IEmailSender

    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailSender> _logger;
       
        public EmailSender(IEmailConfiguration emailConfiguration, ILogger<EmailSender> logger)
        {
            _emailConfiguration = emailConfiguration;
            _logger = logger;
           

        }

        public void SendEmailAsync(Callback callback, IFormFile document)
        {
            try
            {
                var _email = _emailConfiguration.SmtpUsername;
                var _password = _emailConfiguration.SmtpPassword;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var emailMessage = new MimeMessage();
                var multipart = new Multipart("mixed");
                var textPart = new TextPart(TextFormat.Flowed)
                {
                     
                    Text = "Имя клиента: "+callback.Name + "\n Контактный номер телефона: " + callback.Phone + "\n Почта клиента: " + callback.Email + "\n Перевод с: " + callback.LanguageOrig + "  на " + callback.LanguageTarget,
                    ContentTransferEncoding = ContentEncoding.Base64,
                };
                multipart.Add(textPart);

                using (var fs = new MemoryStream())
                {
                    document.CopyTo(fs);
                    fs.Position = 0;

                    var attachmentPart = new MimePart(MediaTypeNames.Application.Pdf)
                    {

                        Content = new MimeContent(fs),
                        ContentTransferEncoding = ContentEncoding.Base64,
                       
                        FileName = document.FileName
                    };
                    multipart.Add(attachmentPart);
                    emailMessage.Body = multipart;
                    emailMessage.From.Add(new MailboxAddress(_emailConfiguration.UserNameFrom, _emailConfiguration.AddressFrom));
                    emailMessage.To.Add(new MailboxAddress("", "ababiy.margarita@mail.ru"));
                    emailMessage.Subject = callback.LanguageOrig + "-" + callback.LanguageTarget;
                    
                    using (var client = new SmtpClient())
                    {
                        client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                        client.Authenticate(_email, _password);
                        client.Send(emailMessage);
                        client.Disconnect(true);
                    }
                    _logger.LogInformation("Сообщение отправлено успешно");

                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Email не отправлен. Ошибка: " + e.Message);
            }
}

       
    }
}
