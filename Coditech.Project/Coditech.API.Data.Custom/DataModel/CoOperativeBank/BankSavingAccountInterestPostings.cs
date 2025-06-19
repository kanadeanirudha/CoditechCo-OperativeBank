using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankSavingAccountInterestPostings
    {
        [Key]
        public int BankSavingAccountInterestPostingsId { get; set; }
        public long BankSavingsAccountId { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public decimal InterestAmount { get; set; }
        public DateTime PostedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

