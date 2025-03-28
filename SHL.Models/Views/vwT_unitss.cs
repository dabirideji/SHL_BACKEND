using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Views
{
    public class vwT_unitss
    {
        public int cert_number { get; set; }
        public short? regcode { get; set; }
        public int? acctno { get; set; }
        public string agent { get; set; }
        public DateTime? issue_dt { get; set; }
        public double units { get; set; }
        public bool? status { get; set; }
        public bool? verif { get; set; }
        public bool? amal { get; set; }
        public bool? rep { get; set; }
        public bool? xfer { get; set; }
        public DateTime? verif_dt { get; set; }
        public DateTime? amal_dt { get; set; }
        public DateTime? repl_dt { get; set; }
        public DateTime? xfer_dt { get; set; }
        public bool? unclaim { get; set; }
        public int? oldcert_numb { get; set; }
        public string xfer_no { get; set; }
        public string who { get; set; }
        public short? reg_orig { get; set; }
        public DateTime? crat_dt { get; set; }
        public string chg_who { get; set; }
        public DateTime? chg_dt { get; set; }
        public string narr { get; set; }
        public string storage_no { get; set; }
        public int? oldtrans_numb { get; set; }
        public string desc_trans { get; set; }
        public string oldcertnumb { get; set; }
        public short? moder { get; set; }
        public int? clearing { get; set; }
        public int? solid_acct { get; set; }
        public string groupr { get; set; }
        public DateTime? claim_dt { get; set; }
        public DateTime? dt_reissue { get; set; }
        public string claimedby { get; set; }
        public int? consolid_Id { get; set; }
        public bool? claimed { get; set; }
        public bool? stop { get; set; }
        public string stop_narr { get; set; }
        public string brok_verified { get; set; }
        public short? category { get; set; }
        public string annotate { get; set; }
        public string category_desc { get; set; }
        public bool? investement_type { get; set; }
        public int? auto1 { get; set; }
        public int auto { get; set; }
        public bool? lodge { get; set; }
        public DateTime? lodge_dt { get; set; }
        public int? lodge_cntr { get; set; }
        public DateTime? createdt { get; set; }
        public bool? bond { get; set; }
        public string main { get; set; }
	}
}
