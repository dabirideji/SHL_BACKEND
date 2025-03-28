using System;

namespace CSL.Models.DividendReinvestment
{
    public class AnnualReport
    {
        public int Id { get; set; }
        public string AnnualReportTitle { get; set; }
        public string AnnualReportCompanyId { get; set; }
        public string AnnualReportCompanyName { get; set; }
        public string AnnualReportCompanyRegCode { get; set; }
        public string AnnualReportCompanyLogoUrl { get; set; }
        public string AnnualReportUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
