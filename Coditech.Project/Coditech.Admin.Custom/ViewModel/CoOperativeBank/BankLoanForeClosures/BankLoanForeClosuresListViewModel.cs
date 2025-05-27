using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankLoanForeClosuresListViewModel : BaseViewModel
    {
        public List<BankLoanForeClosuresViewModel> BankLoanForeClosuresList { get; set; }
        public BankLoanForeClosuresListViewModel()
        {
            BankLoanForeClosuresList = new List<BankLoanForeClosuresViewModel>();
        }
    }
}
