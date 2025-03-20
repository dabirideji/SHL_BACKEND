using SHL.Domain.Models;
using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UserOptionPortfolioDetails
    {
        // User Information
        public string UserEmail { get; set; }

        // Portfolio Information
        public double EstimatedOwnership { get; set; }
        public string EstimatedOwnershipCurrency { get; set; } = "NGN";
        public int ShareAmount { get; set; }
        public double SharePrice { get; set; }
        public double TotalShareValue { get; set; }
        public string ShareType { get; set; }
        public double DilutedOwnership { get; set; }

        // Option Grant Details
        public string OfferId { get; set; }
        public string OptionHoldingId { get; set; }
        public string OptionType { get; set; }
        public double OptionPrice { get; set; }
        public double ExercisePrice { get; set; }
        public string OptionStatus { get; set; }
        public string OptionSignatureStatus { get; set; }


 public OptionHolderVestingStatus VestingStatus { get; set; }
        public bool IsSent { get; set; } 
        public bool IsSigned { get; set; } 
        public string StartDate { get; set; }
        public string VestingStartDate { get; set; }
        public List<ReadVestingScheduleDto>? VestingSchedule { get; set; }
        public List<VestingActivation>? VestingActivations { get; set; }
        public List<ReadPoolDocumentDto>? Documents { get; set; }

        public string OfferType { get; set; }
        public string OptionsPoolName { get; set; }
    }

}
