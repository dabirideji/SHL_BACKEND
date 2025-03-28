using System;
using System.Collections.Generic;
using System.Text;
using CSL.Models.Utils;

namespace CSL.Models.Accounts
{
    public class ApiClient : BaseModel
    {
        //public ApiClient()
        //{
        //    AppSecret = SaltEncryptHelper.Encrypt(AppKey);
        //}

        public string Client { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
    }
}
