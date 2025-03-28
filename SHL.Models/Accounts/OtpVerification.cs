using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSL.Models.Accounts
{
    public class OtpVerification
    {
        
        public int Id { get; set; }      
        public string PhoneNumber { get; set; }

        public string OtpCode { get; set; }
        
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
       
        public DateTime ExpiresAt { get; set; }
       
        public bool IsVerified { get; set; } = false;

        public int Attempts { get; set; } = 0;

        // Method to check if the OTP is expired
        public bool IsExpired()
        {
            return DateTime.Now > ExpiresAt;
        }
    }
}
