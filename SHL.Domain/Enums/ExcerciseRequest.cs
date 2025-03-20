using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Enums
{
    public enum ExcerciseRequest
    {
        Requested = 1,
        Approved,
        Paid,
        Processed,
        SendToBroker,
        Declined
    }
}
