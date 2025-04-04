using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupMortagePropertyTypeViewModel : BaseViewModel
    {
        public short BankSetupMortagePropertyTypeId { get; set; }

        [Display(Name = "Property Code")]
        [Required]
        public string PropertyCode { get; set; }

        [Display(Name = "Property Name")]
        [Required]
        public string PropertyName { get; set; }
        [Display(Name = "LProperty Name")]
        [Required]
        public string LPropertyName { get; set; }

    }
}
