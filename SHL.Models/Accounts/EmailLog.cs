using System;
using System.Collections.Generic;

namespace CSL.Models.Accounts
{
    public class EmailLog : BaseModel
    {

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool HasAttachment { get; set; }
        public bool IsSent { get; set; }
        public int Retires { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateToSend { get; set; }
        //  public DateTime DateCreated { get; set; }

        public virtual List<EmailLogAttachment> EmailAttachments { get; set; }
    }
}
