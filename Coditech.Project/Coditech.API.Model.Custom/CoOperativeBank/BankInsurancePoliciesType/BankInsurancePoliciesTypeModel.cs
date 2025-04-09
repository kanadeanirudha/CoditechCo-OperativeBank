namespace Coditech.Common.API.Model
{
    public partial class BankInsurancePoliciesTypeModel : BaseModel
    {
        public short BankInsurancePoliciesTypeId { get; set; }
        public string InsurancePoliciesType { get; set; }
        public string InsurancePoliciesTypeCode { get; set; }
        public int InsuranceTypeMajorEnumId { get; set; }
        public string InsuranceTypeMajor { get; set; }
    }
}
