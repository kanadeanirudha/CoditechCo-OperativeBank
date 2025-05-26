namespace Coditech.Common.API.Model
{
    public partial class BankPostingLoanAccountListModel : BaseListModel
    {
        public List<BankPostingLoanAccountModel> BankPostingLoanAccountList { get; set; }
        public BankPostingLoanAccountListModel()
        {
            BankPostingLoanAccountList = new List<BankPostingLoanAccountModel>();
        }
    }
}
