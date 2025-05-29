using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankFixedDepositClosureListViewModel : BaseViewModel
    {
        public List<BankFixedDepositClosureViewModel> BankFixedDepositClosureList { get; set; }
        public BankFixedDepositClosureListViewModel()
        {
            BankFixedDepositClosureList = new List<BankFixedDepositClosureViewModel>();
        }
    }
}
