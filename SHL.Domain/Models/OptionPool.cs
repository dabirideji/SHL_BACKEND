using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class OptionPool : BaseEntity
    {
        [ForeignKey("OptionPoolCompany")]
        public Guid? OptionPoolCompanyId { get; set; }
        public Company? OptionPoolCompany { get; set; }
        public string? OptionPoolName { get; set; }
        ////// SHARES
        public double OptionPoolTotalShares { get; set; }
        public double OptionPoolTotalSharesAvailable => OptionPoolTotalShares;
        public double OptionPoolTotalSharesVestable => OptionPoolTotalShares;
        public OptionPoolType OptionPoolType { get; set; }
        ////// FLAGS 
        public OptionPoolStatus? OptionPoolStatus { get; set; } = Categories.OptionPoolStatus.ACTIVE;
        public OptionPoolApprovalStatus? OptionPoolApprovalStatus { get; set; } = Categories.OptionPoolApprovalStatus.PENDING;
        public ICollection<OptionPoolApproval>? OptionPoolApprovals { get; set; }
    }

    public class Grant : BaseEntity
    {
        //CORE PROPERTIES
        [ForeignKey("GrantOptionPool")]
        public Guid? GrantOptionPoolId { get; set; }
        public OptionPool? GrantOptionPool { get; set; }
        public double GrantStrikePrice { get; set; }
        public double GrantExercisePrice { get; set; }
        public double GrantShareAmountTotal { get; set; }
        public double GrantShareAmountAvailable { get; set; }
        public double GrantShareAmountVested { get; set; }
        public double GrantShareAmountVestable => GrantShareAmountTotal;
        public double GrantShareAmountUnvested { get; set; }
        public Status GrantStatus { get; set; } = Status.ACTIVE;
        //NAVIGATION PROPERTIES
        public ICollection<VestingSchedule>? GrantVestingSchedules { get; set; }
        public ICollection<OptionHolder>? TargetOptionHolders { get; set; }
    }


    public class OptionHolder : BaseEntity
    {
        [ForeignKey("OptionHolderGrant")]
        public Guid OptionHolderGrantId { get; set; }
        public Grant? OptionHolderGrant { get; set; }
        public string? OptionHolderEmailAddress { get; set; }
        [ForeignKey("OptionHolderStaff")]
        public Guid OptionHolderStaffId { get; set; }
        public Staff? OptionHolderStaff { get; set; }
        public double OptionHolderAmount { get; set; }
        public double OptionHolderDilutedEquityPercentage { get; set; }
        public OptionHolderStatus OptionHolderStatus { get; set; } = OptionHolderStatus.PENDING;
        public OptionHolderVestingStatus OptionHolderVestingStatus { get; set; } = OptionHolderVestingStatus.AWAITING_VESTING;
        public bool OptionHoldingIsSent { get; set; } = false;
        public bool OptionHoldingIsSigned { get; set; } = false;
        public List<VestingActivation>? VestingActvations { get; set; }
    }

    public class Portfolio : BaseEntity
    {
        public string? EmployeeEmail { get; set; }
        [ForeignKey("OptionGrant")]
        public Guid? OptionId { get; set; }
        public Grant OptionGrant { get; set; }
        [ForeignKey("Employee")]
        public Guid? EmployeeId { get; set; }
        public Staff? Employee { get; set; }
        public string? CompanyName { get; set; }
        public double? TotalShareAmount { get; set; }
        public double? TotalShareValuation { get; set; }
        public double? DilutedOwnershipPercentage { get; set; }
        public double? TotalShareUnits { get; set; }
        public Status? Status { get; set; } = Categories.Status.PENDING;
    }

    public class VestingActivation : BaseEntity
    {
        [ForeignKey("OptionHolder")]
        public Guid? OptionHolderId { get; set; }
        public OptionHolder? OptionHolder { get; set; }

        [ForeignKey("VestingSchedule")]
        public Guid? VestingScheduleId { get; set; }
        public VestingSchedule? VestingSchedule { get; set; }
        public DateTime VestingActivationDate { get; set; }
        public double VestingRelativePercentage { get; set; }
        public double VestingDilutedPercentage { get; set; }
        public double VestingOpeningPercentage { get; set; }
        public double VestingAmountInShares { get; set; }
        public double VestingAmountInValuation { get; set; }
        public Status VestingStatus { get; set; } = Status.PENDING;
        public bool IsCliff { get; set; }
    }


    public class VestingSchedule : BaseEntity
    {
        [ForeignKey("Grant")]
        public Guid GrantId { get; set; }
        public Grant? Grant { get; set; }

        public VestingType? VestingType { get; set; }
        public VestingRecursionType? VestingForPeriod { get; set; }
        public int? VestingForValue { get; set; }

        public VestingRecursionType? VestingEveryPeriod { get; set; }
        public int? VestingEveryValue { get; set; }
        // CORE
        public string? VestingDetails
        {
            get
            {
                // Determine the "amount" part dynamically
                string amountDetails = VestSpecificAmount.HasValue
                    ? $"{VestSpecificAmount.Value} units"
                    : VestAmountInUnit.HasValue
                        ? $"{VestAmountInUnit.Value} units"
                        : VestRelativePercentage.HasValue
                            ? $"{VestRelativePercentage.Value}% of the total"
                            : "an unspecified amount";

                // Build the main details string
                string mainDetails = $"A {VestingType?.ToString().ToUpper() ?? "UNSPECIFIED TYPE"} " +
                                     $"FOR EVERY {VestingForValue?.ToString() ?? "UNSPECIFIED VALUE"} " +
                                     $"{VestingForPeriod?.ToString().ToUpper() ?? "UNSPECIFIED PERIOD"} " +
                                     $"{amountDetails} WILL BE VESTED " +
                                     $"FOR {VestingEveryValue?.ToString() ?? "UNSPECIFIED VALUE"} " +
                                     $"{VestingEveryPeriod?.ToString().ToUpper() ?? "UNSPECIFIED PERIOD"}.";

                return mainDetails;
            }
        }

        // FLAG
        public double? VestSpecificAmount { get; set; }
        public double? VestRelativePercentage { get; set; }
        public double? VestAmountInUnit { get; set; }
        public VestingAvailability? VestingAvailability { get; set; } = Categories.VestingAvailability.AVAILABLE;
        public VestingStatus VestingStatus
        {
            get
            {
                if (StartDate.HasValue)
                {
                    if (DateTime.Now >= StartDate.Value)
                    {
                        return Categories.VestingStatus.VESTING;
                    }
                    else
                    {
                        return Categories.VestingStatus.PENDING;
                    }
                }

                return Categories.VestingStatus.PENDING;
            }
        }
        public DateTime? StartDate { get; set; } // Vesting starts here
        public DateTime? EndDate { get; set; } // Optional: Predefined end date (overrides duration)
        public DateTime ExpiryDate { get; set; } // Vesting expires after this date
        public Status Status { get; set; } = Status.PENDING;
    }

    public class OptionHolderSignature : BaseEntity
    {
        [ForeignKey("OptionHolder")]
        public Guid? OptionHolderId { get; set; }
        public OptionHolder? OptionHolder { get; set; }
        public DateTime SignatureDate { get; set; }
        //public IFormFile? SignatureFile { get; set; }
        public string? SignatureFilePath { get; set; }
        public Status Status { get; set; } = Status.PENDING;
    }


    /// <summary>
    /// Tracks activations for specific vesting instances.
    ///  </summary>
    public class VestingApproval : BaseEntity
    {
        [ForeignKey("OptionHolding")]
        public Guid OptionHoldingId { get; set; }
        public OptionHolder? OptionHolding { get; set; }
        public string? ActivatedBy { get; set; } // Optional: Who activated it
        public DateTime ActivationDate { get; set; } // When the activation occurred
    }
}