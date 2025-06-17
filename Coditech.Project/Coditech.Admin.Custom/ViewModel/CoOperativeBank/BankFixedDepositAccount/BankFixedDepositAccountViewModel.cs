using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankFixedDepositAccountViewModel : BaseViewModel
    {
        public short BankFixedDepositAccountId { get; set; }
        [Display(Name = "Bank Member")]
        public int BankMemberId { get; set; }
        [Display(Name = "Bank Product")]
        public short BankProductId { get; set; }
        [Display(Name = "Bank Member Nominee")]
        public int BankMemberNomineeId { get; set; }
        [MaxLength(20)]
        [Display(Name = "Account Number")]
        public string FixedDepositAccountNumber { get; set; }
        [Required]
        [Display(Name = "Deposit Amount")]
        public decimal? DepositAmount { get; set; }
        [Required]
        [Display(Name = "Interest Rate")]
        public decimal? InterestRate { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Tenure Months")]
        public int? TenureMonths { get; set; }
        [Display(Name = "Maturity Date")]
        public DateTime MaturityDate { get; set; } = DateTime.Now;
        [Display(Name = "Maturity Amount")]
        public decimal? MaturityAmount { get; set; }
        [Display(Name = "Interest Type")]
        public int InterestTypeEnumId { get; set; }
        [Display(Name = "Interest Payout")]
        public int InterestPayoutEnumId { get; set; }
        public int AccountStatusEnumId { get; set; }
        [Display(Name = "Closure Date")]
        public DateTime ClosureDate { get; set; } = DateTime.Now;
        [Display(Name = "Premature Penalty")]
        public decimal? PrematurePenalty { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        [Display(Name = "Account Status")]
        public string AccountStatus { get; set; }
        [Display(Name = "Interest Type")]
        public string InterestType { get; set; }
        [Display(Name = "Interest Payout")]
        public string InterestPayout { get; set; }
        [Display(Name = "Centre")]
        public string CentreCode { get; set; }
    }
}
