using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Views
{
    public class vwDividendPayment
    {
		public int warr_no { get; set; }
        public int? pytno { get; set; }
        public short? regcode { get; set; }
        public int? acct_no { get; set; }
        public string div_type { get; set; }
        public double? holding { get; set; }
        public decimal? netamt { get; set; }
        public decimal? gross { get; set; }
        public decimal? tax { get; set; }
        public DateTime? payable_dt { get; set; }
        public bool? warr_status { get; set; }
        public bool? warr_reissue { get; set; }
        public DateTime? reissue_dt { get; set; }
        public bool? warr_veri { get; set; }
        public bool? unclaim { get; set; }
        public DateTime? veri_dt { get; set; }
        public DateTime? paid_dt { get; set; }
        public string who { get; set; }
        public DateTime? enterd_dt { get; set; }
        public string chg_who { get; set; }
        public DateTime? chg_dt { get; set; }
        public int? olddiv_no { get; set; }
        public int? pyt { get; set; }
        public DateTime? year_end { get; set; }
        public string descr { get; set; }
        public string storage_no { get; set; }
        public int? chn { get; set; }
        public DateTime? dt_clear { get; set; }
        public int? solid_acct { get; set; }
        public string dup { get; set; }
        public string grp { get; set; }
        public bool? supplement { get; set; }
        public int? consolid_Id { get; set; }
        public bool? claimed { get; set; }
        public DateTime? claimedate { get; set; }
        public string claimedby { get; set; }
        public int? batch { get; set; }
        public bool? audit_check { get; set; }
        public bool? revalid { get; set; }
        public DateTime? revalid_dt { get; set; }
        public short? category { get; set; }
        public string revalid_note { get; set; }
        public string annotation { get; set; }
        public string category_desc { get; set; }
        public DateTime? audit_check_dt { get; set; }
        public int? auto { get; set; }
        public bool? fcle { get; set; }
        public bool? div_loc { get; set; }
        public decimal? netamt_loc { get; set; }
        public decimal? gross_loc { get; set; }
        public decimal? tax_loc { get; set; }
        public decimal? div_loc_rate { get; set; }
        public bool? chqpd { get; set; }
        public bool? rtgs { get; set; }
        public long? old_warr_no { get; set; }
        public string curr_code { get; set; }
        public bool is_claimed { get; set; }
	}
}
