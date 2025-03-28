using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Views
{
    public class vwShareHolders
    {
		public int Acctno { get; set; }
		public short? regcode { get; set; }
		public string agent { get; set; }
		public string title { get; set; }
		public string last_nm { get; set; }
		public string first_nm { get; set; }
		public string middle_nm { get; set; }
		public string sex { get; set; }
		public DateTime? dob { get; set; }
		public string addr1 { get; set; }
		public string addr2 { get; set; }
		public string addr3 { get; set; }
		public string st { get; set; }
		public string orig_st { get; set; }
		public string typer { get; set; }
		public string phone { get; set; }
		public string fax { get; set; }
		public string email { get; set; }
		public string mobile { get; set; }
		public int? offer_no { get; set; }
		public bool? sbrok { get; set; }
		public string who { get; set; }
		public string narr { get; set; }
		public string oldaccountno { get; set; }
		public string chn { get; set; }
		public string maiden { get; set; }
		public int? active { get; set; }
		public string mand_acct { get; set; }
		public byte? status1 { get; set; }
		public int? status { get; set; }
		public byte? keep { get; set; }
		public string narration1 { get; set; }
		public string chn_acct { get; set; }
		public string nextofkin { get; set; }
		public string deceased { get; set; }
		public int? consolid_id { get; set; }
		public int? occupation_code { get; set; }
		public byte? extract_bonus { get; set; }
		public string caution_ref { get; set; }
		public int? fbn_code { get; set; }
		public string bighold_branch { get; set; }
		public bool? reinvest { get; set; }
		public string e_account_no { get; set; }
		public int? auto1 { get; set; }
		public int? state_code { get; set; }
		public int? post_office_code { get; set; }
		public int? address_status { get; set; }
		public int? auto { get; set; }
		public string chn_member { get; set; }
		public bool? gsm_enabled { get; set; }
		public DateTime? gsm_subs_dt { get; set; }
		public bool? gsm_subs_warn { get; set; }
		public bool? nibbs_verif { get; set; }
		public int? gsm_subs_life { get; set; }
		public bool? gsm_subs_warn2 { get; set; }
		public bool? gsm_subs_warn3 { get; set; }
		public int? e_repo { get; set; }
		public bool? div_loc { get; set; }
		public bool? div_conv_cert { get; set; }
		public string divcard { get; set; }
		public DateTime? divcard_ed { get; set; }
		public string bvn { get; set; }
		public bool? cp { get; set; }
		public string cp_cd { get; set; }
		public DateTime? caution_dt { get; set; }
		public bool? email_verif { get; set; }
		public bool? spec_tax_rt { get; set; }
		public double? spec_tax_rate { get; set; }
		public int? gvn { get; set; }
		public string curr_code { get; set; }
	}
}
