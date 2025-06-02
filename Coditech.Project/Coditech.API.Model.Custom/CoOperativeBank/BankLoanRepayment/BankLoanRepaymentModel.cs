namespace Coditech.Common.API.Model
{
    public partial class BankLoanRepaymentModel : BaseModel
    {
        public int BankLoanRepaymentId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PrincipalComponent { get; set; }
        public decimal InterestComponent { get; set; }
        public decimal PenaltyCharges { get; set; }
        public int PaymentModeEnumId { get; set; }
        public string ReceiptNumber { get; set; }
        public string Remark { get; set; }
        public bool IsEditable { get; set; }
        public string LoanAccountNumber { get; set; }
    }
}
