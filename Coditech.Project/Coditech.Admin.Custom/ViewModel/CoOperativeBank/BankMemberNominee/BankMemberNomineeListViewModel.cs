using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public partial class BankMemberNomineeListViewModel : BaseViewModel
    {
        public List<BankMemberNomineeViewModel> BankMemberNomineeList { get; set; }
        public BankMemberNomineeListViewModel()
        {
            BankMemberNomineeList = new List<BankMemberNomineeViewModel>();
        }
        public string SelectedCentreCode { get; set; } = string.Empty;

    }
}
