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
        BankPostingLoanAccountListViewModel GetBankPostingLoanAccountList(string centreCode,int bankMemberId);

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

        #region BankLoanForeClosures

        /// <summary>
        /// Create BankLoanForeClosures.
        /// </summary>
        /// <param name="bankLoanForeClosuresViewModel"> BankLoanForeClosures View Model.</param>
        /// <returns>Returns created model.</returns>
        BankLoanForeClosuresViewModel CreateBankLoanForeClosures(BankLoanForeClosuresViewModel bankLoanForeClosuresViewModel);

        /// <summary>
        /// Get BankLoanForeClosures by BankLoanForeClosures.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId</param>
        /// <returns>Returns BankLoanForeClosuresViewModel.</returns>
        BankLoanForeClosuresViewModel GetBankLoanForeClosures(int bankPostingLoanAccountId);

        /// <summary>
        /// Update BankLoanForeClosures.
        /// </summary>
        /// <param name="bankLoanForeClosuresViewModel">BankLoanForeClosuresViewModel.</param>
        /// <returns>Returns updated BankLoanForeClosuresViewModel</returns>
        BankLoanForeClosuresViewModel UpdateBankLoanForeClosures(BankLoanForeClosuresViewModel bankLoanForeClosuresViewModel);
        #endregion

        /// <summary>
        /// Get BankLoanRepayment by BankLoanRepayment.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId</param>
        /// <returns>Returns BankLoanRepaymentViewModel.</returns>
        BankLoanRepaymentViewModel GetLoanRepayment(int bankPostingLoanAccountId);

        /// <summary>
        /// Update BankLoanRepayment.
        /// </summary>
        /// <param name="bankLoanRepaymentViewModel">BankLoanRepaymentViewModel.</param>
        /// <returns>Returns updated BankLoanRepaymentViewModel</returns>
        BankLoanRepaymentViewModel UpdateLoanRepayment(BankLoanRepaymentViewModel bankLoanRepaymentViewModel);
    }
}
