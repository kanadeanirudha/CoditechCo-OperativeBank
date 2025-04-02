using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupMortagePropertyTypeViewModel : BaseViewModel
    {
        public short BankSetupMortagePropertyTypeId { get; set; }

        [Display(Name = "PropertyCode")]
        [Required]
        public string PropertyCode { get; set; }

        [Display(Name = "PropertyName")]
        [Required]
        public string PropertyName { get; set; }
        [Display(Name = "LPropertyName")]
        [Required]
        public string LPropertyName { get; set; }

    }
}
