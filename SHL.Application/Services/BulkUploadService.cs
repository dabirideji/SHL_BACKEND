// using ExcelDataReader;
// using Hangfire;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using SHL.Application.CustomExceptions;
// using SHL.Application.DTO.Company.Request;
// using SHL.Application.Interfaces;
// using SHL.Application.Interfaces.GenericRepositoryPattern;
// using SHL.Domain.Models;

// namespace SHL.Application.Services
// {
//     public class BulkUploadService : IBulkUploadService
//     {
//         private readonly IUnitOfWork _unitOfWork;

//         public BulkUploadService(IUnitOfWork unitOfWork)
//         {
//             _unitOfWork = unitOfWork;
//         }

//         public async Task<object> UploadFile(Guid CompanyId,IFormFile file)
//         {
//             try
//             {
//                 if (file == null || file.Length == 0)
//                 {
//                     ApiException.ClientError("File is not selected or empty.");
//                 }
//                 const long maxFileSize = 500 * 1024 * 1024; // 500MB
//                 if (file.Length > maxFileSize)
//                 {
//                     ApiException.ClientError("File size exceeds the 500MB limit.");
//                 }

//                 var tempFilePath = Path.Combine(Path.GetTempPath(), file.FileName);
//                 using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
//                 {
//                     await file.CopyToAsync(fileStream);
//                 }

//                 var shareholders = await ExtractShareholdersFromExcelAsync(tempFilePath);
//                 var totalHoldings =shareholders.Sum(x=>Convert.ToDecimal(x.ShareholderHolding));
//                 var _companyRepo=_unitOfWork.GetRepository<Company>();

//                 var company=await _companyRepo.GetByIdAsync(CompanyId);
//                 if(company==null)
//                 {
//                     ApiException.ClientError("INVALID COMPANY ID");
//                 }
//                 company.CompanyTotalShareAmount+=(double)totalHoldings;
//                 await _companyRepo.UpdateAsync(company);
//                 // Queue background job to process the shareholders
//                 QueueBackgroundJob(shareholders);

//                 System.IO.File.Delete(tempFilePath);

//                 return new { Message = "File uploaded successfully. Processing will continue in the background." };
//             }
//             catch (Exception ex)
//             {
//                 ApiException.ServerError(ex.Message, 99);
//             }
//             return null;
//         }

//         private async Task<List<CreateShareholderDto>> ExtractShareholdersFromExcelAsync(string filePath)
//         {
//             var shareholders = new List<CreateShareholderDto>();

//             await foreach (var row in StreamExcelRowsAsync(filePath))
//             {
//                 shareholders.Add(new CreateShareholderDto
//                 {
//                     CompanyCode = row.GetValueOrDefault("Company"),
//                     CompanyName = row.GetValueOrDefault("Company"),
//                     ShareholderNumber = row.GetValueOrDefault("ShareholderNum"),
//                     ShareholderName = row.GetValueOrDefault("Name"),
//                     ShareholderAddress = row.GetValueOrDefault("Address"),
//                     ShareholderHolding= row.GetValueOrDefault("Holding"),
//                     ShareholderEmailAddress = row.GetValueOrDefault("emailAddress"),
//                     ShareholderPhoneNumber = row.GetValueOrDefault("PhoneNumber")
//                 });
//             }

//             return shareholders;
//         }

//         private void QueueBackgroundJob(List<CreateShareholderDto> shareholders)
//         {
//             // Example: Using Hangfire for queuing
//             BackgroundJob.Enqueue<IShareholderService>(service =>
//                 service.AddRangeAsync(shareholders));
//         }

//         private async Task<object> ProcessExcelFileAsync(string filePath)
//         {
//             var sampleRows = new List<Dictionary<string, string>>();
//             int sampleSize = 10;
//             int totalRowCount = 0;
//             await foreach (var rowData in StreamExcelRowsAsync(filePath))
//             {
//                 CollectSampleRows(sampleRows, rowData, sampleSize, totalRowCount);
//                 totalRowCount++;
//             }
//             return new
//             {
//                 Message = "File processed successfully.",
//                 TotalRows = totalRowCount,
//                 RandomSample = sampleRows
//             };
//         }

//         private async IAsyncEnumerable<Dictionary<string, string>> StreamExcelRowsAsync(string filePath)
//         {
//             using (var stream = System.IO.File.OpenRead(filePath))
//             using (var reader = ExcelReaderFactory.CreateReader(stream))
//             {
//                 bool isHeaderRow = true;
//                 string[] headers = null;

//                 while (reader.Read())
//                 {
//                     if (isHeaderRow)
//                     {
//                         headers = new string[reader.FieldCount];
//                         for (int i = 0; i < reader.FieldCount; i++)
//                         {
//                             headers[i] = reader.GetString(i) ?? $"Column{i}";
//                         }
//                         isHeaderRow = false;
//                         continue;
//                     }

//                     var rowData = new Dictionary<string, string>();
//                     for (int i = 0; i < reader.FieldCount; i++)
//                     {
//                         string header = headers[i];
//                         rowData[header] = reader.GetValue(i)?.ToString() ?? string.Empty;
//                     }

//                     yield return rowData;
//                     await Task.Yield();
//                 }
//             }
//         }

//         private void CollectSampleRows(
//             List<Dictionary<string, string>> sampleRows,
//             Dictionary<string, string> currentRow,
//             int sampleSize,
//             int totalRowCount)
//         {
//             if (sampleRows.Count < sampleSize)
//             {
//                 sampleRows.Add(currentRow);
//             }
//             else
//             {
//                 int randomIndex = new Random().Next(0, totalRowCount);
//                 if (randomIndex < sampleSize)
//                 {
//                     sampleRows[randomIndex] = currentRow;
//                 }
//             }
//         }
//     }
// }




















using AutoMapper;
using ExcelDataReader;
using Hangfire;
using Microsoft.AspNetCore.Http;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;
using System.Collections.Concurrent;

namespace SHL.Application.Services
{
    public class BulkUploadService : IBulkUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BulkUploadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<object> UploadFile(Guid CompanyId, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    ApiException.ClientError("File is not selected or empty.");

                const long maxFileSize = 500L * 1024 * 1024; // 500MB
                if (file.Length > maxFileSize)
                    ApiException.ClientError("File size exceeds the 500MB limit.");

                string tempFilePath = Path.Combine(Path.GetTempPath(), file.FileName);
                using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Trigger background job for processing
                BackgroundJob.Enqueue(() => ProcessExcelInBackground(tempFilePath, CompanyId));

                return new { Message = "File uploaded successfully. Processing in the background." };
            }
            catch (Exception ex)
            {
                ApiException.ServerError(ex.Message, 99);
            }
            return null;
        }

        public async Task ProcessExcelInBackground(string filePath, Guid CompanyId)
        {
            //try
            //{
            //    var _companyRepo = _unitOfWork.GetRepository<Company>();
            //    var _shareholderRepo = _unitOfWork.GetRepository<Shareholder>();

            //    var company = await _companyRepo.GetByIdAsync(CompanyId);
            //    if (company == null)
            //        ApiException.ClientError("INVALID COMPANY ID");

            //    var shareholders = new ConcurrentBag<CreateShareholderDto>(); // Thread-safe collection

            //    decimal totalHoldings = 0;
            //    await foreach (var row in StreamExcelRowsAsync(filePath))
            //    {
            //        if (!decimal.TryParse(row.GetValueOrDefault("Holding"), out decimal holdingAmount))
            //            holdingAmount = 0;

            //        totalHoldings += holdingAmount; // Sum holdings

            //        shareholders.Add(new CreateShareholderDto
            //        {
            //            CompanyCode = row.GetValueOrDefault("Company"),
            //            CompanyName = row.GetValueOrDefault("Company"),
            //            ShareholderNumber = row.GetValueOrDefault("ShareholderNum"),
            //            ShareholderName = row.GetValueOrDefault("Name"),
            //            ShareholderAddress = row.GetValueOrDefault("Address"),
            //            ShareholderHolding = holdingAmount.ToString(),
            //            ShareholderEmailAddress = row.GetValueOrDefault("emailAddress"),
            //            ShareholderPhoneNumber = row.GetValueOrDefault("PhoneNumber")
            //        });
            //    }

            //    // **BATCH INSERT FOR HIGH PERFORMANCE**
            //    const int batchSize = 5000;
            //    var shareholderList = shareholders.ToList();
            //    var tasks = new List<Task>();

            //    for (int i = 0; i < shareholderList.Count; i += batchSize)
            //    {
            //        var batch = shareholderList.Skip(i).Take(batchSize).ToList();
            //        tasks.Add(_shareholderRepo.AddRangeAsync((_mapper.Map<List<Shareholder>>(batch))));
            //    }

            //    await Task.WhenAll(tasks); // Process all batches in parallel

            //    // Update total shares of the company
            //    company.CompanyTotalShareAmount += (double)totalHoldings;
            //    await _companyRepo.UpdateAsync(company);

            //    System.IO.File.Delete(filePath);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error processing file: {ex.Message}");
            //}
        }

        private async IAsyncEnumerable<Dictionary<string, string>> StreamExcelRowsAsync(string filePath)
        {
            using (var stream = System.IO.File.OpenRead(filePath))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                bool isHeaderRow = true;
                string[] headers = null;

                while (reader.Read())
                {
                    if (isHeaderRow)
                    {
                        headers = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            headers[i] = reader.GetString(i) ?? $"Column{i}";
                        }
                        isHeaderRow = false;
                        continue;
                    }

                    var rowData = new Dictionary<string, string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rowData[headers[i]] = reader.GetValue(i)?.ToString()?.Trim() ?? string.Empty;
                    }

                    yield return rowData;
                    await Task.Yield();
                }
            }
        }
    }
}
