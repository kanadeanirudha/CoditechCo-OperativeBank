namespace Coditech.Common.API.Model
{
    public partial class BankProductModel : BaseModel
    {
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
        public string AccountType { get; set; }
    }   
}
