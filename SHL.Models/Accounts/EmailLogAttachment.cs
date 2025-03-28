using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSL.Models.Accounts
{

    public class EmailLogAttachment : MailAttachment
    {
        public long ID { get; set; }
        public long EmailLogID { get; set; }

        public virtual EmailLog EmailLog { get; set; }

        public string FolderOnServer { get; set; }

        public string FileNameOnServer { get; set; }

        public string EmailFileName { get; set; }

        public DateTime DateCreated { get; set; }

    }

    public class MailAttachment
    {
        /// <summary>
        /// Attached file_name
        /// </summary>
        [NotMapped]
        public string Filename { get; set; }

        /// <summary>
        /// Attached file content-type
        /// </summary>
        [NotMapped]
        public string Mimetype { get; set; }

        /// <summary>
        /// Attached file in Base64 string
        /// </summary>
        [NotMapped]
        public string Attachment { get; set; }
    }
}
