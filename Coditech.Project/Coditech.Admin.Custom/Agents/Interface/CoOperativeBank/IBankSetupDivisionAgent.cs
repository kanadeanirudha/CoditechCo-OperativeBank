using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
namespace Coditech.Admin.Agents
{
    public interface IBankSetupDivisionAgent
    {
        /// <summary>
        /// Get list of BankSetupDivision.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSetupDivisionListViewModel</returns>
        BankSetupDivisionListViewModel GetBankSetupDivisionList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSetupDivision.
        /// </summary>
        /// <param name="bankSetupDivisionViewModel">BankSetupDivisionViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankSetupDivisionViewModel CreateBankSetupDivision(BankSetupDivisionViewModel bankSetupDivisionViewModel);

        /// <summary>
        /// Get BankSetupDivision by bankSetupDivisionId.
        /// </summary>
        /// <param name="bankSetupDivisionId">bankSetupDivisionId</param>
        /// <returns>Returns BankSetupDivisionViewModel.</returns>
        BankSetupDivisionViewModel GetBankSetupDivision(short bankSetupDivisionId);

        /// <summary>
        /// Update BankSetupDivision.
        /// </summary>
        /// <param name="bankSetupDivisionViewModel">bankSetupDivisionViewModel.</param>
        /// <returns>Returns updated BankSetupDivisionViewModel</returns>
        BankSetupDivisionViewModel UpdateBankSetupDivision(BankSetupDivisionViewModel bankSetupDivisionModel);

        /// <summary>
        /// Delete BankSetupDivision.
        /// </summary>
        /// <param name="bankSetupDivisionId">bankSetupDivisionId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankSetupDivision(string bankSetupDivisionId, out string errorMessage);
        BankSetupDivisionListResponse GetBankSetupDivisionList();
    }
}
