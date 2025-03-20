using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class Offer : BaseEntity
    {
        public Guid EquityPlanId { get; set; }
        public string OfferHolder { get; set; } = default!;
        public string EquityHolderEmailAddress { get; set; } = default!;
        public string? EquityHolderUniqueId { get; set; }
        public decimal OfferValue { get; set; }
        public decimal BalanceOfferValue { get; set; }
        public decimal EstimatedOfferValue { get; set; }
        public DateTime VestStartDate { get; set; }
        public DateTime VestEndDate { get; set; }
        public double VestingPeriod { get; set; }
        public DateTime? GrantDate { get; set; }
        public string Status { get; set; } = default!;
        public decimal EquityPrice { get; set; }
        public decimal ExcercisePrice { get; set; }

        /// <summary>
        /// OfferValue x ExcercisePrice. only valid for Option EquityType
        /// </summary>
        public decimal EstimatedValue { get; set; }
        public bool IsOfferSigned { get; set; }
        public string? SignatureUrl { get; set; }
        public DateTime? SignedDate { get; set; }
        public string? SignedOfferUrl { get; set; }
        public virtual EquityPlan? EquityPlan { get; set; }
        public virtual VestedShareTransfer? VestedShareTransfer { get; set; }

        public virtual ICollection<ExcerciseRequest> ExcerciseRequests { get; set; } = new HashSet<ExcerciseRequest>();
    }
}
