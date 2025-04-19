namespace Coditech.Common.API.Model
{
    public partial class BankSetupPropertyValuersAuthorityListModel : BaseListModel
    {
        public List<BankSetupPropertyValuersAuthorityModel> BankSetupPropertyValuersAuthorityList { get; set; }
        public BankSetupPropertyValuersAuthorityListModel()
        {
            BankSetupPropertyValuersAuthorityList = new List<BankSetupPropertyValuersAuthorityModel>();
        }

    }
}
