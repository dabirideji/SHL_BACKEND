using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.AppSetting
{
    public class UpdateSettingDto
    {
        public bool CanEmployeeTransferShares { get; set; }
        public bool AllowIncentive { get; set; }
        public bool ToggleRsuEquityType { get; set; }
        public bool ToggleOptionsEquityType { get; set; }
        public bool ToggleSharePlan { get; set; }
        public decimal ExerciseRequestTax { get; set; }
    }
}
