using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.ViewDto
{
    public class BankInfoDTO
    {
        public long Id { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public long? BankId { get; set; }
    }
}
