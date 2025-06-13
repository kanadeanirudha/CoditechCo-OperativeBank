using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankRecurringDepositInterestPostingViewModel : BaseViewModel
    {
        public int BankRecurringDepositInterestPostingId { get; set; }
        public int BankRecurringDepositAccountId { get; set; }
        [Required]
        [Display(Name = "Interest Amount")]
        public decimal InterestAmount { get; set; }
        [Required]
        [Display(Name = " Posting Date")]
        public DateTime PostingDate { get; set; }
        [Required]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}
