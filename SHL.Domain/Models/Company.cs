using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class Company : BaseEntity
    {
        public string? CompanyEmailAddress { get; set; }
        public string? LogoUrl { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCode { get; set; }
        public string? CompanyCurrencyCode { get; set; }="NGN";
        public double CompanySharePriceValuation { get; set; }=1.0;
        public string? CompanyAddress { get; set; }
        public string? CompanyDomainName { get; set; }
        public decimal CompanyTotalShareAmount {get;set;}
        public double? CompanyAvailableShareAmount { get; set; }
        public double? CompanyVestableShareAmount => CompanyAvailableShareAmount;
        public double? CompanyOptionableShareAmount => CompanyAvailableShareAmount;
        public CompanyInfrastructureStatus? CompanyInfrastructureStatus { get; set; } = Categories.CompanyInfrastructureStatus.ACTIVE;
        public CompanyInfrastructureType? CompanyInfrastructureType { get; set; } = Categories.CompanyInfrastructureType.CORPORATE;
        public string? CompanyInfrastructureConnectionString { get; set; }
        [ForeignKey("CompanySetting")]
        public Guid? CompanySettingId { get; set; }
        public CompanySetting? CompanySetting { get; set; }
        public virtual ICollection<CompanySubscription>? CompanySubscriptions { get; set; }
    
        public virtual ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
        public virtual ICollection<EquityPlan> EquityPlans { get; set; } = new HashSet<EquityPlan>();
        public virtual ICollection<Shareholder> Shareholders { get; set; } = new HashSet<Shareholder>();
        public virtual ICollection<CompanyDepartment> Departments { get; set; } = [];
    }
}