using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankSetupPropertyValuersAuthorityViewModel : BaseViewModel
    {
        public short BankSetupPropertyValuersAuthorityId { get; set; }

        [Display(Name = "Mortage Property Type ")]
        [Required]
        public short BankSetupMortagePropertyTypeId { get; set; }
        [Display(Name = "Property Value Range Start ")]
        [Required]
        public decimal FromPropertyValueRangeStart { get; set; }
        [Display(Name = "Property Value Range End")]
        [Required]
        public decimal FromPropertyValueRangeEnd { get; set; }
        public string PropertyName {  get; set; }



    }
}
