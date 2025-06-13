namespace Coditech.Common.API.Model.Response
{
    public class BankSavingsAccountTransactionsListResponse : BaseListResponse
    {
        public List<BankSavingsAccountTransactionsModel> BankSavingsAccountTransactionsList { get; set; }
    }
}
