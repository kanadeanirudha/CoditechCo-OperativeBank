using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankRecurringDepositClosureListViewModel : BaseViewModel
    {
        public List<BankRecurringDepositClosureViewModel> BankRecurringDepositClosureList { get; set; }
        public BankRecurringDepositClosureListViewModel()
        {
            BankRecurringDepositClosureList = new List<BankRecurringDepositClosureViewModel>();
        }
    }
}
