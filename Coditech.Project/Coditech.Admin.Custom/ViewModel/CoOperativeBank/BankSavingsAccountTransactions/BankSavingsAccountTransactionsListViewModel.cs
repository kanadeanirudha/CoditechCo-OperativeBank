using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankSavingsAccountTransactionsListViewModel : BaseViewModel
    {
        public List<BankSavingsAccountTransactionsViewModel> BankSavingsAccountTransactionsList { get; set; }
        public BankSavingsAccountTransactionsListViewModel()
        {
            BankSavingsAccountTransactionsList = new List<BankSavingsAccountTransactionsViewModel>();
        }
    }
}
