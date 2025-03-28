using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwTprice
    {
        public int register_code { get; set; }
        public decimal? Price { get; set; }
        public int auto_num { get; set; }
        public string symbol { get; set; }
        public string csi { get; set; }
        public string asset { get; set; }
        public decimal? open { get; set; }
        public decimal? high { get; set; }
        public decimal? low { get; set; }
        public decimal? volume { get; set; }
        public decimal? value { get; set; }
        public DateTime? tradedate { get; set; }
        public DateTime? exact_tradedate { get; set; }
        public DateTime? createdate { get; set; }
        public string nse_symbol { get; set; }
	}
}
