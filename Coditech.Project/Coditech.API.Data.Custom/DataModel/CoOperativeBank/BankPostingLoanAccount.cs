using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankPostingLoanAccount
    {
        [Key]
        public int BankPostingLoanAccountId { get; set; }
        public int BankMemberId { get; set; }
        public short BankProductId { get; set; }
        public string CentreCode { get; set; }
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
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


