using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankSetupPropertyValuersAuthorityAgent
    {
        /// <summary>
        /// Get list of BankSetupPropertyValuersAuthority.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSetupPropertyValuersAuthorityListViewModel</returns>
        BankSetupPropertyValuersAuthorityListViewModel GetPropertyValuersAuthorityList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSetupPropertyValuersAuthority.
        /// </summary>
        /// <param name="bankSetupPropertyValuersViewModel"> BankSetupPropertyValuersAuthority View Model.</param>
        /// <returns>Returns created model.</returns>
        BankSetupPropertyValuersAuthorityViewModel CreatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityViewModel bankSetupPropertyValuersAuthorityViewModel);

        /// <summary>
        /// Get BankSetupPropertyValuersAuthority by bankSetupPropertyValuersAuthority.
        /// </summary>
        /// <param name="bankSetupPropertyValuersAuthority">bankSetupPropertyValuersAuthority</param>
        /// <returns>Returns BankSetupPropertyValuersAuthorityViewModel.</returns>
        BankSetupPropertyValuersAuthorityViewModel GetPropertyValuersAuthority(short bankSetupPropertyValuersAuthorityId);

        /// <summary>
        /// Update BankSetupPropertyValuers.
        /// </summary>
        /// <param name="bankSetupPropertyValuersViewModel">BankSetupPropertyValuersViewModel.</param>
        /// <returns>Returns updated BankSetupPropertyValuersViewModel</returns>
        BankSetupPropertyValuersAuthorityViewModel UpdatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityViewModel bankSetupPropertyValuersAuthorityViewModel);

        /// <summary>
        /// Delete BankSetupPropertyValuersAuthority.
        /// </summary>
        /// <param name="bankSetupPropertyValuersAuthorityId">BankSetupPropertyValuersAuthorityId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeletePropertyValuersAuthority(string bankSetupPropertyValuersAuthorityId, out string errorMessage);

    }
}
