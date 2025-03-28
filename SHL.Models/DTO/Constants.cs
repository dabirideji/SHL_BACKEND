using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.DTO.Constants
{
    public class SearchType
    {
        public const string AccountCode = "Account Code";
        public const string LastName = "Last Name";
        public const string FirstName = "First Name";
        public const string OtherName = "Other Name";
        public const string FullName = "Full Name";
        public const string Email = "Email Address";
        public const string Phone = "Phone Number";
        public const string BVN = "BVN";
    }

    public class AuditLogType
    {
        public const string Save = "Save";
        public const string Update = "Update"; 
    }

    public class EventLogType
    {
        public const string Information = "Information";
        public const string Warning = "Warning";
        public const string Reminder = "Reminder";
        public const string Critical = "Critical"; 
        public const string Dividend = "Dividend";
        public const string Subscription = "Subscription";
        public const string Redemption = "Redemption";
    }
}
