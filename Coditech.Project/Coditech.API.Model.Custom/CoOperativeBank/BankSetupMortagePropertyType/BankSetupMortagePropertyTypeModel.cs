namespace Coditech.Common.API.Model
{
    public partial class BankSetupMortagePropertyTypeModel : BaseModel
    {
        public short BankSetupMortagePropertyTypeId { get; set; }
        public string PropertyCode { get; set; }
        public string PropertyName { get; set; }
        public string LPropertyName { get; set; }
    }
}
