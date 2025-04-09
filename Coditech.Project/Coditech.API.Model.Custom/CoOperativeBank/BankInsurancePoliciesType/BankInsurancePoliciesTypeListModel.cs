namespace Coditech.Common.API.Model
{
    public partial class BankInsurancePoliciesTypeListModel : BaseListModel
    {
        public List<BankInsurancePoliciesTypeModel> BankInsurancePoliciesTypeList { get; set; }
        public BankInsurancePoliciesTypeListModel()
        {
            BankInsurancePoliciesTypeList = new List<BankInsurancePoliciesTypeModel>();
        }
    }
}
