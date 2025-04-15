namespace Coditech.Common.API.Model
{
    public partial class BankSetupPropertyValuersListModel : BaseListModel
    {
        public List<BankSetupPropertyValuersModel> BankSetupPropertyValuersList { get; set; }
        public BankSetupPropertyValuersListModel()
        {
            BankSetupPropertyValuersList = new List<BankSetupPropertyValuersModel>();
        }

    }
}
