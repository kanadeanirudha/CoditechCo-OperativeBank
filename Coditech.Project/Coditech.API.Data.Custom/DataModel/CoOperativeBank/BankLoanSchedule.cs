using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankLoanSchedule
    {
        [Key]
        public short BankLoanScheduleId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        public DateTime Duedate { get; set; }
        public decimal EMIAmount { get; set; }
        public decimal PrincipalDue { get; set; }
        public decimal InterestDue { get; set; }
        public int LoanScheduleStatusEnumId { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

