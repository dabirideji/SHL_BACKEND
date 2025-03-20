using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Company
{
    public class UpdateCompanyInfoDto
    {
        public string CompanyName { get; set; } = default!;
        public string? CompanyEmailAddress { get; set; }
        public decimal TotalShares { get; set; }
        public double SharePrice { get; set; }
        public IFormFile? Logo { get; set; } = default!;

    }
}
