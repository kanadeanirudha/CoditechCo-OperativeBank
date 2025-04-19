using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankSetupPropertyValuersAuthority
    {
        [Key]
        public short BankSetupPropertyValuersAuthorityId { get; set; }
        public short BankSetupMortagePropertyTypeId { get; set; }
        public decimal FromPropertyValueRangeStart { get; set; }
        public decimal FromPropertyValueRangeEnd { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


