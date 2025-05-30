using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankRecurringDepositAccountViewModel : BaseViewModel
    {
        public int BankRecurringDepositAccountId { get; set; }
        [Display(Name = "Bank Product")]
        public short BankProductId { get; set; }
        [Display(Name = "Bank Member")]
        public int BankMemberId { get; set; }

        [Display(Name = "Bank Member Nominee")]
        public int BankMemberNomineeId { get; set; }

        [MaxLength(20)]
        [Required]
        [Display(Name = "Account Number ")]
        public string AccountNumber { get; set; }
        [Display(Name = "Monthly Installment")]
        public decimal MonthlyInstallment { get; set; }
      
        [Display(Name = "Start Date ")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Display(Name = "Duration Months")]
        public short DurationMonths { get; set; }
        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }
        [Display(Name = "Maturity Amount")]
        public decimal MaturityAmount { get; set; }
        [Display(Name = "Maturity Date")]
        public DateTime MaturityDate { get; set; } =DateTime.Now;
        [Display(Name = " Interest Type")]
        public int InterestTypeEnumId { get; set; }
        [Display(Name = "Account Status")]
        public int AccountStatusEnumId { get; set; }
        [Display(Name = "Closure Date ")]
        public DateTime ClosureDate { get; set; }= DateTime.Now;
        [Display(Name = "Premature Penalty  ")]
        public decimal PrematurePenalty { get; set; }
        [Display(Name = "Remarks  ")]
        public string Remarks { get; set; }
        [Display(Name = "Centre")]
        public string CentreCode { get; set; }
        public string InterestType { get; set; }
        public string AccountStatus { get; set; }

    }
}
