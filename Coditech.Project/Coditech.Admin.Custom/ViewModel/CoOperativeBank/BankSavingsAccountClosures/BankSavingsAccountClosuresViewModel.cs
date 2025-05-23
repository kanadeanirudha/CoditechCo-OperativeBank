using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingsAccountClosuresViewModel : BaseViewModel
    {
        public int BankSavingsAccountClosuresId { get; set; }
        public long BankSavingsAccountId { get; set; }
        [Required]
        [Display(Name = "Closure Date")]
        public DateTime ClosureDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Closing Balance")]
        public decimal ClosingBalance { get; set; }
        [Required]
        [Display(Name = "Reason")]
        public string Reason { get; set; }
        [Required]
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
