using SHL.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.IServices
{
   public interface IExcelProcessor
    {
        List<OfferExcelModel> ReadOfferFromExcel(Stream file);
        List<VestedShareRequestExcelModel> ReadVestedShareRequestFromExcel(Stream file);
        List<BulkCreateEmployeeModel> ReadBulkEmployeeFromExcel(Stream file, Guid companyId);
        Task<byte[]> ConvertToCsv<T>(IEnumerable<T> records);
    }
}
