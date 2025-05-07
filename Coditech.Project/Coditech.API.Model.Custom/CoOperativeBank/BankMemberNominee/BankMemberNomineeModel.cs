namespace Coditech.Common.API.Model
{
    public partial class BankMemberNomineeModel : BaseModel
    {
        public int BankMemberNomineeId { get; set; }
        public long PersonId { get; set; } 
        public int BankMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PANCardNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public int RelationTypeEnumId { get; set; }
        public decimal PercentageShare { get; set; }
       

    }
}
