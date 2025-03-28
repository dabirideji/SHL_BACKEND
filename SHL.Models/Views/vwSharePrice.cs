using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwSharePrice
    {
        public long Id { get; set; }
        public string Symbol { get; set; }
        public int RegCode { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal PreviousPrice { get; set; }
        public DateTime TradeDate { get; set; }
        public string CompanyName { get; set; }
        public long TotalUnits { get; set; }
    }
}
