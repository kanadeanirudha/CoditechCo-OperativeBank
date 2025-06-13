namespace Coditech.Common.API.Model
{
    public partial class BankLoanScheduleModel : BaseModel
    {
        public short BankLoanScheduleId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        public DateTime Duedate { get; set; }
        public decimal EMIAmount { get; set; }
        public decimal PrincipalDue { get; set; }
        public decimal InterestDue { get; set; }
        public int LoanScheduleStatusEnumId { get; set; }
        public string LoanScheduleStatus { get; set; }
    }
}
