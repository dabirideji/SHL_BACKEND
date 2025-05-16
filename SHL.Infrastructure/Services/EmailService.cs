using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SHL.Application.DTO.SendEmail;
using SHL.Application.IServices;

namespace SHL.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _configuration;

        public EmailService(ILogger<EmailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<EmailResponse> SendMail(EmailModelDto dto)
        {
            try
            {
                var smtpServer = _configuration["EmailSettings:SmtpServer"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
                var smtpUsername = _configuration["EmailSettings:SmtpUsername"];
                var smtpEmail = _configuration["EmailSettings:SmtpEmail"];
                var smtpPassword = _configuration["EmailSettings:SmtpPassword"];

                using var smtpClient = new SmtpClient(smtpServer, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = smtpPort != 25, // Enable SSL if not using port 25
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpEmail, "SHL"),
                    Subject = dto.Subject,
                    Body = dto.MessageBody,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(dto.Mail);
                mailMessage.ReplyToList.Add(new MailAddress(smtpEmail));

                // Add CC
                if (dto.CCEmails?.Any() == true)
                {
                    foreach (var cc in dto.CCEmails)
                        mailMessage.CC.Add(cc);
                }

                // Add BCC
                if (dto.BCCEmails?.Any() == true)
                {
                    foreach (var bcc in dto.BCCEmails)
                        mailMessage.Bcc.Add(bcc);
                }

                // Add Attachments
                if (dto.Attachments?.Any() == true)
                {
                    foreach (var attachment in dto.Attachments)
                    {
                        var memoryStream = new MemoryStream(attachment.Content);
                        var mailAttachment = new Attachment(memoryStream, attachment.FileName, attachment.ContentType);
                        mailMessage.Attachments.Add(mailAttachment);
                    }
                }

                _logger.LogInformation("Sending email to {Email} with subject '{Subject}'", dto.Mail, dto.Subject);
                await smtpClient.SendMailAsync(mailMessage);

                return EmailResponse.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email to {Email}", dto.Mail);
                return EmailResponse.Fail("Failed to send email: " + ex.Message);
            }
        }
    }
}
