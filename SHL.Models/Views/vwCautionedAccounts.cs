using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwCautionedAccounts
    {
        public int Acctno { get; set; }
        public string email { get; set; }
        public byte? status1 { get; set; }
        public int? status { get; set; }
        public string caution_ref { get; set; }
	}
}
