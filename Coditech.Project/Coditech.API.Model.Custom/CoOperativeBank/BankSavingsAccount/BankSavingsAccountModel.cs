namespace Coditech.Common.API.Model
{
    public partial class BankSavingsAccountModel : BaseModel
    {
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
        public string AccountStatus { get; set; }
    }
}
