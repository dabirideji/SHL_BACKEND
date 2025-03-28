using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Campaign
{
    public class Campaign
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? LinkUrl { get; set; }
        public bool Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
