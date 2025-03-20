namespace SHL.Application.Response
{
    public class DefaultResponse<T>
    {
        public bool Status { get; set; }
        public String ResponseCode { get; set; }
        public String ResponseMessage { get; set; }
        public T? Data { get; set; }
    }
}
