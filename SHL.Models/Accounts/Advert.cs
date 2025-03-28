using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class Advert
    {
        public Advert()
        {
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public long Id { get; set; }

        /// <summary>
        /// Represent the Title or like a tips to reference the Advert posted.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Represent the Url/Link to the exact Advert site when clicked on.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Represent the Advert Image filename save to folder on the server.
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        /// Represent the Advert Image File location on the server.
        /// </summary>
        public string ImageServerFileLocation { get; set; }

        /// <summary>
        /// Represent the toogle to turn On/Off the Advert for showing up on the page. 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Represent the Email of the User who created the Ads.
        /// </summary>
        public string CreatedBy { get; set; }       
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Represent the Email of the last User modified the Ads.
        /// </summary>
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

    }
}
