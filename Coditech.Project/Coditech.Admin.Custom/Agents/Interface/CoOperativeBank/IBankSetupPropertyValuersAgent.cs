using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankSetupPropertyValuersAgent
    {
        /// <summary>
        /// Get list of BankSetupPropertyValuers.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSetupPropertyValuersListViewModel</returns>
        BankSetupPropertyValuersListViewModel GetPropertyValuersList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSetupPropertyValuers.
        /// </summary>
        /// <param name="bankSetupPropertyValuersViewModel"> BankSetupPropertyValuers View Model.</param>
        /// <returns>Returns created model.</returns>
        BankSetupPropertyValuersViewModel CreatePropertyValuers(BankSetupPropertyValuersViewModel bankSetupPropertyValuersViewModel);

        /// <summary>
        /// Get BankSetupPropertyValuers by bankSetupPropertyValuers.
        /// </summary>
        /// <param name="bankSetupPropertyValuers">bankSetupPropertyValuers</param>
        /// <returns>Returns BankSetupPropertyValuersViewModel.</returns>
        BankSetupPropertyValuersViewModel GetPropertyValuers(short bankSetupPropertyValuersId);

        /// <summary>
        /// Update BankSetupPropertyValuers.
        /// </summary>
        /// <param name="bankSetupPropertyValuersViewModel">BankSetupPropertyValuersViewModel.</param>
        /// <returns>Returns updated BankSetupPropertyValuersViewModel</returns>
        BankSetupPropertyValuersViewModel UpdatePropertyValuers(BankSetupPropertyValuersViewModel bankSetupPropertyValuersViewModel);

        /// <summary>
        /// Delete BankSetupPropertyValuers.
        /// </summary>
        /// <param name="bankSetupPropertyValuersId">BankSetupPropertyValuersId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeletePropertyValuers(string bankSetupPropertyValuersId, out string errorMessage);

    }
}
