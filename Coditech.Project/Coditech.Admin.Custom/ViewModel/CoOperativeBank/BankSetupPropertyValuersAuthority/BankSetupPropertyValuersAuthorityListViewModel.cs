using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupPropertyValuersAuthorityListViewModel : BaseViewModel
    {
        public List<BankSetupPropertyValuersAuthorityViewModel> BankSetupPropertyValuersAuthorityList { get; set; }
        public BankSetupPropertyValuersAuthorityListViewModel()
        {
            BankSetupPropertyValuersAuthorityList = new List<BankSetupPropertyValuersAuthorityViewModel>();
        }
    }
}
