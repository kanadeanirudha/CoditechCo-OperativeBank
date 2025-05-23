namespace Coditech.Common.API.Model
{
    public partial class BankSavingsAccountClosuresModel : BaseModel
    {
        public int BankSavingsAccountClosuresId { get; set; }
        public long BankSavingsAccountId { get; set; }
        public DateTime ClosureDate { get; set; }
        public decimal ClosingBalance { get; set; }
        public string Reason { get; set; }
        public string ApprovedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
