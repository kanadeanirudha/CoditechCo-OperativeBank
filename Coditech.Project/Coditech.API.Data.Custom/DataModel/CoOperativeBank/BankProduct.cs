using System.ComponentModel.DataAnnotations;
namespace Coditech.API.Data
{
    public partial class BankProduct
    {
        [Key]
        public short BankProductId { get; set; }
        public string ProductName { get; set; }
        public int AccountTypeEnumId { get; set; }
        public decimal RateOfIntrest { get; set; }
        public int MethodOfCalculatingEnumId { get; set; }
        public short InteresetPayableGLAccountMappingId { get; set; }
        public short InteresetReceivableGLAccountMappingId { get; set; }
        public string CentreCode { get; set; }
        public int InterestCalculationsPeriodicityEnumId { get; set; }
        public decimal InitialDepositAmount { get; set; }
        public decimal MinimumBalanceAmount { get; set; }
        public short BankProductGLMappingId { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}

