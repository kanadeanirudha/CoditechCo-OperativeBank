using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankSavingsAccount
    {
        [Key]
        public long BankSavingsAccountId { get; set; }
        public short BankProductId { get; set; }
        public int BankMemberId { get; set; }
        public decimal BalanceAmount { get; set; }
        public int AccountStatusEnumId { get; set; }
        public string SavingAccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public bool KYCStatus { get; set; }
        public DateTime LastBalanceUpdate { get; set; }
        public string Remark { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

