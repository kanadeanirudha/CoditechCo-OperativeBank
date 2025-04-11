namespace Coditech.Common.API.Model
{
    public partial class BankSetupOfficesListModel : BaseListModel
    {
        public List<BankSetupOfficesModel> BankSetupOfficesList { get; set; }
        public BankSetupOfficesListModel()
        {
            BankSetupOfficesList = new List<BankSetupOfficesModel>();
        }
    }
}
