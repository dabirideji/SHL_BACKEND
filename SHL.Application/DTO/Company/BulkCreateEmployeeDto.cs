using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Company
{
    public class BulkCreateEmployeeDto
    {
        public IFormFile File { get; set; }
    }
}
