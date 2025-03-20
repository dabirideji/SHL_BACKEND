using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Enums
{
    public enum VestesShareTransfer
    {
        PendingApproval= 1,
        Approve,
        Processed,
        SentToBroker,
        Declined
    }
}
