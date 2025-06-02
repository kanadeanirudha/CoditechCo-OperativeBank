using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankMemberShareCapitalClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankMemberShareCapital.
        /// </summary>
        /// <returns>BankMemberShareCapitalListResponse</returns>
        BankMemberShareCapitalListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankMemberShareCapital.
        /// </summary>
        /// <param name="BankMemberShareCapitalModel">BankMemberShareCapitalModel.</param>
        /// <returns>Returns BankMemberShareCapitalResponse.</returns>
        BankMemberShareCapitalResponse CreateMemberShareCapital(BankMemberShareCapitalModel body);

        /// <summary>
        /// Get BankMemberShareCapital by bankMemberShareCapitalId.
        /// </summary>
        /// <param name="bankMemberShareCapitalId">BankMemberShareCapitalId</param>
        /// <returns>Returns BankMemberShareCapitalResponse.</returns>
        BankMemberShareCapitalResponse GetMemberShareCapital(int bankMemberId);

        /// <summary>
        /// Update BankMemberShareCapital.
        /// </summary>
        /// <param name="BankMemberShareCapitalModel">BankMemberShareCapitalModel.</param>
        /// <returns>Returns updated BankMemberShareCapitalResponse</returns>
        BankMemberShareCapitalResponse UpdateMemberShareCapital(BankMemberShareCapitalModel body);

        /// <summary>
        /// Delete BankMemberShareCapital.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteMemberShareCapital(ParameterModel body);
    }
}
