using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Views
{
    public class vwT_reg_name
    {
        public int coy_no { get; set; }
        public string rc_num { get; set; }
        public string coy_name { get; set; }
        public string coy_addr { get; set; }
        public string coy_phone { get; set; }
        public string coy_fax { get; set; }
        public string coy_email { get; set; }
        public DateTime incop_dt { get; set; }
        public DateTime list_dt { get; set; }
        public string coy_type { get; set; }
        public double auth_sh { get; set; }
        public string who { get; set; }
        public DateTime enterd_dt { get; set; }
        public string chg_who { get; set; }
        public DateTime chg_dt { get; set; }
        public string website { get; set; }
	}
}
