namespace Coditech.Common.API.Model
{
    public partial class BankLoanForeClosuresModel : BaseModel
    {
        public int BankLoanForeClosuresId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        public int RemainingEMI { get; set; }
        public decimal RemainingEMIAmount { get; set; }
        public DateTime MaturityDate { get; set; }
        public int LoanScheduleStatusEnumId { get; set; }
    }
}
