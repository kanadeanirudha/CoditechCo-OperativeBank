using Coditech.Common.API.Model;
namespace Coditech.API.Service
{
    public interface IBankSavingsAccountTransactionsService
    {
        BankSavingsAccountTransactionsModel CreateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel model);
        BankSavingsAccountTransactionsModel GetBankSavingsAccountTransactions(long bankSavingsAccountId);
        bool UpdateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel model);
    }
}
