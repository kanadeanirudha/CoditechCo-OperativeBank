using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public class BankLoanScheduleListViewModel : BaseViewModel
    {
        public List<BankLoanScheduleViewModel> BankLoanScheduleList { get; set; }
        public BankLoanScheduleListViewModel()
        {
            BankLoanScheduleList = new List<BankLoanScheduleViewModel>();
        }
    }
}
