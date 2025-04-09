using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankInsurancePoliciesTypeListViewModel : BaseViewModel
    {
        public List<BankInsurancePoliciesTypeViewModel> BankInsurancePoliciesTypeList { get; set; }
        public BankInsurancePoliciesTypeListViewModel()
        {
            BankInsurancePoliciesTypeList = new List<BankInsurancePoliciesTypeViewModel>();
        }
    }
}
