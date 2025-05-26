using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankMemberNomineeClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankMemberNominee.
        /// </summary>
        /// <returns>BankMemberNomineeListResponse</returns>
        BankMemberNomineeListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankMemberNominee.
        /// </summary>
        /// <param name="BankMemberNomineeModel">BankMemberNomineeModel.</param>
        /// <returns>Returns BankMemberNomineeResponse.</returns>
        BankMemberNomineeResponse CreateMemberNominee(BankMemberNomineeModel body);

        /// <summary>
        /// Get BankMemberNominee by bankMemberNomineeId.
        /// </summary>
        /// <param name="bankMemberNomineeId">BankMemberNomineeId</param>
        /// <returns>Returns BankMemberNomineeResponse.</returns>
        BankMemberNomineeResponse GetMemberNominee(int bankMemberId);

        /// <summary>
        /// Update BankMemberNominee.
        /// </summary>
        /// <param name="BankMemberNomineeModel">BankMemberNomineeModel.</param>
        /// <returns>Returns updated BankMemberNomineeResponse</returns>
        BankMemberNomineeResponse UpdateMemberNominee(BankMemberNomineeModel body);

        /// <summary>
        /// Delete BankMemberNominee.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteMemberNominee(ParameterModel body);
    }
}
