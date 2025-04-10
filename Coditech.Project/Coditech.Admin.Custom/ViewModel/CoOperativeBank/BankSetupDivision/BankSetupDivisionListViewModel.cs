using Coditech.Common.API.Model;
using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankSetupDivisionListViewModel : BaseViewModel
    {
        public List<BankSetupDivisionViewModel> BankSetupDivisionList { get; set; }
        public BankSetupDivisionListViewModel()
        {
            BankSetupDivisionList = new List<BankSetupDivisionViewModel>();
        }
    }
}
