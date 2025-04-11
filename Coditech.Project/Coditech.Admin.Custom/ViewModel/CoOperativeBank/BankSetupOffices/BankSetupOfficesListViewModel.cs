using Coditech.Common.API.Model;
using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankSetupOfficesListViewModel : BaseViewModel
    {
        public List<BankSetupOfficesViewModel> BankSetupOfficesList { get; set; }
        public BankSetupOfficesListViewModel()
        {
            BankSetupOfficesList = new List<BankSetupOfficesViewModel>();
        }
    }
}
