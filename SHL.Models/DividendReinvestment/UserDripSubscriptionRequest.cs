using System;

namespace CSL.Models.DividendReinvestment
{
    public class UserDripSubscriptionRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string TotalShares { get; set; }
        public string CompanyName { get; set; }
        public string ClearingHouseNumber { get; set; }
        public string IsActive { get; set; } 
        public bool IsAccepted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
    }
}
