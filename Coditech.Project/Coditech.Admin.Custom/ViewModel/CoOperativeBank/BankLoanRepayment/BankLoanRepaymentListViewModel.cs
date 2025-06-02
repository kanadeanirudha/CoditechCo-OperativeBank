using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankLoanRepaymentListViewModel : BaseViewModel
    {
        public List<BankLoanRepaymentViewModel> BankLoanRepaymentList { get; set; }
        public BankLoanRepaymentListViewModel()
        {
            BankLoanRepaymentList = new List<BankLoanRepaymentViewModel>();
        }
        public string SelectedParameter1 { get; set; }
        public int BankMemberId { get; set; }
        public string CentreCode { get; set; }
    }
}
