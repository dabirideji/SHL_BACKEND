using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Messages
{
    public class UserReadMessage
    {
        public long UserId { get; set; }
        public long Id { get; set; }
        public long MessageId { get; set; }
        public bool IsRead { get; set; }
    }
}
