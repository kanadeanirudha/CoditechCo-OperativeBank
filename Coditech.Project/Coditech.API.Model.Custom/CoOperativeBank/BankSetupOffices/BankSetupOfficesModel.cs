namespace Coditech.Common.API.Model
{
    public partial class BankSetupOfficesModel : BaseModel
    {
        public short BankSetupOfficeId { get; set; }
        public short BankSetupDivisionId { get; set; }
        public string Office { get; set; }
        public string LOffice { get; set; }
    }
}
