using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Views
{
    public class vwBanks
    {
        public short agent_code { get; set; }
        public string agent_name { get; set; }
        public string agent_type { get; set; }
        public string enteredby { get; set; }
        public string cscslcode { get; set; }
        public DateTime createdat { get; set; }
        public string changedby { get; set; }
        public DateTime changedat { get; set; }
        public string cbn_code_num { get; set; }
        public string cbn_bank_code { get; set; }
        public string offcr { get; set; }
        public string phon { get; set; }
        public string email { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string addr3 { get; set; }
        public string bc_title { get; set; }
        public string swiftcode { get; set; }
        public string sortcode { get; set; }
        public string BankCode { get; set; }
        public string cscsnmcd { get; set; }
        public string edmmsnmcd { get; set; }
        public string branch_code { get; set; }
        public string iban { get; set; }
        public string routing { get; set; }
	}
}
