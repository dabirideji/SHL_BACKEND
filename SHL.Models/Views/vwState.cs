using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Views
{
    public class vwState
    {
        public int auto_num { get; set; }
        public int? zonecd { get; set; }
        public DateTime? createdate { get; set; }
        public string enteredby { get; set; }
        public string state_name { get; set; }
        public string state_code { get; set; }

    }
}
