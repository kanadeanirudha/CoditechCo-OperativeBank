namespace Coditech.Common.API.Model
{
    public partial class BankSetupPropertyValuersAuthorityModel : BaseModel
    {
        public short BankSetupPropertyValuersAuthorityId { get; set; }
        public short BankSetupMortagePropertyTypeId { get; set; }
        public decimal FromPropertyValueRangeStart { get; set; }
        public decimal FromPropertyValueRangeEnd { get; set; }
        public string PropertyName { get; set; }
        
    }
}
