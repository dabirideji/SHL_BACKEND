using CSL.Models.Accounts;
using CSL.Models.Enums;
using CSL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Messages
{
    
    public class Message : BaseModel
    {
        public Message()
        {
            Status = (int) MessageStatus.Pending;
        }
        //public long? SenderId { get; set; }
        //public long? ReceiverId { get; set; }
      
        public string Subject { get; set; }
        public string Content { get; set; }
        public string PlainContent { get; set; }
        public int Status { get; set; }

        //public ReadStatus ReadStatus { get; set; }

        //public DateTime DateSent { get; set; }
        //public ApplicationUser Sender { get; set; }
        //public UserVerification Receiver { get; set; }

    }


    public class FlashMsg  
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
