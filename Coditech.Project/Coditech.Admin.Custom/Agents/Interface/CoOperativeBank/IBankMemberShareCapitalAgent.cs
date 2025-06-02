using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankMemberShareCapitalAgent
    {
        /// <summary>
        /// Get list of BankMemberShareCapital.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankMemberShareCapitalListViewModel</returns>
        BankMemberShareCapitalListViewModel GetMemberShareCapitalList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankMemberShareCapital.
        /// </summary>
        /// <param name="bankMemberShareCapitalViewModel"> BankMemberShareCapital View Model.</param>
        /// <returns>Returns created model.</returns>
        BankMemberShareCapitalViewModel CreateMemberShareCapital(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel);

        /// <summary>
        /// Get BankMemberShareCapital by bankMemberShareCapital.
        /// </summary>
        /// <param name="bankMemberShareCapital">bankMemberShareCapital</param>
        /// <returns>Returns BankMemberShareCapitalViewModel.</returns>
        BankMemberShareCapitalViewModel GetMemberShareCapital(int bankMemberId);

        /// <summary>
        /// Update BankMemberShareCapital.
        /// </summary>
        /// <param name="bankMemberShareCapitalViewModel">BankMemberShareCapitalViewModel.</param>
        /// <returns>Returns updated BankMemberShareCapitalViewModel</returns>
        BankMemberShareCapitalViewModel UpdateMemberShareCapital(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel);

        /// <summary>
        /// Delete BankMemberShareCapital.
        /// </summary>
        /// <param name="bankMemberShareCapitalId">BankMemberShareCapitalId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteMemberShareCapital(string bankMemberShareCapitalId, out string errorMessage);

    }
}
