namespace Coditech.Common.API.Model
{
    public partial class BankSavingsAccountListModel : BaseListModel
    {
        public List<BankSavingsAccountModel> BankSavingsAccountList { get; set; }
        public BankSavingsAccountListModel()
        {
            BankSavingsAccountList = new List<BankSavingsAccountModel>();
        }
    }
}
