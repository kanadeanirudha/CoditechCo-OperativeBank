using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankSetupMortagePropertyType
    {
        [Key]
        public short BankSetupMortagePropertyTypeId { get; set; }
        public string PropertyCode { get; set; }
        public string PropertyName { get; set; }
        public string LPropertyName { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


