using Coditech.Common.Helper;
using Coditech.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Coditech.Admin.ViewModel
{
    public partial class BankPostingLoanAccountViewModel : BaseViewModel
    {
        public int BankPostingLoanAccountId { get; set; }

        [Required]
        [Display(Name = "Bank Member")]
        public int BankMemberId { get; set; }

        [Required]
        [Display(Name = "Bank Product")]
        public short BankProductId { get; set; }

        [MaxLength(20)]
        [Required]
        [Display(Name = "Loan Account Number")]
        public string LoanAccountNumber { get; set; }

        [Required]
        [Display(Name = "Loan Type")]
        public int LoanTypeEnumId { get; set; }

        [Required]
        [Display(Name = "Loan Amount")]
        public decimal LoanAmount { get; set; }

        [Required]
        [Display(Name = "Sanctioned Date")]
        public DateTime SanctionedDate { get; set; }

        [Required]
        [Display(Name = "Interest Date")]
        public DateTime InterestDate { get; set; }

        [Required]
        [Display(Name = "Tenure Months")]
        public int TenureMonthsEnumId { get; set; }

        [Required]
        [Display(Name = "Tenure Years")]
        public int TenureYears { get; set; }

        [Required]
        [Display(Name = "Repayment Mode")]
        public int RepaymentModeEnumId { get; set; }

        [Required]
        [Display(Name = "Maturity Date")]
        public DateTime MaturityDate { get; set; }

        [Required]
        [Display(Name = "EMI Amount")]
        public decimal EMIAmount { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Security Detail")]
        public string SecurityDetail { get; set; }

        [Required]
        [Display(Name = "Account Status")]
        public int AccountStatusEnumId { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        public bool IsEditable { get; set; }
        [Display(Name = "Centre")]
        public string SelectedCentreCode { get; set; }
        [Required]
        [Display(Name = "LabelCentre", ResourceType = typeof(AdminResources))]
        public string CentreCode { get; set; }
    }
}
