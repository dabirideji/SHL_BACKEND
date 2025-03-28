using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Campaign
{
    
    public class AccessRightLog
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public bool Status { get; set; }
        public DateTime? LogDate { get; set; }
        public string? Name { get; set; }
    }
}
