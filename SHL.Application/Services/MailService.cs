using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace SHL.Application.Services
{
    public interface IMailService
    {
        Task<bool> SendMail([EmailAddress] string mail, [Required] string messageBody, [Required] string subject);
        Task SendMailWithAttachmentAsync([EmailAddress] string mail, [Required] string messageBody, [Required] string subject, List<Attachment> attachments);
    }
    public class MailService : IMailService
    {
        public Task<bool> SendMail([EmailAddress] string mail, [Required] string messageBody, [Required] string subject)
        {
            MailMessage m = new MailMessage();
            m.From = new MailAddress("Efezeino@gmail.com", "SHL");
            m.To.Add(mail);
            m.Body = messageBody;
            m.Subject = subject;
            m.ReplyToList.Add("NoReply@noreply.com");

            SmtpClient sm = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("Efezeino@gmail.com", "nornqzchaexdonxy")
            };
            // sm.Send(m);
            sm.Send(m);
            return Task.FromResult(true);
        }

        public async Task SendMailWithAttachmentAsync([EmailAddress] string mail, [Required] string messageBody, [Required] string subject,List<Attachment> attachments)
        {
            MailMessage m = new MailMessage();
            m.From = new MailAddress("Efezeino@gmail.com", "EquityPlan");
            m.To.Add(mail);
            m.Body = messageBody;
            m.Subject = subject;
            m.ReplyToList.Add("NoReply@noreply.com");
            foreach (var attachment in attachments)
            {
                m.Attachments.Add(attachment);
            }            

            SmtpClient sm = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("Efezeino@gmail.com", "nornqzchaexdonxy")
            };
            // sm.Send(m);
            await sm.SendMailAsync(m);

        }

    }
}