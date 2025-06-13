using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankSavingsAccountTransactions
    {
        [Key]
        public long BankSavingsTransactionsId { get; set; }
        public long BankSavingsAccountId { get; set; }
        public DateTime TranscationDate { get; set; }
        public int BankSavingsTranscationTypeEnumId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentModeEnumId { get; set; }
        public decimal BalanceAfter { get; set; }
        public int CheckingApprovalEnumId { get; set; }
        public int TransactionStatusEnumId { get; set; }
        public string TransactionalRemark { get; set; }
        public DateTime IsEndOfDate { get; set; }
        public DateTime EODDate { get; set; }
        public DateTime EODTimeStamp { get; set; }
        public string TranscationPositing { get; set; }
        public string VoucherNumber { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

