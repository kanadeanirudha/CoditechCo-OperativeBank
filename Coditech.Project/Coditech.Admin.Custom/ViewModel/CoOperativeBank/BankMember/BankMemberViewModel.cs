using Coditech.Common.Helper;
using System.ComponentModel.DataAnnotations;
namespace Coditech.Admin.ViewModel
{
    public partial class BankMemberViewModel : BaseViewModel
    {
        public int BankMemberId { get; set; }
        
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
        [Required]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }
        [Display(Name = "Account Status")]
        public int AccountStatusEnumId { get; set; }
        public long PersonId { get; set; }
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(200)]
        [Editable(false)]
        [Display(Name = "Member Code")]
        public string MemberCode { get; set; }
        public string CentreCode { get; set; }
        public string ImagePath { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
