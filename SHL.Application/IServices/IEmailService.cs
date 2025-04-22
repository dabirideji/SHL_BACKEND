using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SHL.Application.DTO.SendEmail;

namespace SHL.Application.IServices
{
    public interface IEmailService
    {
        Task<bool> SendMail(EmailDto dto);
        Task<bool> SendMailWithAttachmentAsync(EmailDto dto);
    }
}
