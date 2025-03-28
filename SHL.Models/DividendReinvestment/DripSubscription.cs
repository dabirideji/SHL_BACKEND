using System.Collections.Generic;
using System.Text;

namespace CSL.Models.DividendReinvestment
{
    public class DripSubscription
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string AccountNumber  { get; set; }
        public string Address { get; set; }
        public string CompanyShareHeld { get; set; }
        public string ClearingHouseNumber { get; set; }
        public string Signature1 { get; set; }
        public string Signature1Company { get; set; }
        public string Signature2 { get; set; }
        public string Signature2Company { get; set; }
    } 
}
