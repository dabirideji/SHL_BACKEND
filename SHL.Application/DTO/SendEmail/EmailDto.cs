namespace CSL.Application.Utils.DTO
{

    #region Reminder Mail:


    public class ShareholderSubRenewDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string SubscriptionPlan { get; set; }
        public decimal SubscriptionPlanAmount { get; set; }
        public DateTime SubscriptionExpiryDate { get; set; }
    }


    #endregion



    public class VerifyInviteDTO
    {
        public int CompanyId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public int auto { get; set; }
        public string Body { get; set; }
        public string EmailTo { get; set; }
        public bool Email_Verified { get; set; }
        public string URL { get; set; }
        public string Phone_no { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string state_code { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
        public string Holder_type { get; set; }
        public string BVN { get; set; }
        public string NIN { get; set; }
        public string TIN { get; set; }
        public int acctno { get; set; }
        public string chn { get; set; }
        public string RC_No { get; set; }
        public string Token { get; set; }
        public bool IsSent { get; set; }
    }

  
    public class ShareholderProfileDTO
    {
        public ShareholderProfileDTO()
        {
            SharesData = new List<SharesDTO>();
        }
        //public int RegistrarId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string BVN { get; set; }
        public string NIN { get; set; }
        public List<SharesDTO> SharesData { get; set; }
    }

    public class SharesDTO
    {
        public string CompanyName { get; set; }
        public decimal TotalShares { get; set; }
        public string? RegCode { get; set; }
        public string? AcctNo { get; set; }
    }

    public class DripSharesDTO : SharesDTO
    {
        public string ClearingHouseNumber { get; set; } = "";
        public string IsActive { get; set; } = "";
        public bool? IsAccepted { get; set; } = false;
        public DateTime? DividendReinvestmentDate { get; set; }
        public bool IsReinvestable =>
            DividendReinvestmentDate.HasValue &&
            DividendReinvestmentDate.Value.Date <= DateTime.UtcNow.Date &&
            DividendReinvestmentDate.Value.Date >= DateTime.UtcNow.Date.AddDays(-3);

        public bool IsCancellable =>
            DividendReinvestmentDate.HasValue &&
            DividendReinvestmentDate.Value.Date <= DateTime.UtcNow.Date &&
            DividendReinvestmentDate.Value.Date >= DateTime.UtcNow.Date.AddDays(-15);
    }

    public class AggregateDTO
    {
        public decimal total_units { get; set; }
    }

    public class TxnExportNotificationObj
    {
        public string FullName { get; set; }
        public string EmailTo { get; set; }
        public string TxnType { get; set; }
    }

    public class OTPAlertDto
    {
        public string Otp { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Type { get; set; } 
    }

    public class GeneralAlertDTO
    {
        public string FullName { get; set; }
        public string Body { get; set; }
        public string EmailTo { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string CC { get; set; }
        public string URL { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
    }
    public class EmailLogViewModel
    {
        public EmailLogViewModel()
        {
            attachmentModelCol = Enumerable.Empty<EmailLogAttachementViewModel>().ToList();
        }

        public long ID { get; set; }
        public string Receiver { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public string MessageBodyWithoutHeaderFooter { get; set; }

        public bool HasAttachment { get; set; }
        public bool IsSent { get; set; }
        public int Retires { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateToSend { get; set; }

        public List<EmailLogAttachementViewModel> attachmentModelCol { get; set; }
        public int CompanyID { get; set; }
    }

    public class EmailLogAttachementViewModel : MailAttachment
    {

        public string FolderOnServer { get; set; }
        public string FileNameOnServer { get; set; }
        public string EmailFileName { get; set; }

    }

    public class MailAttachment
    {
        /// <summary>
        /// Attached file_name
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Attached file content-type
        /// </summary>
        public string Mimetype { get; set; }

        /// <summary>
        /// Attached file in Base64 string
        /// </summary>
        public string Attachment { get; set; }
    }

    public class EmailTokenViewModel
    {
        public string Token { get; set; }
        public string TokenValue { get; set; }
    }


}
