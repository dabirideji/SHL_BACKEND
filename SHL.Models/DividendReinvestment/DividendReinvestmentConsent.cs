using System;

namespace CSL.Models.DividendReinvestment
{
    public class DividendReinvestmentConsent
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Consent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
    } 
}
