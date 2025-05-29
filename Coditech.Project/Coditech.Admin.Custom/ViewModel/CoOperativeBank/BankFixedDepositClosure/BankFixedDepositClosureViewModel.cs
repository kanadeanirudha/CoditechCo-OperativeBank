using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankFixedDepositClosureViewModel : BaseViewModel
    {
        public short BankFixedDepositClosureId { get; set; }
        public short BankFixedDepositAccountId { get; set; }
        [Display(Name = "Closure Date")]
        public DateTime ClosureDate { get; set; }
        public int ClosureTypeEnumId { get; set; }
        [Required]
        [Display(Name = "Amount Paid")]
        public decimal AmountPaid { get; set; }
        [Required]
        [Display(Name = "Penalty Applied")]
        public decimal PenaltyApplied { get; set; }
        [Required]
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }
        [Required]
        public string Remarks { get; set; }
        [Display(Name = "Closure Type")]
        public string ClosureType { get; set; }
        public string CentreCode { get; set; }
    }
}
