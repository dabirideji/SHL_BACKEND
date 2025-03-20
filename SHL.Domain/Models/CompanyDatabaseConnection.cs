namespace SHL.Domain.Models
{
    public class CompanyDatabaseConnection : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public DatabaseType? DatabaseType { get; set; }
        public DatabaseStatus? DatabaseStatus { get; set; }
        public string? DatabaseConnectionString { get; set; }
    }
}