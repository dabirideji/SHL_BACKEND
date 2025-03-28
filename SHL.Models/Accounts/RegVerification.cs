using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class RegVerification
    {
        public RegVerification()
        {
            DateCreated = DateTime.Now;
            ValidTill = DateCreated.AddHours(24);
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Otp { get; set; }
        public DateTime ValidTill { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
