using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingsAccountViewModel : BaseViewModel
    {
        public long BankSavingsAccountId { get; set; }
        [Display(Name = "Bank Product")]
        public short BankProductId { get; set; }
        [Display(Name = "Bank Member")]
        public int BankMemberId { get; set; }
        [Display(Name = "Balance Amount")]
        public decimal? BalanceAmount { get; set; }
        [Display(Name = "Status")]
        public int AccountStatusEnumId { get; set; }
        [MaxLength(20)]
        [Display(Name = "Saving Account Number")]
        [Required]
        public string SavingAccountNumber { get; set; }
        [Required]
        [Display(Name = "Opening Date")]
        public DateTime OpeningDate { get; set; }
        [Required]
        [Display(Name = "KYC Status")]
        public bool KYCStatus { get; set; }
        [Display(Name = "Last Balance Update")]
        public DateTime LastBalanceUpdate { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        [Display(Name = "Centre")]
        public string CentreCode { get; set; }
        [Display(Name = "Account Status")]
        public string AccountStatus { get; set; }
    }
}
