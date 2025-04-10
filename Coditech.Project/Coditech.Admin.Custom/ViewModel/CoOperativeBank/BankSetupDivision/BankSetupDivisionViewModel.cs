using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;

namespace Coditech.Common.API.Model
{
    public partial class BankSetupDivisionViewModel : BaseViewModel
    {
        public short BankSetupDivisionId { get; set; }
        [Required]
        [Display(Name = "Country")]
        public short GeneralCountryMasterId { get; set; }
        [Required]
        [Display(Name = "Region")]
        public short GeneralRegionMasterId { get; set; }
        [Required]
        [Display(Name = "City")]
        public int GeneralCityMasterId { get; set; }
        [Required]
        [Display(Name = "Bank Setup Division")]
        public string SetupDivision { get; set; }
    }
}
