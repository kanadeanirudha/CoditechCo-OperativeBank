using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankProductListViewModel : BaseViewModel
    {
        public List<BankProductViewModel> BankProductList { get; set; }
        public BankProductListViewModel()
        {
            BankProductList = new List<BankProductViewModel>();
        }
        public string SelectedCentreCode { get; set; }
    }
}
