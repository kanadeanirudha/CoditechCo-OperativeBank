namespace Coditech.Common.API.Model
{
    public partial class BankFixedDepositClosureModel : BaseModel
    {
        public short BankFixedDepositClosureId { get; set; }
        public short BankFixedDepositAccountId { get; set; }
        public DateTime ClosureDate { get; set; }
        public int ClosureTypeEnumId { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PenaltyApplied { get; set; }
        public string ApprovedBy { get; set; }
        public string Remarks { get; set; }
    }
}
