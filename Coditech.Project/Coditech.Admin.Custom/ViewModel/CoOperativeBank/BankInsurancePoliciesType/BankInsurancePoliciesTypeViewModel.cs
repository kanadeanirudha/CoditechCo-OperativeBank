using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public class BankInsurancePoliciesTypeViewModel : BaseViewModel
    {
        public short BankInsurancePoliciesTypeId { get; set; }
        [Required]
        [Display(Name = "Insurance Policies Type")]
        public string InsurancePoliciesType { get; set; }
        [Required]
        [Display(Name = "Insurance Policies Code")]
        [RegularExpression(@"^[^0-9\s]+$", ErrorMessage = "Space and numbers are not allowed.")]
        public string InsurancePoliciesTypeCode { get; set; }
        public int InsuranceTypeMajorEnumId { get; set; }
        [Display(Name = "Insurance Type Major")]
        public string InsuranceTypeMajor { get; set; }
    }
}
