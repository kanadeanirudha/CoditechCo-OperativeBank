using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankFixedDepositInterestPostings
    {
        [Key]
        public short BankFixedDepositInterestPostingsId { get; set; }
        public short BankFixedDepositAccountId { get; set; }
        public DateTime PayoutDate { get; set; }
        public decimal InterestAmount { get; set; }
        public string PayoutMode { get; set; }
        public string Remarks { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

