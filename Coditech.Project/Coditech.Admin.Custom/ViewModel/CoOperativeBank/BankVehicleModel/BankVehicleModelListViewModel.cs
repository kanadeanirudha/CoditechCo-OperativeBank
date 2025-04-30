using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public partial class BankVehicleModelListViewModel : BaseViewModel
    {
        public List<BankVehicleModelViewModel> BankVehicleModelList { get; set; }
        public BankVehicleModelListViewModel()
        {
            BankVehicleModelList = new List<BankVehicleModelViewModel>();
        }
    }
}
