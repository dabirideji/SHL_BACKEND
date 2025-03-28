using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwDividendPaid
    {
        public DateTime cutoff_dt { get; set; }
        public short regcode { get; set; }
        public string div_type { get; set; }
        public decimal totamt { get; set; }
        public int sno { get; set; }
        public DateTime payable_dt { get; set; }
        public double tax_rate { get; set; }
        public string div_acct { get; set; }
        public decimal price { get; set; }
        public string who { get; set; }
        public DateTime acqdtpd { get; set; }
        public int paid { get; set; }
        public DateTime enterd_dt { get; set; }
        public string chg_who { get; set; }
        public DateTime chg_dt { get; set; }
        public int pyt { get; set; }
        public DateTime year_end { get; set; }
        public bool pyt_with_coy { get; set; }
        public decimal div_loc_rate { get; set; }
        public int offer_id { get; set; }
        public double spec_tx_rt { get; set; }
        public bool lock_reissue { get; set; }
        public string curr_code { get; set; }
	}
}
