using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankRecurringDepositClosure
    {
        [Key]
        public int BankRecurringDepositClosureId { get; set; }
        public int BankRecurringDepositAccountId { get; set; }
        public DateTime ClosureDate { get; set; }
        public int ClosureTypeEnumId { get; set; }
        public string Reason { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PenaltyAmount { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

