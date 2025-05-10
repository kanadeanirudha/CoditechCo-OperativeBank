namespace Coditech.Common.API.Model
{
    public partial class BankSavingAccountIntrestPostingsModel : BaseModel
    {
        public int BankSavingAccountIntrestPostingsId { get; set; }
        public long BankSavingsAccountId { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public decimal InterestAmount { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
