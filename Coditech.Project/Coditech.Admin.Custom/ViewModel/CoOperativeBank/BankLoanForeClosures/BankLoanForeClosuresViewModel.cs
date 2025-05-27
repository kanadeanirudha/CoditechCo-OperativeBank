using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public class BankLoanForeClosuresViewModel : BaseViewModel
    {
        public int BankLoanForeClosuresId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        [Required]
        [Display(Name = "Remaining EMI")]
        public int RemainingEMI { get; set; }
        [Required]
        [Display(Name = "Remaining EMI Amount")]
        public decimal RemainingEMIAmount { get; set; }
        [Required]
        [Display(Name = "Maturity Date")]
        public DateTime MaturityDate { get; set; } = DateTime.Now;
        public int LoanScheduleStatusEnumId { get; set; }
        [Display(Name = "Loan Schedule Status")]
        public string LoanScheduleStatus { get; set; }
    }
}
