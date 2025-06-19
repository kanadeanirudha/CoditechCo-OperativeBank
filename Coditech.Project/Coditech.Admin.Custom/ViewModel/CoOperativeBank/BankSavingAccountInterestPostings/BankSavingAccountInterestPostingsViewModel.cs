using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingAccountInterestPostingsViewModel : BaseViewModel
    {
        public int BankSavingAccountInterestPostingsId { get; set; }
        [Display(Name = "Savings Account")]
        public long BankSavingsAccountId { get; set; }
        [Required]
        [Display(Name = "Period Start Date")]
        public DateTime PeriodStartDate { get; set; }
        [Required]
        [Display(Name = "Period End Date")]
        public DateTime PeriodEndDate { get; set; }
        [Display(Name = "Interest Amount")]
        public decimal? InterestAmount { get; set; }
        [Required]
        [Display(Name = "Posted On")]
        public DateTime PostedOn { get; set; }
    }
}
