using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.DTO
{

    #region Common:
    
    public class CommonResponse<T>
    {
        public static object ToCoreResponse(T source, string msg = "", string respcode = "")
        {
            if (string.IsNullOrWhiteSpace(respcode))
            {
                return new
                {
                    status = source != null,
                    message = source == null
                        ? (!string.IsNullOrWhiteSpace(msg) ? msg : "No record found")
                        : (!string.IsNullOrWhiteSpace(msg) ? msg : "Successful"),
                    data = source
                };
            }
            return new 
            {
                status = source != null,
                message = source == null
                    ? (!string.IsNullOrWhiteSpace(msg) ? msg : "No record found")
                    : (!string.IsNullOrWhiteSpace(msg) ? msg : "Successful"),
                code = respcode,
                data = source
            };
        }
    }

    public class CommonResponses<T>
    {
        public static dynamic ToCoreResponse(dynamic source, string msg = "")
        {
            return new
            {
                status = source.status,
                message = source == null
                        ? (!string.IsNullOrWhiteSpace(msg) ? msg : "Not successful")
                        : (!string.IsNullOrWhiteSpace(msg) ? msg : "Successful"),
                data = source
            };
        }
    }
     

    public class MessageResp
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static MessageResp ToCoreResponse(MessageResponse source)
        {
            return new MessageResp
            {
                status = source.status,
                code = source.code,
                message = source.message,
                data = source.data
            };
        }
    }

    public class MessagesResp
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static MessagesResp ToCoreResponse(MessageResponse source)
        {
            return new MessagesResp
            {
                status = source.status,
                code = source.code,
                message = source.message,
                data = source.data
            };
        }
    }

    public class CommonMessage<T>
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static CommonMessage<T> ToCoreResponse(bool status, string msg, T source)
        {
            return new CommonMessage<T>
            {
                status = status,
                message = msg,
                data = source
            };
        }
    }

    public class CommonMessages<T>
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static CommonMessages<T> ToCoreResponse(bool status, string msg, T source)
        {
            return new CommonMessages<T>
            {
                status = status,
                message = msg,
                data = source
            };
        }
    }

    public class MessageResponse
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }

    //public class ApiLinkDTO
    //{
    //    public string method { get; set; }
    //    public string final_url { get; set; }
    //    public string headers { get; set; }
    //    public string body { get; set; }
    //}




    #endregion

    public class ShareCoreResponse
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }

    public class ServerResponse<T>
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
