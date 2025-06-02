using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankLoanRepayment
    {
        [Key]
        public int BankLoanRepaymentId { get; set; }
        public int BankPostingLoanAccountId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal PrincipalComponent { get; set; }
        public decimal InterestComponent { get; set; }
        public decimal PenaltyCharges { get; set; }
        public int PaymentModeEnumId { get; set; }
        public string ReceiptNumber { get; set; }
        public string Remark { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


