using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingAccountInterestPostingsListViewModel : BaseViewModel
    {
        public List<BankSavingAccountInterestPostingsViewModel> BankSavingAccountInterestPostingsList { get; set; }
        public BankSavingAccountInterestPostingsListViewModel()
        {
            BankSavingAccountInterestPostingsList = new List<BankSavingAccountInterestPostingsViewModel>();
        }
    }
}
