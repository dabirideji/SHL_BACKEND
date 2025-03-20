namespace SHL.Application.Response
{
    public static class AutoDefaultResponse<T>
    {
        public static DefaultResponse<T> FailResponse(string? failureMessage, string? failCode = "99")
        {
            return new DefaultResponse<T>
            {
                Status = false,
                ResponseCode = failCode,
                ResponseMessage = failureMessage,
            };
        }
        public static DefaultResponse<T> SuccessResponse(string successMessage, T? responseData)
        {
            return new DefaultResponse<T>
            {
                Status = true,
                ResponseCode = "00",
                ResponseMessage = successMessage,
                Data = responseData
            };
        }
        public static DefaultResponse<T> BadRequestResponse(string failureMessage, string failCode = "44")
        {
            return new DefaultResponse<T>
            {
                Status = false,
                ResponseCode = failCode,
                ResponseMessage = failureMessage,
            };
        }
    }
}
