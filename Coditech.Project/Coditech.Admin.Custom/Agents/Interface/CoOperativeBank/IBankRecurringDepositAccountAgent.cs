using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankRecurringDepositAccountAgent
    {
        /// <summary>
        /// Get list of BankRecurringDepositAccount.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankRecurringDepositAccountListViewModel</returns>
        BankRecurringDepositAccountListViewModel GetBankRecurringDepositAccountList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankRecurringDepositAccount.
        /// </summary>
        /// <param name="bankRecurringDepositAccountViewModel">BankRecurringDepositAccountViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankRecurringDepositAccountViewModel CreateBankRecurringDepositAccount(BankRecurringDepositAccountViewModel bankRecurringDepositAccountViewModel);

        /// <summary>
        /// Get BankRecurringDepositAccount by bankRecurringDepositAccountId.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId</param>
        /// <returns>Returns BankRecurringDepositAccountViewModel.</returns>
        BankRecurringDepositAccountViewModel GetBankRecurringDepositAccount(int bankRecurringDepositAccountId);

        /// <summary>
        /// Update BankRecurringDepositAccount.
        /// </summary>
        /// <param name="bankRecurringDepositAccountViewModel">bankRecurringDepositAccountViewModel.</param>
        /// <returns>Returns updated BankRecurringDepositAccountViewModel</returns>
        BankRecurringDepositAccountViewModel UpdateBankRecurringDepositAccount(BankRecurringDepositAccountViewModel bankRecurringDepositAccountModel);

        /// <summary>
        /// Delete BankRecurringDepositAccount.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankRecurringDepositAccount(string bankRecurringDepositAccountId, out string errorMessage);

        #region BankRecurringDepositClosure

        /// <summary>
        /// Create BankRecurringDepositClosure.
        /// </summary>
        /// <param name="bankRecurringDepositClosureViewModel">BankRecurringDepositClosureViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankRecurringDepositClosureViewModel CreateBankRecurringDepositClosure(BankRecurringDepositClosureViewModel bankRecurringDepositClosureViewModel);

        /// <summary>
        /// Get BankRecurringDepositClosure by bankRecurringDepositAccountId.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId</param>
        /// <returns>Returns BankRecurringDepositClosureViewModel.</returns>
        BankRecurringDepositClosureViewModel GetBankRecurringDepositClosure(int bankRecurringDepositAccountId);

        /// <summary>
        /// Update BankRecurringDepositClosure.
        /// </summary>
        /// <param name="BankRecurringDepositClosureViewModel">BankRecurringDepositClosureViewModel.</param>
        /// <returns>Returns updated BankRecurringDepositClosureViewModel</returns>
        BankRecurringDepositClosureViewModel UpdateBankRecurringDepositClosure(BankRecurringDepositClosureViewModel bankRecurringDepositClosureModel);
        #endregion 
        // BankRecurringDepositAccountListResponse GetBankRecurringDepositAccountList();


        #region BankRecurringDepositInterestPosting

        /// <summary>
        /// Create BankRecurringDepositInterestPosting.
        /// </summary>
        /// <param name="bankRecurringDepositInterestPostingViewModel">BankRecurringDepositInterestPostingViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankRecurringDepositInterestPostingViewModel CreateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingViewModel bankRecurringDepositInterestPostingViewModel);

        /// <summary>
        /// Get BankRecurringDepositInterestPosting by bankRecurringDepositAccountId.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId</param>
        /// <returns>Returns BankRecurringDepositInterestPostingViewModel.</returns>
        BankRecurringDepositInterestPostingViewModel GetBankRecurringDepositInterestPosting(int bankRecurringDepositAccountId);

        /// <summary>
        /// Update BankRecurringDepositInterestPosting.
        /// </summary>
        /// <param name="bankRecurringDepositInterestPostingViewModel">bankRecurringDepositInterestPostingViewModel.</param>
        /// <returns>Returns updated BankRecurringDepositInterestPostingViewModel</returns>
        BankRecurringDepositInterestPostingViewModel UpdateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingViewModel bankRecurringDepositInterestPostingViewModel);


        #endregion
    }
}
