using CSL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Models.DTO
{

    public class BulkUploadSearchParams
    {
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string SearchText { get; set; }
    }


    public class ApiResult<T>
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public T data { get; set; }
        public string draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
        public int TotalCount { get; set; }
    }

    public class WebResponse
    {
        public string draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public T data { get; set; }
        public int TotalCount { get; set; }
        //public int TotalCount => Helper.GetCount(data).GetValueOrDefault();
    }

    public class MessageOut
    {
        public long RetId { get; set; }
        public string TxnReference { get; set; }
        public string otp { get; set; }
        public string Message { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsFirstTimeLogin => LastLogin == null;
        public bool IsSuccessful { get; set; }
        public object data { get; set; }
        public long CompanyId { get; set; }
        public string PhoneNo { get; set; }
    }

    public class IdNameObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NameValueObj
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class IdTextObj
    {
        public int coy_no { get; set; }
        public int acctno { get; set; }
        public string coy_name { get; set; }
    }

    public class SearchModel
    {
        public long Id { get; set; }
        public string searchType { get; set; }
        public string searchText { get; set; }
        public int pageSize { get; set; } = DefaultValueMaps.pageSize;
        public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
    }

    public class QueryOption
    {
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string SearchText { get; set; }
        public int pageSize { get; set; } = DefaultValueMaps.pageSize;
        public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
        public string draw { get; set; }
        public string start { get; set; }
        public string length { get; set; }
        public Dictionary<string, string> search { get; set; }
    }

    public class Query_Option
    {
        public string email { get; set; }
        public int companyId { get; set; } = 0;
        public int trans_type { get; set; } = 2;
    }

    public class QueryParam
    {
        public string email { get; set; }
        public int companyId { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
    }

    public class QueryOptions
    {
        public QueryOptions()
        {
            pageSize = start_date.GetValueOrDefault() == default || end_date.GetValueOrDefault() == default
                ? pageSize > 0 ? pageSize : 0
                : DefaultValueMaps.pageSize;
        }


        public int companyId { get; set; } = 0;
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string SearchText { get; set; }
        public int pageSize { get; set; } //= DefaultValueMaps.pageSize;
        public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
        public string draw { get; set; }
        public string start { get; set; }
        public string length { get; set; }
        public Dictionary<string, string> search { get; set; } 
    }

    public class ExportParams
    {
        public int exportType { get; set; }
        public string fileType { get; set; }
        public int companyId { get; set; }
        public int acctno { get; set; }
    }

    public class SearchParams
    {
        public int companyId { get; set; } 
        public int groupByCompany { get; set; } = 0;
        public int acctno { get; set; }
        public int trans_type { get; set; } = 2;
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string SearchText { get; set; }
        public int pageSize { get; set; } = DefaultValueMaps.pageSize;
        public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
    }


    public class QueryParams
    {
        /// <summary>
        /// For sequential returns from server-side processing requests
        /// </summary>
        public int draw { get; set; }

        /// <summary>
        /// For Page No. (start point in the current data set (0 index based - i.e. 0 is the first record).
        /// This means that plus (+1) should always be done at the backend
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// Number of records that the table can display in the current draw. (i.e. pageSize at the backend)
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// Global search value. To be applied to all columns which have searchable as true.
        /// </summary>
        public Dictionary<string, string> search { get; set; }
       
    }


    public class TransQueryOptions : QueryParams
    {
        //public string draw { get; set; }
        //public string start { get; set; }
        //public string length { get; set; }
        //public Dictionary<string, string> search { get; set; }
        public int acctno { get; set; }
        public int companyId { get; set; } = 0;
        public int trans_type { get; set; } = 2;
        public string SearchText { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public int pageSize { get; set; } 
        public int pageNumber { get; set; } 
        //public int pageSize { get; set; } = DefaultValueMaps.pageSize;
        //public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
    }
    
    public class MessageQueryOptions
    {
        public string draw { get; set; }
        public string start { get; set; }
        public string length { get; set; }
        public Dictionary<string, string> search { get; set; }
        public string SearchText { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public int pageSize { get; set; } = DefaultValueMaps.pageSize;
        public int pageNumber { get; set; } = DefaultValueMaps.pageNumber;
    }

    public class MessageQueryParams
    {
        public string SearchText { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
    }

    public class Query_Params : QueryParams
    {
        public string SearchText { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
    }

    public class DefaultValueMaps
    {
        public const int pageSize = 10;
        public const int pageNumber = 1;
        public const int StartCount = 1;
    }

    public class Holding_vw
    {
        public string label { get; set; }
        public decimal data { get; set; }
        public decimal price { get; set; }
        public long regCode { get; set; }
        public decimal marketvalue { get; set; }
    }

    public class ShareholderHoldingViewObj
    {
        public string label { get; set; }
        public decimal data { get; set; }
        public decimal price { get; set; }
        public long regCode { get; set; }
        public decimal marketvalue { get; set; }
    }

    public class HoldingExempted_vw
   {
       public string CompName { get; set; }
       public double Unit { get; set; }
       public double Price { get; set; }
       public double MarketValue { get; set; }
   }

}
