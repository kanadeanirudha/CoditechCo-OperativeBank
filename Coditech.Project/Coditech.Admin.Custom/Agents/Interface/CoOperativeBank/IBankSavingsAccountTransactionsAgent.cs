using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Custom.Agents.Interface.CoOperativeBank
{
    public interface IBankSavingsAccountTransactionsAgent
    {
        /// <summary>
        /// Create BankSavingsAccountTransactions.
        /// </summary>
        /// <param name="bankSavingsAccountTransactionsViewModel">BankSavingsAccountTransactionsViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankSavingsAccountTransactionsViewModel CreateBankSavingsAccountTransactions(BankSavingsAccountTransactionsViewModel bankSavingsAccountTransactionsViewModel);

        /// <summary>
        /// Get BankSavingsAccountTransactions by bankSavingsAccountId.
        /// </summary>
        /// <param name="bankSavingsAccountId">bankSavingsAccountId</param>
        /// <returns>Returns BankSavingsAccountTransactionsViewModel.</returns>
        BankSavingsAccountTransactionsViewModel GetBankSavingsAccountTransactions(long bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingsAccountTransactions.
        /// </summary>
        /// <param name="BankSavingsAccountTransactionsViewModel">bankSavingsAccountTransactionsViewModel.</param>
        /// <returns>Returns updated BankSavingsAccountTransactionsViewModel</returns>
        BankSavingsAccountTransactionsViewModel UpdateBankSavingsAccountTransactions(BankSavingsAccountTransactionsViewModel bankSavingsAccountTransactionsViewModel);
    }
}
