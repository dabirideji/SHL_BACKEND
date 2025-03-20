using SHL.Application.DTO.ContractDocument;
using SHL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.EquityPlan
{
   public class CreateEquityPlanDto
    {
        public string PlanName { get; set; } = default!;
        public decimal TotalEquity { get; set; }
        public string EquityType { get; set; } = default!;
        public string? OfferLetterName { get; set; }
        public string? OfferLetterContent { get; set; }
        public string? PlanRuleName { get; set; }
        public string? PlanRuleContentUrl { get; set; }
       
    }
}
