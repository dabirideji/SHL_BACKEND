using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSL.Models.Enums
{
    public enum ReadStatus
    {
        [Description("None")]
        [Display(Name = "None")]
        None,

        [Description("Read")]
        [Display(Name = "Read")]
        Read,

        [Description("Un-Read")]
        [Display(Name = "Un-Read")]
        UnRead
    }

    public enum MessageStatus
    {

        Pending = 1,
        Read = 2

        //[Description("None")]
        //None = 0,

        //[Description("Inbox")]
        //Inbox = 1,

        //[Description("Sent")]
        //Sent = 2,

        //[Description("Draft")]
        //Draft = 3,

        //[Description("Trash")]
        //Trash = 4
    }
}
