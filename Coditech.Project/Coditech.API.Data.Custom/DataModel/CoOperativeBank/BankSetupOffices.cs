using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankSetupOffices
    {
        [Key]
        public short BankSetupOfficeId { get; set; }
        public short BankSetupDivisionId { get; set; }
        public string Office { get; set; }
        public string LOffice { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

