namespace SHL.Domain.Models
{
    public class AuditLog : BaseEntity
    {
        public LogType? LogType { get; set; }
        public string? LogBody { get; set; }
        public string? LogInitiator { get; set; }
        public string? LogAction { get; set; }
        public string? LogPayload { get; set; }
        public string? LogResponse { get; set; }
        public string? LogEndpoint { get; set; }
        public string? LogServerInformation { get; set; }

    }
}