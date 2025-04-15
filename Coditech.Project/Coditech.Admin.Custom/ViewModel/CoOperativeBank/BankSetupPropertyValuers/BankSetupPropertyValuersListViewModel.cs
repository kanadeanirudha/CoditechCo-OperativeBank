using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupPropertyValuersListViewModel : BaseViewModel
    {
        public List<BankSetupPropertyValuersViewModel> BankSetupPropertyValuersList { get; set; }
        public BankSetupPropertyValuersListViewModel()
        {
            BankSetupPropertyValuersList = new List<BankSetupPropertyValuersViewModel>();
        }
    }
}
