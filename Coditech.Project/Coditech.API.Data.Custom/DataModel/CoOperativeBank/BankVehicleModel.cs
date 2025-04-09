using System.ComponentModel.DataAnnotations;

namespace Coditech.API.Data
{
    public partial class BankVehicleModel
    {
        [Key]
        public short BankVehicleModelId { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleCompanyEnumId { get; set; }
   
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}


