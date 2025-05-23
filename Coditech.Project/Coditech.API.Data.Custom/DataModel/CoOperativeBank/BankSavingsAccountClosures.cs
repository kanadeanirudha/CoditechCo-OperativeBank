using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankSavingsAccountClosures
    {
        [Key]
        public int BankSavingsAccountClosuresId { get; set; }
        public long BankSavingsAccountId { get; set; }
        public DateTime ClosureDate { get; set; }
        public decimal ClosingBalance { get; set; }
        public string Reason { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

