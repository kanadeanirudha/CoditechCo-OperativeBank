using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public class BankProductViewModel : BaseViewModel
    {
        public short BankProductId { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int AccountTypeEnumId { get; set; }
        [Required]
        [Display(Name = "Rate Of Intrest")]
        public decimal RateOfIntrest { get; set; }
        public int MethodOfCalculatingEnumId { get; set; }
        [Required]
        [Display(Name = "Payable GL Account")]
        public short InteresetPayableGLAccountMappingId { get; set; }
        [Display(Name = "Receivable GL Account")]
        public short InteresetReceivableGLAccountMappingId { get; set; }
        [Display(Name = "Centre")]
        public string CentreCode { get; set; }
        public int InterestCalculationsPeriodicityEnumId { get; set; }
        [Required]
        [Display(Name = "Initial Deposit Amount")]
        public decimal InitialDepositAmount { get; set; }
        [Required]
        [Display(Name = "Minimum Balance Amount")]
        public decimal MinimumBalanceAmount { get; set; }
        [Required]
        [Display(Name = "GL Mapper Account")]
        public short BankProductGLMappingId { get; set; }
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
        [Display(Name = "Method Of Calculating")]
        public string MethodOfCalculating { get; set; }
        [Display(Name = "Interest Calculations Periodicity")]
        public string InterestCalculationsPeriodicity { get; set; }
    }
}
