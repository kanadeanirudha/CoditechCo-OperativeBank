using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankPostingLoanAccountAgent
    {
        /// <summary>
        /// Get list of BankPostingLoanAccount.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankPostingLoanAccountListViewModel</returns>
        BankPostingLoanAccountListViewModel GetBankPostingLoanAccountList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankPostingLoanAccount.
        /// </summary>
        /// <param name="bankPostingLoanAccountViewModel"> BankPostingLoanAccount View Model.</param>
        /// <returns>Returns created model.</returns>
        BankPostingLoanAccountViewModel CreatePostingLoanAccount(BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel);

        /// <summary>
        /// Get BankPostingLoanAccount by BankPostingLoanAccount.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId</param>
        /// <returns>Returns BankPostingLoanAccountViewModel.</returns>
        BankPostingLoanAccountViewModel GetPostingLoanAccount(int bankPostingLoanAccountId);

        /// <summary>
        /// Update BankPostingLoanAccount.
        /// </summary>
        /// <param name="bankPostingLoanAccountViewModel">BankPostingLoanAccountViewModel.</param>
        /// <returns>Returns updated BankPostingLoanAccountViewModel</returns>
        BankPostingLoanAccountViewModel UpdatePostingLoanAccount(BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel);

        /// <summary>
        /// Delete BankPostingLoanAccount.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeletePostingLoanAccount(string bankPostingLoanAccountId, out string errorMessage);

    }
}
