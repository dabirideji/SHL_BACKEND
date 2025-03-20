using Azure.Core;
using CsvHelper;
using ExcelDataReader;
using SHL.Application.IServices;
using SHL.Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Infrastructure.Services
{
    public class ExcelProcessor : IExcelProcessor
    {
        public List<OfferExcelModel> ReadOfferFromExcel(Stream file)
        {
            var offers = new List<OfferExcelModel>();
            using (var reader = ExcelReaderFactory.CreateReader(file))
            {
                var result = reader.AsDataSet();
                DataTable table = result.Tables[0];
                var rows = table.Rows;
                for (int i = 1; i < rows.Count; i++)
                {
                    var row = rows[i];
                    var id = row[2]?.ToString();
                    var email = row[3]?.ToString();
                    var name = row[4]?.ToString();
                    var grade = row[5]?.ToString();
                    var division = row[6]?.ToString();
                    var unitAllocated = row[7]?.ToString();
                    var dateIssued = row[8]?.ToString();
                    var vestingDate = row[9]?.ToString();
                    if (!string.IsNullOrEmpty(email))
                    {
                        offers.Add(new OfferExcelModel
                        {
                            DateIssued = dateIssued,
                            Division = division,
                            Email = email,
                            Grade = grade,
                            Name = name,
                            AllocatedUnits = unitAllocated,
                            UniqueId = id,
                            VestingDate = vestingDate
                        });
                    }

                }
                return offers;
            }
        }

        public List<VestedShareRequestExcelModel> ReadVestedShareRequestFromExcel(Stream file)
        {
            var shares = new List<VestedShareRequestExcelModel>();
            using (var reader = ExcelReaderFactory.CreateReader(file))
            {
                var result = reader.AsDataSet();
                DataTable table = result.Tables[0];
                var rows = table.Rows;
                for (int i = 1; i < rows.Count; i++)
                {
                    var row = rows[i];
                    var refnumber = row[0]?.ToString();
                    var email = row[1]?.ToString();
                    var name = row[2]?.ToString();
                    var amount = row[3]?.ToString();

                    if (!string.IsNullOrEmpty(email))
                    {
                        shares.Add(new VestedShareRequestExcelModel
                        {
                            EmailAddress = email,
                            FullName = name ?? "",
                            ReferenceNumber = refnumber ?? "",
                            TransferRequestValue = decimal.Parse(amount ?? "0")
                        });
                    }
                }
                return shares;
            }
        }

        public List<BulkCreateEmployeeModel> ReadBulkEmployeeFromExcel(Stream file, Guid companyId)
        {
            var shares = new List<BulkCreateEmployeeModel>();
            using (var reader = ExcelReaderFactory.CreateReader(file))
            {
                var result = reader.AsDataSet();
                DataTable table = result.Tables[0];
                var rows = table.Rows;
                for (int i = 1; i < rows.Count; i++)
                {
                    var row = rows[i];
                    var employeeId = row[0]?.ToString();
                    var email = row[1]?.ToString();
                    var firstName = row[2]?.ToString();
                    var lastName = row[3]?.ToString();
                    var department = row[4]?.ToString();
                    var grade = row[5]?.ToString();
                    var employmentDate = row[6]?.ToString();
                    var designation = row[7]?.ToString();
                    var phoneNumber = row[8]?.ToString();

                    if (!string.IsNullOrEmpty(email))
                    {
                        shares.Add(new BulkCreateEmployeeModel
                        {
                            Department = department ?? "",
                            Designation = designation,
                            EmailAddress = email ?? "",
                            EmployeeId = employeeId,
                            EmploymentDate = employmentDate,
                            FirstName = firstName ?? "",
                            Grade = grade,
                            LastName = lastName ?? "",
                            PhoneNumber = phoneNumber ?? "",
                            CompanyId = companyId
                        });
                    }
                }
                return shares;
            }
        }

        public async Task<byte[]> ConvertToCsv<T>(IEnumerable<T> records)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                await csv.WriteRecordsAsync(records);
                writer.Flush();
                stream.Position = 0;
                return stream.ToArray();
            }

        }
    }
}
