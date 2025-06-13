using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankLoanScheduleViewModel : BaseViewModel
    {
        public short BankLoanScheduleId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        [Required]
        [Display(Name = "Due date")]
        public DateTime Duedate { get; set; }
        [Required]
        [Display(Name = "EMI Amount")]
        public decimal EMIAmount { get; set; }
        [Required]
        [Display(Name = "Principal Due")]
        public decimal PrincipalDue { get; set; }
        [Required]
        [Display(Name = "Interest Due")]
        public decimal InterestDue { get; set; }
        public int LoanScheduleStatusEnumId { get; set; }
        [Display(Name = "Loan Status")]
        public string LoanScheduleStatus { get; set; }
    }
}
