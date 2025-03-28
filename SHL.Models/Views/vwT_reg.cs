using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Views
{
    public class vwT_reg
    {
        public int regcode { get; set; }
        public int? coy_no { get; set; }
        public DateTime? date_tak { get; set; }
        public string sec_type { get; set; }
        public string description { get; set; }
        public decimal? nominal { get; set; }
        public double? shares { get; set; }
        public string who { get; set; }
        public DateTime? enterd_dt { get; set; }
        public string chg_who { get; set; }
        public DateTime? chg_dt { get; set; }
        public string caution { get; set; }
        public bool? active { get; set; }
        public string symbol { get; set; }
        public bool? fraction { get; set; }
        public string fund_cert_narr { get; set; }
        public int? bond_freq { get; set; }
        public double? bond_price { get; set; }
        public double? bond_red_cnt { get; set; }
        public int? deci { get; set; }
        public bool? spec_reg { get; set; }
        public int? verif_ref { get; set; }
        public string reis_ref { get; set; }
        public bool? for_trns { get; set; }
        public string def_curr { get; set; }
        public bool? nasd { get; set; }
        public bool? nodemat { get; set; }
        public string edmmsregnm { get; set; }
        public double? issu_cap { get; set; }
        public DateTime? cntr_dt { get; set; }
        public DateTime? prev_dt { get; set; }
        public double? shr_alrt { get; set; }
        public byte[] reg_log { get; set; }
        public string nse_symbol { get; set; }
        public bool? fmdq { get; set; }
	}
}
