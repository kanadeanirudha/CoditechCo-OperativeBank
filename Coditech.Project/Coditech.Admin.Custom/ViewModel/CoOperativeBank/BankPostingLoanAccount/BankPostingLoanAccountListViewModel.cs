using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankPostingLoanAccountListViewModel : BaseViewModel
    {
        public List<BankPostingLoanAccountViewModel> BankPostingLoanAccountList { get; set; }
        public BankPostingLoanAccountListViewModel()
        {
            BankPostingLoanAccountList = new List<BankPostingLoanAccountViewModel>();
        }
        public string SelectedParameter1 { get; set; }
        public int BankMemberId { get; set; }
        public string CentreCode { get; set; }
    }
}
