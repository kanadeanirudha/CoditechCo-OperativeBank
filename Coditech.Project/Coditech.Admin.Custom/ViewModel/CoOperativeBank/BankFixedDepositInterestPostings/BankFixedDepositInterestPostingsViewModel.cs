using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankFixedDepositInterestPostingsViewModel : BaseViewModel
    {
        public short BankFixedDepositInterestPostingsId { get; set; }
        public short BankFixedDepositAccountId { get; set; }
        [Required]
        [Display(Name = "Payout Date")]
        public DateTime PayoutDate { get; set; }
        [Required]
        [Display(Name = "Interest Amount")]
        public decimal InterestAmount { get; set; }
        [Required]
        [Display(Name = "Payout Mode")]
        public string PayoutMode { get; set; }
        [Required]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
    }
}
