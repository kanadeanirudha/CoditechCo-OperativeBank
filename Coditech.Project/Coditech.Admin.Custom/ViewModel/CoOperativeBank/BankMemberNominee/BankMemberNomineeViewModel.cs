using Coditech.Common.Helper;
using Coditech.Resources;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
namespace Coditech.Admin.ViewModel
{
    public partial class BankMemberNomineeViewModel : BaseViewModel
    {
        public int BankMemberNomineeId { get; set; }

        public long PersonId { get; set; }
        [Display(Name = "Bank Member")]
        public int BankMemberId { get; set; }
        [Display(Name = "First Name   ")]
        [Required]

        public string FirstName { get; set; }
        [Display(Name = "Last Name   ")]
        [Required]

        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "PAN Card Number")]
        [RegularExpression(@"^[A-Z]{5}[0-9]{4}[A-Z]$", ErrorMessage = "Please Enter Valid PAN Card Details.")]

        public string PANCardNumber { get; set; }
        [Required]
        [MaxLength(12)]
        [MinLength(12)]
        [Display(Name = "Aadhaar Card Number")]
        [RegularExpression(@"^\d{12}", ErrorMessage = "The Aadhaar Card Number Must Be Exactly 12 Digit Long.")]

        public string AadharCardNumber { get; set; }


        [Display(Name = "Relation Type ")]
        public int RelationTypeEnumId { get; set; }

        [Display(Name = "Percentage Of Shares ")]
        [Required]
        public decimal PercentageShare { get; set; }
        [Display(Name = "Centre")]
       
        public string CentreCode { get; set; }

    }
}
