using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model.Response;
namespace Coditech.Admin.Agents
{
    public interface IBankSavingAccountIntrestPostingsAgent
    {
        /// <summary>
        /// Get list of BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSavingAccountIntrestPostingsListViewModel</returns>
        BankSavingAccountIntrestPostingsListViewModel GetBankSavingAccountIntrestPostingsList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsViewModel">BankSavingAccountIntrestPostingsViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankSavingAccountIntrestPostingsViewModel CreateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel);

        /// <summary>
        /// Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsId">bankSavingAccountIntrestPostingsId</param>
        /// <returns>Returns BankSavingAccountIntrestPostingsViewModel.</returns>
        BankSavingAccountIntrestPostingsViewModel GetBankSavingAccountIntrestPostings(int bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsViewModel">bankSavingAccountIntrestPostingsViewModel.</param>
        /// <returns>Returns updated bankSavingAccountIntrestPostingsViewModel</returns>
        BankSavingAccountIntrestPostingsViewModel UpdateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel);

        /// <summary>
        /// Delete BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsId">bankSavingAccountIntrestPostingsId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankSavingAccountIntrestPostings(string bankSavingAccountIntrestPostingsId, out string errorMessage);
        BankSavingAccountIntrestPostingsListResponse GetBankSavingAccountIntrestPostingsList();
    }
}
