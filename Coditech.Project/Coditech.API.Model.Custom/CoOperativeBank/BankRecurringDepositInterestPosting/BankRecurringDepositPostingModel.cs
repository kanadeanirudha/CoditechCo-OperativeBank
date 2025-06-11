namespace Coditech.Common.API.Model
{
    public partial class BankRecurringDepositInterestPostingModel : BaseModel
    {
        public int BankRecurringDepositInterestPostingId { get; set; }
        public int BankRecurringDepositAccountId { get; set; }
        public decimal InterestAmount { get; set; }
        public DateTime PostingDate { get; set; }
        public string Remarks { get; set; }
    }
}
