namespace Coditech.Common.API.Model
{
    public partial class BankRecurringDepositClosureModel : BaseModel
    {
        public int BankRecurringDepositClosureId { get; set; }
        public int BankRecurringDepositAccountId { get; set; }
        public DateTime ClosureDate { get; set; }
        public int ClosureTypeEnumId { get; set; }
        public string Reason { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PenaltyAmount { get; set; }
        public string ApprovedBy { get; set; }
    }
}
