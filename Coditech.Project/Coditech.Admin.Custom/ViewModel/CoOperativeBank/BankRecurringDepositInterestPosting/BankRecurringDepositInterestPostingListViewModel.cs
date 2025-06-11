using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankRecurringDepositInterestPostingListViewModel : BaseViewModel
    {
        public List<BankRecurringDepositInterestPostingViewModel> BankRecurringDepositInterestPostingList { get; set; }
        public BankRecurringDepositInterestPostingListViewModel()
        {
            BankRecurringDepositInterestPostingList = new List<BankRecurringDepositInterestPostingViewModel>();
        }
    }
}
