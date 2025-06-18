namespace Coditech.Common.API.Model
{
    public partial class BankSavingsAccountTransactionsModel : BaseModel
    {
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
        public string TranscationPosting { get; set; }
        public string VoucherNumber { get; set; }
        public string BankSavingsTranscationType { get; set; }
        public string PaymentMode { get; set; }
        public string CheckingApproval { get; set; }
        public string TransactionStatus { get; set; }
    }
}
