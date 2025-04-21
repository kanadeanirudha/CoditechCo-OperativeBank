using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupPropertyValuersListViewModel : BaseViewModel
    {
        public List<BankSetupPropertyValuersViewModel> BankSetupPropertyValuersList { get; set; }
        public BankSetupPropertyValuersListViewModel()
        {
            BankSetupPropertyValuersList = new List<BankSetupPropertyValuersViewModel>();
        }
        public short BankSetupPropertyValuersId { get; set; }
        public long GeneralPersonAddressId { get; set; }
        public long PersonId { get; set; }
        public long EntityId { get; set; }
        public string EntityType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ControllerName { get; set; }
        [Display(Name = "Same as Permanent Address")]
        public bool IsCorrespondanceAddressSameAsPermanentAddress { get; set; }
    }
}
