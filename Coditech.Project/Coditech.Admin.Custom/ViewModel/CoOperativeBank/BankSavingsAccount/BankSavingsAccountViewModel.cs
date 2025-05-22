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
        [Display(Name = "Saving Account Number")]
        public string SavingAccountNumber { get; set; }
        [Display(Name = "Opening Date")]
        public DateTime OpeningDate { get; set; } = DateTime.Now;
        [Display(Name = "KYC Status")]
        public bool KYCStatus { get; set; }
        [Display(Name = "Last Balance Update")]
        public DateTime LastBalanceUpdate { get; set; } = DateTime.Now;
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        [Display(Name = "Centre")]
        public string CentreCode { get; set; }
        [Display(Name = "Account Status")]
        public string AccountStatus { get; set; }
    }
}
