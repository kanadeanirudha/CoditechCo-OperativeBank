using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankMemberShareCapitalViewModel : BaseViewModel
    {
        public int BankMemberShareCapitalId { get; set; }

        [Display(Name = "Bank Member ")]
        public int BankMemberId { get; set; }
        [Display(Name = "Number Of Shares ")]
        [Required]
        public int NumberOfShares { get; set; }
        [Display(Name = "Amount Invested")]
        [Required]
        public decimal AmountInvested { get; set; }
        [Display(Name = "Purchased Date")]
        [Required]
        public DateTime PurchaseDate {  get; set; }
        [Display(Name = "Share Price")]
        [Required]
        public decimal SharePrice { get; set; }
        [Display(Name = "Payment Mode ")]
        public int PaymentModeEnumId { get; set; }
        [Display(Name = "Transcation Reference ")]
        public string TranscationReference {  get; set; }
        [Display(Name = "Remarks ")]
        public string Remarks { get; set; }
        [Display(Name = "Is Active ")]
        [Required]
        public bool IsActive { get; set; }
        public long PersonId { get; set; }
    }
}
