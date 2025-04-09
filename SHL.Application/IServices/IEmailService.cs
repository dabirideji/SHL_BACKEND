using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.IServices
{
    public interface IEmailService
    {
        Task<bool> SendMail([EmailAddress] string mail, [Required] string messageBody, [Required] string subject);
        Task<bool> SendMailWithAttachmentAsync([EmailAddress] string mail, [Required] string messageBody, [Required] string subject, List<Attachment> attachments);
    }
}
