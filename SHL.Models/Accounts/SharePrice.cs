using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
	public class NgxSharePrice
    {
        public long Id { get; set; }
        public int RegCode { get; set; }
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PreviousPrice { get; set; }
        public DateTime TradeDate { get; set; }
        
    }
}
