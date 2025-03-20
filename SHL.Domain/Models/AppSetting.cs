using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class AppSetting : BaseEntity
    {
        public bool CanEmployeeTransferShares { get; set; }
        public bool AllowIncentive { get; set; }
        public bool ToggleRsuEquityType { get; set; }
        public bool ToggleOptionsEquityType { get; set; }
        public bool ToggleSharePlan { get; set; }
        public decimal ExerciseRequestTaxValue { get; set; }
    }
}
