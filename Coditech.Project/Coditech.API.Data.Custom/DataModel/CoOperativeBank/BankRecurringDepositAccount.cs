using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankRecurringDepositAccount
    {
        [Key]
        public int BankRecurringDepositAccountId { get; set; }
        public short BankProductId { get; set; }
        public int BankMemberId { get; set; }
        public int BankMemberNomineeId { get; set; }
        public string AccountNumber { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public DateTime StartDate { get; set; }
        public short DurationMonths { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MaturityAmount { get; set; }
        public DateTime MaturityDate { get; set; }
        public int InterestTypeEnumId { get; set; }
        public int AccountStatusEnumId { get; set; }
        public DateTime ClosureDate { get; set; }
        public decimal PrematurePenalty { get; set; }
        public string Remarks { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

