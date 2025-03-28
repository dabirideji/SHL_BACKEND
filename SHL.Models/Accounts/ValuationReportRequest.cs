using System;
using System.Collections.Generic;
using System.Text;
using CSL.Models.Utils;

namespace CSL.Models.Accounts
{
    public class ValuationReportRequest
    {
        public ValuationReportRequest()
        {
            DateRequested = DateTime.Now;
        }

        public long Id { get; set; }

        /// <summary>
        /// Ticket No. generated for the statement return from GenerateStatement Api 
        /// </summary>
        public string TicketNumber { get; set; }
        public string AccountNo { get; set; }

        /// <summary>
        /// Amount for the service return from GenerateStatement Api 
        /// </summary>
        public decimal Amount { get; set; }
        public int CompanyId { get; set; }
        public int DestinationId { get; set; }
        public string ApplicantName { get; set; }
        public string VisaApplicationNumber { get; set; }
        /// <summary>
        /// For the value for (Applicant, Sponsor, Guarantor)
        /// </summary>
        public int StatementRoleId { get; set; }

        public int PurposeId { get; set; }
        /// <summary>
        /// No of pages in the statement generated return from GenerateStatement Api 
        /// </summary>
        public int NoOfPages { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime? DateModified { get; set; }
        public string SentTo { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string Recipient { get; set; }

        public bool? IsSent { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime? DatePaid { get; set; }
        public string PaymentRef { get; set; }

    }
}
