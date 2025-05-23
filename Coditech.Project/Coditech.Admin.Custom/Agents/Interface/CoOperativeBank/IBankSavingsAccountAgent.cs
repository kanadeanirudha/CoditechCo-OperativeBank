using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model.Response;
namespace Coditech.Admin.Agents
{
    public interface IBankSavingsAccountAgent
    {
        /// <summary>
        /// Get list of BankSavingsAccount.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSavingsAccountListViewModel</returns>
        BankSavingsAccountListViewModel GetBankSavingsAccountList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSavingsAccount.
        /// </summary>
        /// <param name="bankSavingsAccountViewModel">BankSavingsAccountViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankSavingsAccountViewModel CreateBankSavingsAccount(BankSavingsAccountViewModel bankSavingsAccountViewModel);

        /// <summary>
        /// Get BankSavingsAccount by bankSavingsAccountId.
        /// </summary>
        /// <param name="bankSavingsAccountId">bankSavingsAccountId</param>
        /// <returns>Returns BankSavingsAccountViewModel.</returns>
        BankSavingsAccountViewModel GetBankSavingsAccount(long bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingsAccount.
        /// </summary>
        /// <param name="bankSavingsAccountViewModel">bankSavingsAccountViewModel.</param>
        /// <returns>Returns updated BankSavingsAccountViewModel</returns>
        BankSavingsAccountViewModel UpdateBankSavingsAccount(BankSavingsAccountViewModel bankSavingsAccountViewModel);

        /// <summary>
        /// Delete BankSavingsAccount.
        /// </summary>
        /// <param name="bankSavingsAccountId">bankSavingsAccountId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankSavingsAccount(string bankSavingsAccountId, out string errorMessage);
        /// <summary>
        /// Get BankSavingsAccountClosures by bankSavingsAccountId.
        /// </summary>
        /// <param name="bankSavingsAccountId">bankSavingsAccountId</param>
        /// <returns>Returns BankSavingsAccountClosuresViewModel.</returns>
        BankSavingsAccountClosuresViewModel GetBankSavingsAccountClosures(long bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingsAccountClosures.
        /// </summary>
        /// <param name="bankSavingsAccountClosuresViewModel">bankSavingsAccountClosuresViewModel.</param>
        /// <returns>Returns updated BankSavingsAccountClosuresViewModel</returns>
        BankSavingsAccountClosuresViewModel UpdateBankSavingsAccountClosures(BankSavingsAccountClosuresViewModel bankSavingsAccountClosuresViewModel);
        BankSavingsAccountListResponse GetBankSavingsAccountList();
        BankSavingsAccountClosuresViewModel CreateBankSavingsAccountClosures(BankSavingsAccountClosuresViewModel bankSavingsAccountClosuresViewModel);
    }
}
