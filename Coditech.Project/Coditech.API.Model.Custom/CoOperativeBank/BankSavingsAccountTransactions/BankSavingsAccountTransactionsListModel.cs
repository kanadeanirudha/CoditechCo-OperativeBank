namespace Coditech.Common.API.Model
{
    public partial class BankSavingsAccountTransactionsListModel : BaseListModel
    {
        public List<BankSavingsAccountTransactionsModel> BankSavingsAccountTransactionsList { get; set; }
        public BankSavingsAccountTransactionsListModel()
        {
            BankSavingsAccountTransactionsList = new List<BankSavingsAccountTransactionsModel>();
        }
    }
}
