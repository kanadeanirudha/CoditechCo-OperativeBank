using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankMemberAgent
    {
        /// <summary>
        /// Get list of BankMember.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankMemberListViewModel</returns>
        BankMemberListViewModel GetBankMemberList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankMember.
        /// </summary>
        /// <param name="memberCreateEditViewModel"> BankMember View Model.</param>
        /// <returns>Returns created model.</returns>
        MemberCreateEditViewModel CreateBankMember(MemberCreateEditViewModel memberCreateEditViewModel);

        /// <summary>
        /// Get Member Personal Details by personId.
        /// </summary>
        /// <param name="bankMemberId">bankMemberId</param>
        /// <param name="personId">personId</param>
        /// <returns>Returns MemberCreateEditViewModel.</returns>
        MemberCreateEditViewModel GetMemberPersonalDetails(int bankMemberId, long personId);

        /// <summary>
        /// Update Member Personal Details.
        /// </summary>
        /// <param name="memberCreateEditViewModel">MemberCreateEditViewModel.</param>
        /// <returns>Returns updated MemberCreateEditViewModel</returns>
        MemberCreateEditViewModel UpdateMemberPersonalDetails(MemberCreateEditViewModel memberCreateEditViewModel);

        /// <summary>
        /// Get BankMember by bankMember.
        /// </summary>
        /// <param name="bankMemberId">bankMemberId</param>
        /// <returns>Returns BankMemberViewModel.</returns>
        BankMemberViewModel GetMemberOtherDetail(int bankMemberId);

        /// <summary>
        /// Update BankMember.
        /// </summary>
        /// <param name="bankMemberViewModel">BankMemberViewModel.</param>
        /// <returns>Returns updated BankMemberViewModel</returns>
        BankMemberViewModel UpdateMemberOtherDetail(BankMemberViewModel bankMemberViewModel);

        /// <summary>
        /// Delete BankMember.
        /// </summary>
        /// <param name="bankMemberId">BankMemberId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankMember(string bankMemberId, out string errorMessage);

    }
}
