using System;

namespace CSL.Models.DividendReinvestment
{
    public class DividendPaymentDate
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyRegCode { get; set; }
        public bool CompanyDividendPaymentStatus { get; set; } = true;
        public DateTime CompanyDividendPaymentDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
    }
}
