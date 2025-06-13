using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingsAccountTransactionsViewModel : BaseViewModel
    {
        public long BankSavingsTransactionsId { get; set; }
        public long BankSavingsAccountId { get; set; }
        [Required]
        [Display(Name = "Transcation Date")]
        public DateTime TranscationDate { get; set; }
        public int BankSavingsTranscationTypeEnumId { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        public int PaymentModeEnumId { get; set; }
        [Required]
        [Display(Name = "Balance After")]
        public decimal BalanceAfter { get; set; }
        public int CheckingApprovalEnumId { get; set; }
        public int TransactionStatusEnumId { get; set; }
        [Required]
        [Display(Name = "Transactional Remark")]
        public string TransactionalRemark { get; set; }
        [Required]
        [Display(Name = "Is End Of Date")]
        public DateTime IsEndOfDate { get; set; }
        [Required]
        [Display(Name = "EOD Date")]
        public DateTime EODDate { get; set; }
        [Required]
        [Display(Name = "EOD Time Stamp")]
        public DateTime EODTimeStamp { get; set; }
        [Required]
        [Display(Name = "Transcation Positing")]
        public string TranscationPositing { get; set; }
        [Required]
        [Display(Name = "Voucher Number")]
        public string VoucherNumber { get; set; }
        [Display(Name = "Transcation Type")]
        public string BankSavingsTranscationType { get; set; }
        [Display(Name = "Payment Mode")]
        public string PaymentMode { get; set; }
        [Display(Name = "Checking Approval")]
        public string CheckingApproval { get; set; }
        [Display(Name = "Transaction Status")]
        public string TransactionStatus { get; set; }
    }
}
