namespace SHL.Application.DTO.Token.Request
{
    public class TokenGenerationDto
    {
        public string? Name { get; set;}
        public string? EmailAddress { get; set;}
        public string? CompanyCode { get; set;}
        public string? CompanyName { get; set;}
        public string? CompanyId { get; set;}
        public string? UserName { get; set;}
        public string? UserType { get; set;}
        public string? Permission { get; set;}
    }
}