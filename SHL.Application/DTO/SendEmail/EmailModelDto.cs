using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.SendEmail
{
    public class EmailModelDto
    {
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }

        public List<string>? CCEmails { get; set; }
        public List<string>? BCCEmails { get; set; }

        public List<EmailAttachment>? Attachments { get; set; }
    }

    public class EmailAttachment
    {
        public byte[] Content { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
    public class EmailResponse
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public static EmailResponse Ok() => new EmailResponse { Success = true };
        public static EmailResponse Fail(string message) => new EmailResponse { Success = false, ErrorMessage = message };
    }


}
