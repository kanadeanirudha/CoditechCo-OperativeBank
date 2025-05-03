using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public partial class BankMemberShareCapitalListViewModel : BaseViewModel
    {
        public List<BankMemberShareCapitalViewModel> BankMemberShareCapitalList { get; set; }
        public BankMemberShareCapitalListViewModel()
        {
            BankMemberShareCapitalList = new List<BankMemberShareCapitalViewModel>();
        }
    }
}
