using System.ComponentModel.DataAnnotations;

namespace Coditech.Common.API.Model
{
    public partial class BankSetupPropertyValuersModel : BaseModel
    {
        public short BankSetupPropertyValuersId { get; set; }
        public long GeneralPersonAddressId { get; set; }
        public string MobileNumber { get; set; }
        public long EntityId { get; set; }
        public string EntityType { get; set; }
        public string AddressTypeEnum { get; set; }
        public long PersonId { get; set; }
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(200)]
        [Required]
        [Display(Name = "Address1")]
        public string AddressLine1 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Address2")]
        public string AddressLine2 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

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
        [MaxLength(10)]
        [Display(Name = "Postal Code")]
        public string Postalcode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public bool IsCorrespondanceAddressSameAsPermanentAddress { get; set; }
        public bool IsDefault { get; set; }
        public string ControllerName { get; set; }
    }
}
