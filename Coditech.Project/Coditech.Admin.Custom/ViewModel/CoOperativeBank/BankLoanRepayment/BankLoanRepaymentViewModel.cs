using Coditech.Common.Helper;
using Coditech.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Coditech.Admin.ViewModel
{
    public partial class BankLoanRepaymentViewModel : BaseViewModel
    {
        public int BankLoanRepaymentId { get; set; }

        [Required]
        public int BankPostingLoanAccountId { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Display(Name = "Amount Paid")]
        public decimal AmountPaid { get; set; }

        [Required]
        [Display(Name = "Pricipal Component")]
        public decimal PrincipalComponent { get; set; }

        [Required]
        [Display(Name = "Interest Component")]
        public decimal InterestComponent { get; set; }

        [Required]
        [Display(Name = "Penalty Charges")]
        public decimal PenaltyCharges { get; set; }

        [Required]
        [Display(Name = "Payment Mode")]
        public int PaymentModeEnumId { get; set; } 

        [Display(Name = "Receipt Number")]
        public string ReceiptNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        public bool IsEditable { get; set; }
        public string LoanAccountNumber { get; set; }
    }
}
