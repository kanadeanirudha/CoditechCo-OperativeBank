using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
namespace Coditech.Admin.Agents
{
    public interface IBankSetupOfficesAgent
    {
        /// <summary>
        /// Get list of BankSetupOffices.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSetupOfficesListViewModel</returns>
        BankSetupOfficesListViewModel GetBankSetupOfficesList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSetupOffices.
        /// </summary>
        /// <param name="bankSetupOfficesViewModel">BankSetupOfficesViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankSetupOfficesViewModel CreateBankSetupOffices(BankSetupOfficesViewModel bankSetupOfficesViewModel);

        /// <summary>
        /// Get BankSetupOffices by bankSetupOfficeId.
        /// </summary>
        /// <param name="bankSetupOfficeId">bankSetupOfficeId</param>
        /// <returns>Returns BankSetupOfficesViewModel.</returns>
        BankSetupOfficesViewModel GetBankSetupOffices(short bankSetupOfficeId);

        /// <summary>
        /// Update BankSetupOffices.
        /// </summary>
        /// <param name="bankSetupOfficesViewModel">bankSetupOfficesViewModel.</param>
        /// <returns>Returns updated BankSetupOfficesViewModel</returns>
        BankSetupOfficesViewModel UpdateBankSetupOffices(BankSetupOfficesViewModel bankSetupOfficesViewModel);

        /// <summary>
        /// Delete BankSetupOffices.
        /// </summary>
        /// <param name="bankSetupOfficeId">bankSetupOfficeId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankSetupOffices(string bankSetupOfficeId, out string errorMessage);
        BankSetupOfficesListResponse GetBankSetupOfficesList();
    }
}
