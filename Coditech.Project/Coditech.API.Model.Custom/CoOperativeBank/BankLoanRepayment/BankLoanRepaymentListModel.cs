namespace Coditech.Common.API.Model
{
    public partial class BankLoanRepaymentListModel : BaseListModel
    {
        public List<BankLoanRepaymentModel> BankLoanRepaymentList { get; set; }
        public BankLoanRepaymentListModel()
        {
            BankLoanRepaymentList = new List<BankLoanRepaymentModel>();
        }
    }
}
