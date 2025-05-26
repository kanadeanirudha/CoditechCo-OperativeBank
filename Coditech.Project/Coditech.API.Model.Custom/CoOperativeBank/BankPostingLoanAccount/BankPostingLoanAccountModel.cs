using System.ComponentModel.DataAnnotations;

namespace Coditech.Common.API.Model
{
    public partial class BankPostingLoanAccountModel : BaseModel
    {
        public int BankPostingLoanAccountId { get; set; }
        public int BankMemberId { get; set; }
        public short BankProductId { get; set; }
        public string LoanAccountNumber { get; set; }
        public int LoanTypeEnumId { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime SanctionedDate { get; set; }
        public DateTime InterestDate { get; set; }
        public int TenureMonthsEnumId { get; set; }
        public int RepaymentModeEnumId { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal EMIAmount { get; set; }
        public string SecurityDetail { get; set; }
        public int AccountStatusEnumId { get; set; }
        public string Remark { get; set; }
        public bool IsEditable { get; set; }
        public string SelectedCentreCode { get; set; }
        public int TenureYears { get; set; }
        public string CentreCode { get; set; }
    }
}
