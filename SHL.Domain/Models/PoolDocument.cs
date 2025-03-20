using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class PoolDocument : BaseEntity
    {
        [ForeignKey("OfferPool")]
        public Guid? OfferPoolId { get; set; }
        public OptionPool? OfferPool { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentTitle { get; set; }
        public string? DocumentBody { get; set; }
        public string? DocumentFilePath { get;set;}
        public Status? Status { get; set; } = Categories.Status.ACTIVE;
    }
}