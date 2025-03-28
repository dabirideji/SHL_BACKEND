using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Cosec
{
    public class CosecUser
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool Consent { get; set; }
    }
}
