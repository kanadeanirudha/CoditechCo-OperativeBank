namespace Coditech.Common.API.Model
{
    public partial class BankSetupPropertyValuersListModel : BaseListModel
    {
        public List<BankSetupPropertyValuersModel> BankSetupPropertyValuersList { get; set; }
        public BankSetupPropertyValuersListModel()
        {
            BankSetupPropertyValuersList = new List<BankSetupPropertyValuersModel>();
        }
        public List<BankSetupPropertyValuersModel> PersonAddressList { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
