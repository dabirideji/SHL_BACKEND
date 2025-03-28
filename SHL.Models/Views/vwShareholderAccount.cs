using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwShareholderAccount
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone_no { get; set; }
        public string bvn { get; set; }
        public DateTime? dob { get; set; }
        public int? Acctno { get; set; }
        public int? CompanyId { get; set; }
        public short? CompanyRegCode { get; set; }
        public string CompanyName { get; set; }
        public string SecType { get; set; }
        public bool? IsActive { get; set; }
        public string CustomerNo { get; set; }
        public string PadRegCode { get; set; }
        public string AccountNo { get; set; }
        public string Nuban { get; set; }
        public string AccountName { get; set; }
        public string CompanyStockCode { get; set; }

        public string Sex { get; set; }
        public string Title { get; set; }
        public string ResidentialAddress { get; set; }
        //public decimal NetAmount { get; set; }
        //public bool IsClaimed { get; set; }

    }
}
