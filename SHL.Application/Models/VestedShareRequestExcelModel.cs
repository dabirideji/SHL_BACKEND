using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Models
{
   public class VestedShareRequestExcelModel
    {
        public string ReferenceNumber { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public decimal TransferRequestValue { get; set; }

    }
}
