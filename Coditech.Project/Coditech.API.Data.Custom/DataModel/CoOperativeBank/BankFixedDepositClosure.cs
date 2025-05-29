using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankFixedDepositClosure
    {
        [Key]
        public short BankFixedDepositClosureId { get; set; }
        public short BankFixedDepositAccountId { get; set; }
        public DateTime ClosureDate { get; set; }
        public int ClosureTypeEnumId { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PenaltyApplied { get; set; }
        public string ApprovedBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

