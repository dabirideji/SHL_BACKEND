namespace SHL.Domain.Models
{
    public class Shareholder : BaseEntity,IBaseEntity
    {      
        public Guid CompanyId { get; set; }
       // public string? CompanyName { get; set; }
        public string? CscsNumber { get; set; }
        public string? ChnNumber { get; set; }
        public Guid? BrokerId { get; set; }
        public string? ShareHolderEmployeeId { get; set; }
        public string? ShareholderPhoneNumber { get; set; }
        public string? ShareholderName { get; set; }
        public string? ShareholderAddress { get; set; }
        public string? ShareholderEmailAddress { get; set; }
        public decimal Holding { get; set; }
        public decimal PercentageHolding { get; set; }

        public virtual Company? Company { get; set; }
    }
}