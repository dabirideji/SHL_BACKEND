using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using CSL.Models.Identity;
using Microsoft.Extensions.Logging;
using SHL.Application.DTO.SendEmail;
using SHL.Application.IServices;

namespace SHL.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly string smtpServer = "smtp.gmail.com"; 
        private readonly int smtpPort = 587;
        private readonly string smtpUsername = "Efezeino@gmail.com";
        private readonly string smtpPassword = "SHL";
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        public async Task<bool> SendMail(EmailDto dto)
        {
            try
            {
                using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(smtpUsername, "SHL");
                        mailMessage.To.Add(dto.mail);
                        mailMessage.Subject = dto.subject;
                        mailMessage.Body = dto.messageBody;
                        mailMessage.ReplyToList.Add(new MailAddress("NoReply@noreply.com"));
                        mailMessage.IsBodyHtml = true;

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                return false;
            }
        }

        public async Task<bool> SendMailWithAttachmentAsync(EmailDto dto)
        {
            try
            {
                using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(smtpUsername);
                        mailMessage.To.Add(dto.mail);
                        mailMessage.Subject = dto.subject;
                        mailMessage.Body = dto.messageBody;
                        mailMessage.IsBodyHtml = true;

                        // Attach files if provided
                        if (dto.attachments != null && dto.attachments.Any())
                        {
                            foreach (var attachment in dto.attachments)
                            {
                                mailMessage.Attachments.Add(attachment);
                            }
                        }

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                return false;
            }
        }

}

}
