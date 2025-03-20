using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class OfferOwner
    {
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public decimal VestedOptions { get; set; }
        public decimal UnVestedOptions { get; set; }
        public decimal VestedRsu { get; set; }
        public decimal UnVestedRsu { get; set; }
        public decimal TotalSecurities { get; set; }
        public decimal Ownership { get; set; }
        public string? TotalValue { get; set; }
    }

    public class Owner
    {
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? Status { get; set; }
        public decimal TotalValue { get; set; }
    }
}
