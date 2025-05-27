using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankLoanForeClosures
    {
        [Key]
        public int BankLoanForeClosuresId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        public int RemainingEMI { get; set; }
        public decimal RemainingEMIAmount { get; set; }
        public DateTime MaturityDate { get; set; }
        public int LoanScheduleStatusEnumId { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

