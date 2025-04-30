using Coditech.Common.Helper;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupMortagePropertyTypeListViewModel : BaseViewModel
    {
        public List<BankSetupMortagePropertyTypeViewModel> BankSetupMortagePropertyTypeList { get; set; }
        public BankSetupMortagePropertyTypeListViewModel()
        {
            BankSetupMortagePropertyTypeList = new List<BankSetupMortagePropertyTypeViewModel>();
        }
    }
}
