using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class CompanyInfo:BaseEntity
    {
        public string? LogoUrl { get; set; }
        public string CompanyName { get; set; } = default!;
        public string CompanyCurrencyCode { get; set; } = "NGN";
        public string Address { get; set; } = default!;
        public string DomainName { get; set; } = default!;
        public string NormalizedDomainName { get; set; } = default!;
        public bool IsActive { get; set; }
        public string? ConnectionString { get; set; }
    }
}
