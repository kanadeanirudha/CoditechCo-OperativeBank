using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankFixedDepositAccountAgent
    {
        /// <summary>
        /// Get list of BankFixedDepositAccount.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankFixedDepositAccountListViewModel</returns>
        BankFixedDepositAccountListViewModel GetBankFixedDepositAccountList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankFixedDepositAccount.
        /// </summary>
        /// <param name="bankFixedDepositAccountViewModel">BankFixedDepositAccountViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankFixedDepositAccountViewModel CreateBankFixedDepositAccount(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel);

        /// <summary>
        /// Get BankFixedDepositAccount by bankFixedDepositAccountId.
        /// </summary>
        /// <param name="bankFixedDepositAccountId">bankFixedDepositAccountId</param>
        /// <returns>Returns BankFixedDepositAccountViewModel.</returns>
        BankFixedDepositAccountViewModel GetBankFixedDepositAccount(short bankFixedDepositAccountId);

        /// <summary>
        /// Update BankFixedDepositAccount.
        /// </summary>
        /// <param name="bankFixedDepositAccountViewModel">bankFixedDepositAccountViewModel.</param>
        /// <returns>Returns updated BankFixedDepositAccountViewModel</returns>
        BankFixedDepositAccountViewModel UpdateBankFixedDepositAccount(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel);

        /// <summary>
        /// Delete BankFixedDepositAccount.
        /// </summary>
        /// <param name="bankFixedDepositAccountId">bankFixedDepositAccountId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankFixedDepositAccount(string bankFixedDepositAccountId, out string errorMessage);
    }
}
