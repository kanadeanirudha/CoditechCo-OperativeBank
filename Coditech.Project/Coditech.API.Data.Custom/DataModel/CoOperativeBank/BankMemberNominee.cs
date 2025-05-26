using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankMemberNominee
    {
        [Key]
        public int BankMemberNomineeId { get; set; }
        public long PersonId { get; set; }
        public int BankMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PANCardNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public int RelationTypeEnumId { get; set; }
        public decimal PercentageShare { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


