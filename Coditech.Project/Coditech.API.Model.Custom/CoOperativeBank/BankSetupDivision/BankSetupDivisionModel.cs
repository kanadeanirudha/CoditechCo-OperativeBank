namespace Coditech.Common.API.Model
{
    public partial class BankSetupDivisionModel : BaseModel
    {
        public short BankSetupDivisionId { get; set; }
        public short GeneralCountryMasterId { get; set; }
        public short GeneralRegionMasterId { get; set; }
        public int GeneralCityMasterId { get; set; }
        public string SetupDivision { get; set; }
    }
}
