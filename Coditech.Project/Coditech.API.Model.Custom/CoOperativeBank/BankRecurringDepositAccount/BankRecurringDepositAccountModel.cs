namespace Coditech.Common.API.Model
{
    public partial class BankRecurringDepositAccountModel : BaseModel
    {
        public int BankRecurringDepositAccountId { get; set; }
        public short BankProductId { get; set; }
        public int BankMemberId { get; set; }
        public int BankMemberNomineeId { get; set; }
        public string AccountNumber { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public DateTime StartDate { get; set; }
        public short DurationMonths { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MaturityAmount{ get; set; }
        public DateTime MaturityDate { get; set; }
        public int InterestTypeEnumId { get; set; }
        public int AccountStatusEnumId { get; set; }
        public DateTime ClosureDate { get; set; }
        public decimal PrematurePenalty { get; set; }
        public string Remarks { get; set; }
        public string InterestType { get; set; }
        public string AccountStatus { get; set; }
        public string CentreCode { get; set; }


    }
}
