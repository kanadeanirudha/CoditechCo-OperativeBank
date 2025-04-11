using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Common.API.Model
{
    public partial class BankSetupOfficesViewModel : BaseViewModel
    {
        public short BankSetupOfficeId { get; set; }
        [Required]
        [Display(Name = "Bank Setup Division")]
        public short BankSetupDivisionId { get; set; }
        [Required]
        [Display(Name = "Office")]
        public string Office { get; set; }
        [Required]
        [Display(Name = "LOffice")]
        public string LOffice { get; set; }
    }
}
