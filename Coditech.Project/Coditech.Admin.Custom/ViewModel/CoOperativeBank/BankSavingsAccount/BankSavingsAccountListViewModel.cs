using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingsAccountListViewModel : BaseViewModel
    {
        public List<BankSavingsAccountViewModel> BankSavingsAccountList { get; set; }
        public BankSavingsAccountListViewModel()
        {
            BankSavingsAccountList = new List<BankSavingsAccountViewModel>();
        }
    }
}
