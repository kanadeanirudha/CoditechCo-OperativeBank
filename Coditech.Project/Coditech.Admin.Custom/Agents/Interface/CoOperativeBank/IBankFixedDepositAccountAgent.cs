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

        #region BankFixedDepositClosure

        /// <summary>
        /// Create BankFixedDepositClosure.
        /// </summary>
        /// <param name="bankFixedDepositClosureViewModel">BankFixedDepositClosureViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankFixedDepositClosureViewModel CreateBankFixedDepositClosure(BankFixedDepositClosureViewModel bankFixedDepositClosureViewModel);

        /// <summary>
        /// Get BankFixedDepositClosure by bankFixedDepositAccountId.
        /// </summary>
        /// <param name="bankFixedDepositAccountId">bankFixedDepositAccountId</param>
        /// <returns>Returns BankFixedDepositAccountViewModel.</returns>
        BankFixedDepositClosureViewModel GetBankFixedDepositClosure(short bankFixedDepositAccountId);

        /// <summary>
        /// Update BankFixedDepositClosure.
        /// </summary>
        /// <param name="bankFixedDepositAccountViewModel">bankFixedDepositAccountViewModel.</param>
        /// <returns>Returns updated BankFixedDepositAccountViewModel</returns>
        BankFixedDepositClosureViewModel UpdateBankFixedDepositClosure(BankFixedDepositClosureViewModel bankFixedDepositClosureViewModel);

        #endregion
        #region BankFixedDepositInterestPostings

        /// <summary>
        /// Create BankFixedDepositInterestPostings.
        /// </summary>
        /// <param name="bankFixedDepositInterestPostingsViewModel">BankFixedDepositInterestPostingsViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankFixedDepositInterestPostingsViewModel CreateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsViewModel bankFixedDepositInterestPostingsViewModel);

        /// <summary>
        /// Get BankFixedDepositInterestPostings by bankFixedDepositAccountId.
        /// </summary>
        /// <param name="bankFixedDepositAccountId">bankFixedDepositAccountId</param>
        /// <returns>Returns BankFixedDepositInterestPostingsViewModel.</returns>
        BankFixedDepositInterestPostingsViewModel GetBankFixedDepositInterestPostings(short bankFixedDepositAccountId);

        /// <summary>
        /// Update BankFixedDepositInterestPostings.
        /// </summary>
        /// <param name="bankFixedDepositInterestPostingsViewModel">bankFixedDepositInterestPostingsViewModel.</param>
        /// <returns>Returns updated BankFixedDepositInterestPostingsViewModel</returns>
        BankFixedDepositInterestPostingsViewModel UpdateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsViewModel bankFixedDepositInterestPostingsViewModel);

        #endregion
    }
}
