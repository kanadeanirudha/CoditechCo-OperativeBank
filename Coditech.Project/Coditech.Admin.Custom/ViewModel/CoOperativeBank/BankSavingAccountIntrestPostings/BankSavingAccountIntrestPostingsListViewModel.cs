using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingAccountIntrestPostingsListViewModel : BaseViewModel
    {
        public List<BankSavingAccountIntrestPostingsViewModel> BankSavingAccountIntrestPostingsList { get; set; }
        public BankSavingAccountIntrestPostingsListViewModel()
        {
            BankSavingAccountIntrestPostingsList = new List<BankSavingAccountIntrestPostingsViewModel>();
        }
    }
}
