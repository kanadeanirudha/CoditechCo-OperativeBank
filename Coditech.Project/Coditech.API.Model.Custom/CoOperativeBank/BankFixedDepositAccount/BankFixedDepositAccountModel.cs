namespace Coditech.Common.API.Model
{
    public partial class BankFixedDepositAccountModel : BaseModel
    {
        public short BankFixedDepositAccountId { get; set; }
        public int BankMemberId { get; set; }
        public short BankProductId { get; set; }
        public int BankMemberNomineeId { get; set; }
        public int FixedDepositAccountNumber { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public int TenureMonths { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal MaturityAmount { get; set; }
        public int InterestTypeEnumId { get; set; }
        public int InterestPayoutEnumId { get; set; }
        public int AccountStatusEnumId { get; set; }
        public DateTime ClosureDate { get; set; }
        public decimal PrematurePenalty { get; set; }
        public string Remarks { get; set; }
        public string AccountStatus { get; set; }
        public string InterestType { get; set; }
        public string InterestPayout { get; set; }
        public string SelectedCentreCode { get; set; }
    }
}
