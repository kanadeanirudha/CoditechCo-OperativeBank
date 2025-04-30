using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankVehicleModelViewModel : BaseViewModel
    {
        public short BankVehicleModelId { get; set; }

        [Display(Name = "Vehicle Model")]
        [Required]
        public string VehicleModel { get; set; }

        //[Display(Name = "Property Name")]
        //[Required]
        public int VehicleCompanyEnumId { get; set; }
        [Display(Name = "Vehicle Company ")]
        public string VehicleCompany { get; set; }


    }
}
