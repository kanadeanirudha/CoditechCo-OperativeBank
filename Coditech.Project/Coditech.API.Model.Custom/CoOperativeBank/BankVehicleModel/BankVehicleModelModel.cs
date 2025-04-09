namespace Coditech.Common.API.Model
{
    public partial class BankVehicleModelModel : BaseModel
    {
        public short BankVehicleModelId { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleCompanyEnumId { get; set; }
        public string VehicleCompany { get; set; }
      
    }
}
