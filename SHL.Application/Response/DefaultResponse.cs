namespace SHL.Application.Response
{
    public class DefaultResponse<T>
    {
        public bool Status { get; set; }
        public String ResponseCode { get; set; }
        public String ResponseMessage { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; }

        public static DefaultResponse<T> SuccessMessage(string message = "", dynamic data = null, bool status = true)
        {
            return new DefaultResponse<T>
            {
                Data = (T)data,
                ResponseMessage = string.IsNullOrWhiteSpace(message) ? "Successful" : message,
                Status = status,
            };
        }

        public static DefaultResponse<T> ErrorMessage(string message = "", List<string> errors = null)
        {
            message = string.IsNullOrWhiteSpace(message) ? "An error occurred while processing your request. Please try again later" : message;
            errors ??= [];
            if (errors.Count == 0) errors.Add(message);
            return new DefaultResponse<T>
            {
                ResponseMessage = string.IsNullOrWhiteSpace(message) ? "An error occurred while processing your request. Please try again later" : message,
                Status = false,
                Errors = errors
            };
        }
    }
}
