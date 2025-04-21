namespace Coditech.Common.API.Model.Response
{
    public class BankSetupPropertyValuersListResponse : BaseListResponse
    {
        public List<BankSetupPropertyValuersModel> BankSetupPropertyValuersList { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
