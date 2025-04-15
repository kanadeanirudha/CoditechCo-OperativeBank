namespace Coditech.Common.API.Model
{
    public partial class BankSetupPropertyValuersModel : BaseModel
    {
        public short BankSetupPropertyValuersId { get; set; }
        public long GeneralPersonAddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobileNumber { get; set; }
    }
}
