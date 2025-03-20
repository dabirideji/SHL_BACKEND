using SHL.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.IServices
{
   public interface IBulkEmployeeChannel: IGenericChannel<BulkCreateEmployeeModel>
    {
    }
}
