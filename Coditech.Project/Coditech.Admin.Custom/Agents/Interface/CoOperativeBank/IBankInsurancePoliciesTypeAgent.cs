using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model.Response;
namespace Coditech.Admin.Agents
{
    public interface IBankInsurancePoliciesTypeAgent
    {
        /// <summary>
        /// Get list of BankInsurancePoliciesType.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankInsurancePoliciesTypeListViewModel</returns>
        BankInsurancePoliciesTypeListViewModel GetBankInsurancePoliciesTypeList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankInsurancePoliciesType.
        /// </summary>
        /// <param name="bankInsurancePoliciesTypeViewModel">BankInsurancePoliciesTypeViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankInsurancePoliciesTypeViewModel CreateBankInsurancePoliciesType(BankInsurancePoliciesTypeViewModel bankInsurancePoliciesTypeViewModel);

        /// <summary>
        /// Get BankInsurancePoliciesType by bankInsurancePoliciesTypeId.
        /// </summary>
        /// <param name="bankInsurancePoliciesTypeId">bankInsurancePoliciesTypeId</param>
        /// <returns>Returns BankInsurancePoliciesTypeViewModel.</returns>
        BankInsurancePoliciesTypeViewModel GetBankInsurancePoliciesType(short generalFinancialYearId);

        /// <summary>
        /// Update BankInsurancePoliciesType.
        /// </summary>
        /// <param name="bankInsurancePoliciesTypeViewModel">bankInsurancePoliciesTypeViewModel.</param>
        /// <returns>Returns updated BankInsurancePoliciesTypeViewModel</returns>
        BankInsurancePoliciesTypeViewModel UpdateBankInsurancePoliciesType(BankInsurancePoliciesTypeViewModel generalFinancialYearViewModel);

        /// <summary>
        /// Delete BankInsurancePoliciesType.
        /// </summary>
        /// <param name="generalFinancialYearId">generalFinancialYearId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankInsurancePoliciesType(string bankInsurancePoliciesTypeId, out string errorMessage);
        BankInsurancePoliciesTypeListResponse GetBankInsurancePoliciesTypeList();
    }
}
