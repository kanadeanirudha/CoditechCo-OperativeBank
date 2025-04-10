using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankSetupDivision
    {
        [Key]
        public short BankSetupDivisionId { get; set; }
        public short GeneralCountryMasterId { get; set; }
        public short GeneralRegionMasterId { get; set; }
        public int GeneralCityMasterId { get; set; }
        public string SetupDivision { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

