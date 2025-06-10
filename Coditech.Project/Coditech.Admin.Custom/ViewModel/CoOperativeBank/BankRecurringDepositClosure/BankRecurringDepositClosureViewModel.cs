using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankRecurringDepositClosureViewModel : BaseViewModel
    {
         public int BankRecurringDepositClosureId { get; set; }
        public int BankRecurringDepositAccountId { get; set; }
        [Display(Name = "Closure Date")]
        public DateTime ClosureDate { get; set; }
        public int ClosureTypeEnumId { get; set; }
        [Required]
        [Display(Name = "Reason")]
        public string Reason { get; set; }
        [Required]
        [Display(Name = "Amount Paid")]
        public decimal AmountPaid { get; set; }
        [Required]
        [Display(Name = "Penalty Amount")]
        public decimal PenaltyAmount { get; set; }
        [Required]
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }
        [Display(Name = "Closure Type")]
        public string ClosureType { get; set; }
    }
}
