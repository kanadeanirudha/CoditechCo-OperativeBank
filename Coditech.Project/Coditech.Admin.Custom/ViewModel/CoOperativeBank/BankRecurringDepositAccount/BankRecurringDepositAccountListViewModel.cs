using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankRecurringDepositAccountListViewModel : BaseViewModel
    {
        public List<BankRecurringDepositAccountViewModel> BankRecurringDepositAccountList { get; set; }
        public BankRecurringDepositAccountListViewModel()
        {
            BankRecurringDepositAccountList = new List<BankRecurringDepositAccountViewModel>();
        }
        public string SelectedCentreCode { get; set; }
    }
}
