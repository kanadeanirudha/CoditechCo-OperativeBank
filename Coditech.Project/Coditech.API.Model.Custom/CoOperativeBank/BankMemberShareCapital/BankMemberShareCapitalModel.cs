namespace Coditech.Common.API.Model
{
    public partial class BankMemberShareCapitalModel : BaseModel
    {
        public int BankMemberShareCapitalId { get; set; }
        public int BankMemberId { get; set; }
        public int NumberOfShares { get; set; }
        public decimal AmountInvested { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal SharePrice { get; set; }
        public int PaymentModeEnumId { get; set; }
        public string TranscationReference { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }

    }
}
