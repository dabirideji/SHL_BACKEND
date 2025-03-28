using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwShareAccountDetail
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public short RegCode { get; set; }
        public string CustomerNo { get; set; }
        public string PadRegCode { get; set; }
        public string AccountNo { get; set; }
	}
}
