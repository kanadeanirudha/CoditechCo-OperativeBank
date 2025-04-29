using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankMemberListViewModel : BaseViewModel
    {
        public List<BankMemberViewModel> BankMemberList { get; set; }
        public BankMemberListViewModel()
        {
            BankMemberList = new List<BankMemberViewModel>();
        }
        public string SelectedCentreCode { get; set; } = string.Empty;
    }
}
