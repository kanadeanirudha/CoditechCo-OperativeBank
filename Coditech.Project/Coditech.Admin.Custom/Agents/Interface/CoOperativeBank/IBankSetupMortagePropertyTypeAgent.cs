using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankSetupMortagePropertyTypeAgent
    {
        /// <summary>
        /// Get list of BankSetupMortagePropertyType.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankSetupMortagePropertyTypeListViewModel</returns>
        BankSetupMortagePropertyTypeListViewModel GetPropertyTypeList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankSetupMortagePropertyType.
        /// </summary>
        /// <param name="bankSetupMortagePropertyTypeViewModel"> BankSetupMortagePropertyType View Model.</param>
        /// <returns>Returns created model.</returns>
        BankSetupMortagePropertyTypeViewModel CreatePropertyType(BankSetupMortagePropertyTypeViewModel bankSetupMortagePropertyTypeViewModel);

        /// <summary>
        /// Get BankSetupMortagePropertyType by bankSetupMortagePropertyType.
        /// </summary>
        /// <param name="bankSetupMortagePropertyType">bankSetupMortagePropertyType</param>
        /// <returns>Returns BankSetupMortagePropertyTypeViewModel.</returns>
        BankSetupMortagePropertyTypeViewModel GetPropertyType(short bankSetupMortagePropertyTypeId);

        /// <summary>
        /// Update BankSetupMortagePropertyType.
        /// </summary>
        /// <param name="bankSetupMortagePropertyTypeViewModel">BankSetupMortagePropertyTypeViewModel.</param>
        /// <returns>Returns updated BankSetupMortagePropertyTypeViewModel</returns>
        BankSetupMortagePropertyTypeViewModel UpdatePropertyType(BankSetupMortagePropertyTypeViewModel bankSetupMortagePropertyTypeViewModel);

        /// <summary>
        /// Delete BankSetupMortagePropertyType.
        /// </summary>
        /// <param name="bankSetupMortagePropertyTypeId">BankSetupMortagePropertyTypeId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeletePropertyType(string bankSetupMortagePropertyTypeId, out string errorMessage);

    }
}
