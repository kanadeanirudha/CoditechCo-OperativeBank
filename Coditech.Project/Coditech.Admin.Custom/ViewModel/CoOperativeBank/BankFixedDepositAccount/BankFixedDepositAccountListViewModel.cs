using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankFixedDepositAccountListViewModel : BaseViewModel
    {
        public List<BankFixedDepositAccountViewModel> BankFixedDepositAccountList { get; set; }
        public BankFixedDepositAccountListViewModel()
        {
            BankFixedDepositAccountList = new List<BankFixedDepositAccountViewModel>();
        }
        public string SelectedCentreCode { get; set; }
    }
}
