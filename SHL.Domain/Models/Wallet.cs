using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class Wallet : BaseEntity
    {
        [ForeignKey("WalletUser")]
        public Guid WalletUserId { get; set; }
       // public User? WalletUser { get; set; }
        public string? WalletAccountNumber { get; set; }
        public string? WalletCode { get; set; }
        public WalletStatus? WalletStatus { get; set; }
        public WalletType? WalletType { get; set; }
        public double WalletCheckedBalance { get; set; }
        public double WalletAvailableBalance { get; set; }
    }
}