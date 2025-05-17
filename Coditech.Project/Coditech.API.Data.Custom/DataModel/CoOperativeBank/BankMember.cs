using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankMember
    {
        [Key]
        public int BankMemberId { get; set; }
        public long PersonId { get; set; }
        public string MemberCode { get; set; }
        public string UserType { get; set; }
        public string CentreCode { get; set; }
        public string PANCardNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public DateTime JoiningDate { get; set; }
        public int AccountStatusEnumId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


