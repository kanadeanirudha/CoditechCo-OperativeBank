using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankInsurancePoliciesType
    {
        [Key]
        public short BankInsurancePoliciesTypeId { get; set; }
        public string InsurancePoliciesType { get; set; }
        public string InsurancePoliciesTypeCode { get; set; }
        public int InsuranceTypeMajorEnumId { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

