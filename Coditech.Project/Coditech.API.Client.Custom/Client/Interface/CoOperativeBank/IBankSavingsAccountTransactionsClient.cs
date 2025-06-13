using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
namespace Coditech.API.Client
{
    public interface IBankSavingsAccountTransactionsClient : IBaseClient
    {
        /// <summary>
        /// Create BankSavingsAccountTransactions.
        /// </summary>
        /// <param name="BankSavingsAccountTransactionsModel">BankSavingsAccountTransactionsModel.</param>
        /// <returns>Returns BankSavingsAccountResponse.</returns>
        BankSavingsAccountTransactionsResponse CreateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel body);

        /// <summary>
        /// Get BankSavingsAccountTransactions by bankSavingsAccountId.
        /// </summary>
        /// <param name="bankSavingsAccountId">bankSavingsAccountId</param>
        /// <returns>Returns BankSavingsAccountTransactionsResponse.</returns>
        BankSavingsAccountTransactionsResponse GetBankSavingsAccountTransactions(long bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingsAccountTransactions
        /// </summary>
        /// <param name="BankSavingsAccountTransactionsModel">BankSavingsAccountTransactionsModel.</param>
        /// <returns>Returns updated BankSavingsAccountTransactionsResponse</returns>
        BankSavingsAccountTransactionsResponse UpdateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel body);
    }
}
