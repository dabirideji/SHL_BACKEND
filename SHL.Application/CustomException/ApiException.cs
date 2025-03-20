namespace SHL.Application.CustomExceptions
{
    public class ApiException : Exception
    {
        public int ErrorCode { get; }
        public object AdditionalData { get; }

        private ApiException(string message, int errorCode, object additionalData)
            : base(message)
        {
            ErrorCode = errorCode;
            AdditionalData = additionalData;
        }

        public static void ClientError(string message, int errorCode = 400, object additionalData = null)
        {
            throw new ApiException(message.ToUpper(), errorCode, additionalData);
        }

        public static void ServerError(string message, int errorCode = 99, object additionalData = null)
        {
            throw new ApiException(message.ToUpper(), errorCode, additionalData);
        }
    }
}

