using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankMemberNomineeAgent
    {
        /// <summary>
        /// Get list of BankMemberNominee.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankMemberNomineeListViewModel</returns>
        BankMemberNomineeListViewModel GetMemberNomineeList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankMemberNominee.
        /// </summary>
        /// <param name="bankMemberNomineeViewModel"> BankMemberNominee View Model.</param>
        /// <returns>Returns created model.</returns>
        BankMemberNomineeViewModel CreateMemberNominee(BankMemberNomineeViewModel bankMemberNomineeViewModel);

        /// <summary>
        /// Get BankMemberNominee by bankMemberNominee.
        /// </summary>
        /// <param name="bankMemberNominee">bankMemberNominee</param>
        /// <returns>Returns BankMemberNomineeViewModel.</returns>
        BankMemberNomineeViewModel GetMemberNominee(int bankMemberNomineeId);

        /// <summary>
        /// Update BankMemberNominee.
        /// </summary>
        /// <param name="bankMemberNomineeViewModel">BankMemberNomineeViewModel.</param>
        /// <returns>Returns updated BankMemberNomineeViewModel</returns>
        BankMemberNomineeViewModel UpdateMemberNominee(BankMemberNomineeViewModel bankMemberNomineeViewModel);

        /// <summary>
        /// Delete BankMemberNominee.
        /// </summary>
        /// <param name="bankMemberNomineeId">BankMemberNomineeId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteMemberNominee(string bankMemberNomineeId, out string errorMessage);

    }
}
