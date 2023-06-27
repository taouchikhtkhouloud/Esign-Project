using Esign.Application.Configurations;
using Esign.Application.Interfaces.Services;
using Esign.Application.Requests.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Esign.Infrastructure.Shared.Services
{
    public class SMTPMailService : IMailService
    {
        //private readonly MailConfiguration _config;
        //private readonly ILogger<SMTPMailService> _logger;

        //public SMTPMailService(IOptions<MailConfiguration> config, ILogger<SMTPMailService> logger)
        //{
        //    _config = config.Value;
        //    _logger = logger;
        //}

        //public async Task SendAsync(MailRequest request)
        //{
        //    using var smtp = new SmtpClient();
        //    try
        //    {
        //        var emailMessage = new MimeMessage();
        //        emailMessage.From.Add(new MailboxAddress("email", request.From ?? _config.From));
        //        var recipient = MailboxAddress.Parse(request.To);
        //        emailMessage.To.Add(recipient);
        //        emailMessage.Subject = request.Subject;
        //        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = request.Body };

        //        //var email = new MimeMessage
        //        //{
        //        //    Sender = new MailboxAddress(request.From ?? _config.From),
        //        //    Subject = request.Subject,
        //        //    Body = new BodyBuilder
        //        //    {
        //        //        HtmlBody = request.Body
        //        //    }.ToMessageBody()
        //        //};


        //         smtp.Connect(_config.Host, _config.Port, SecureSocketOptions.StartTls);
        //        smtp.AuthenticationMechanisms.Remove("XOAUTH2");
        //         smtp.Authenticate(_config.UserName, _config.Password);
        //         await smtp.SendAsync(emailMessage);

        //    }
        //    catch (System.Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //    }
        //    finally
        //    {
        //        smtp.Disconnect(true);
        //        smtp.Dispose();
        //    }
        //}
        private readonly MailConfiguration _emailConfig;
        public SMTPMailService(IOptions<MailConfiguration> config )
        {
            _emailConfig = config.Value;
        }
        public void SendAsync(MailRequest message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(MailRequest message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.Host, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}