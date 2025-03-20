using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Enums
{
    public enum EquityType
    {
        [Description("Restricted Stock Units")]
        Rsu = 1,

        Options
    }
}
