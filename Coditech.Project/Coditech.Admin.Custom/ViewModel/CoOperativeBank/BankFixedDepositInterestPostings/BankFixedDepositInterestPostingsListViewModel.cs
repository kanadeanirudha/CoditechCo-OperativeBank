using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankFixedDepositInterestPostingsListViewModel : BaseViewModel
    {
        public List<BankFixedDepositInterestPostingsViewModel> BankFixedDepositInterestPostingsList { get; set; }
        public BankFixedDepositInterestPostingsListViewModel()
        {
            BankFixedDepositInterestPostingsList = new List<BankFixedDepositInterestPostingsViewModel>();
        }
    }
}
