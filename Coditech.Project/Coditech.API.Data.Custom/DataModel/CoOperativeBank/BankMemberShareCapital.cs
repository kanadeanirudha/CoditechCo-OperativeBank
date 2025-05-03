using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankMemberShareCapital
    {
        [Key]
        public short BankMemberShareCapitalId { get; set; }
        public int BankMemberId { get; set; }
        public int NumberOfShares { get; set; }
        public decimal AmountInvested { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal SharePrice { get; set; }
        public int PaymentModeEnumId { get; set; }
        public string TranscationReference { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


