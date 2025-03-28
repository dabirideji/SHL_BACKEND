using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.ReferenceLetter
{
    public class RefLetterRequest
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Destination { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? BuildingNumber { get; set; }
        public string? StreetName { get; set; }
        public string? Email { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsSent { get; set; }
        public string? PaymentRef { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DateModified { get; set; }
        public string? Source { get; set; }
    }
}
