using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using CSL.Models.Identity;
using SHL.Application.IServices;

namespace SHL.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly string smtpServer = "smtp.gmail.com"; 
        private readonly int smtpPort = 587;
        private readonly string smtpUsername = "Efezeino@gmail.com";
        private readonly string smtpPassword = "SHL";

        public async Task<bool> SendMail([EmailAddress] string mail, [Required] string messageBody, [Required] string subject)
        {
            MailMessage m = new MailMessage();
            m.From = new MailAddress("Efezeino@gmail.com", "SHL");
            m.To.Add(mail);
            m.Body = messageBody;
            m.Subject = subject;
            m.ReplyToList.Add("NoReply@noreply.com");

            SmtpClient sm = new SmtpClient("smtp.gmail.com");

            // Additional SMTP configuration is required here
            await sm.SendMailAsync(m);

            return true;
        }

        public async Task<bool> SendMailWithAttachmentAsync([EmailAddress] string mail, [Required] string messageBody, [Required] string subject, List<Attachment> attachments)
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
                        mailMessage.To.Add(mail);
                        mailMessage.Subject = subject;
                        mailMessage.Body = messageBody;
                        mailMessage.IsBodyHtml = true;

                        // Attach files if provided
                        if (attachments != null && attachments.Any())
                        {
                            foreach (var attachment in attachments)
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
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }

}

}
