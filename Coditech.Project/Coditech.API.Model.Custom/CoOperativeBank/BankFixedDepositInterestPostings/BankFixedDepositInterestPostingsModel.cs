namespace Coditech.Common.API.Model
{
    public partial class BankFixedDepositInterestPostingsModel : BaseModel
    {
        public short BankFixedDepositInterestPostingsId { get; set; }
        public short BankFixedDepositAccountId { get; set; }
        public DateTime PayoutDate { get; set; }
        public decimal InterestAmount { get; set; }
        public string PayoutMode { get; set; }
        public string Remarks { get; set; }
    }
}
