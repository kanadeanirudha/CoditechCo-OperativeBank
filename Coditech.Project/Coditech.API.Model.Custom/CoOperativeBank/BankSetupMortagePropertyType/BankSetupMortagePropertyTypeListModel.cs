namespace Coditech.Common.API.Model
{
    public partial class BankSetupMortagePropertyTypeListModel : BaseListModel
    {
        public List<BankSetupMortagePropertyTypeModel> BankSetupMortagePropertyTypeList { get; set; }
        public BankSetupMortagePropertyTypeListModel()
        {
            BankSetupMortagePropertyTypeList = new List<BankSetupMortagePropertyTypeModel>();
        }

    }
}
