using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model.Response;
namespace Coditech.Admin.Agents
{
    public interface IBankSavingAccountInterestPostingsAgent
    {
        /// <summary>
        /// Get list of BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSavingAccountIntrestPostingsListViewModel</returns>
        BankSavingAccountInterestPostingsListViewModel GetBankSavingAccountInterestPostingsList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsViewModel">BankSavingAccountIntrestPostingsViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankSavingAccountInterestPostingsViewModel CreateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsViewModel bankSavingAccountInterestPostingsViewModel);

        /// <summary>
        /// Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsId">bankSavingAccountIntrestPostingsId</param>
        /// <returns>Returns BankSavingAccountIntrestPostingsViewModel.</returns>
        BankSavingAccountInterestPostingsViewModel GetBankSavingAccountInterestPostings(int bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsViewModel">bankSavingAccountIntrestPostingsViewModel.</param>
        /// <returns>Returns updated bankSavingAccountIntrestPostingsViewModel</returns>
        BankSavingAccountInterestPostingsViewModel UpdateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsViewModel bankSavingAccountInterestPostingsViewModel);

        /// <summary>
        /// Delete BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsId">bankSavingAccountIntrestPostingsId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankSavingAccountInterestPostings(string bankSavingAccountInterestPostingsId, out string errorMessage);
    }
}
