using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankSetupPropertyValuers
    {
        [Key]

        public short BankSetupPropertyValuersId { get; set; }
        public long GeneralPersonAddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


