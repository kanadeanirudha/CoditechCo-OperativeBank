using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupPropertyValuersViewModel : BaseViewModel
    {
        public short BankSetupPropertyValuersId { get; set; }

        [Display(Name = " Person's Address")]
        [Required]
        public long GeneralPersonAddressId { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        [Required]
        public string MiddleName { get; set; }

        [Display(Name = "Mobile Number ")]
        [Required]
        public string MobileNumber { get; set; }

    }
}
