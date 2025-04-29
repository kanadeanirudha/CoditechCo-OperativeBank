using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankMemberClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankMember.
        /// </summary>
        /// <returns>BankMemberListResponse</returns>
        BankMemberListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankMember.
        /// </summary>
        /// <param name="BankMemberModel">BankMemberModel.</param>
        /// <returns>Returns BankMemberResponse.</returns>
        BankMemberResponse CreateBankMember(BankMemberModel body);

        /// <summary>
        /// Get BankMember by bankMemberId.
        /// </summary>
        /// <param name="bankMemberId">BankMemberId</param>
        /// <returns>Returns BankMemberResponse.</returns>
        BankMemberResponse GetBankMember(int bankMemberId);

        /// <summary>
        /// Update BankMember.
        /// </summary>
        /// <param name="BankMemberModel">BankMemberModel.</param>
        /// <returns>Returns updated BankMemberResponse</returns>
        BankMemberResponse UpdateBankMember(BankMemberModel body);

        /// <summary>
        /// Delete BankMember.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankMember(ParameterModel body);
    }
}
