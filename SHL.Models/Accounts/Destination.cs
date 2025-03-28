using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class Destination :  BaseModel
    {
        public string Name { get; set; }

        /// <summary>
        /// Represent different kinds of Destination such as; Embassy, Commercial banks & Others Financial Inst.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Represent something like Country-Code
        /// </summary>
        public string Code { get; set; } 
    }
}
