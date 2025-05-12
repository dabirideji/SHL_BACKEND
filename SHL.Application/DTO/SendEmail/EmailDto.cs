using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.SendEmail
{
    public class EmailDto
    {
        public string mail { get; set; }
        public string messageBody { get; set; }
        public string subject { get; set; }
        public List<Attachment> attachments { get; set; }
    }
}
