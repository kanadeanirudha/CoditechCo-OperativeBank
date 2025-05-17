namespace Coditech.Common.API.Model
{
    public partial class BankMemberModel : BaseModel
    {
        public int BankMemberId { get; set; }
        public string PANCardNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public DateTime JoiningDate { get; set; }
        public int AccountStatusEnumId { get; set; }
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MemberCode { get; set; }
        public string CentreCode { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
