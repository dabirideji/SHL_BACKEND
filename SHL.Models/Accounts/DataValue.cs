using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class DataValue
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string InputName { get; set; }
        public string InputValue { get; set; }
        public string Sequence { get; set; }
        public bool? IsUsed { get; set; }
        public string OnboardStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string CreatedBy { get; set; }
    }
}
