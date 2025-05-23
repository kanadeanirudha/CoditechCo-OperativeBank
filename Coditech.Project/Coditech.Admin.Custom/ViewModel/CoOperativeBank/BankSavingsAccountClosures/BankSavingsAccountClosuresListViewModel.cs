using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingsAccountClosuresListViewModel : BaseViewModel
    {
        public List<BankSavingsAccountClosuresViewModel> BankSavingsAccountClosuresList { get; set; }
        public BankSavingsAccountClosuresListViewModel()
        {
            BankSavingsAccountClosuresList = new List<BankSavingsAccountClosuresViewModel>();
        }
    }
}
