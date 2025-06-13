using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankRecurringDepositInterestPosting
    {
        [Key]
        public int BankRecurringDepositInterestPostingId { get; set; }
        public int BankRecurringDepositAccountId { get; set; }
        public decimal InterestAmount { get; set; }
        public DateTime PostingDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

