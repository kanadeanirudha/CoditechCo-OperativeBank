using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSetupPropertyValuersAuthorityClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSetupPropertyValuersAuthority.
        /// </summary>
        /// <returns>BankSetupPropertyValuersAuthorityListResponse</returns>
        BankSetupPropertyValuersAuthorityListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSetupPropertyValuersAuthority.
        /// </summary>
        /// <param name="BankSetupPropertyValuersAuthorityModel">BankSetupPropertyValuersAuthorityModel.</param>
        /// <returns>Returns BankSetupPropertyValuersResponse.</returns>
        BankSetupPropertyValuersAuthorityResponse CreatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel body);

        /// <summary>
        /// Get BankSetupPropertyValuersAuthority by bankSetupPropertyValuersAuthorityId.
        /// </summary>
        /// <param name="bankSetupPropertyValuersAuthorityId">BankSetupPropertyValuersAuthorityId</param>
        /// <returns>Returns BankSetupPropertyValuersAuthorityResponse.</returns>
        BankSetupPropertyValuersAuthorityResponse GetPropertyValuersAuthority(short bankSetupPropertyValuersAuthorityId);

        /// <summary>
        /// Update BankSetupPropertyValuersAuthority.
        /// </summary>
        /// <param name="BankSetupPropertyValuersAuthorityModel">BankSetupPropertyValuersAuthorityModel.</param>
        /// <returns>Returns updated BankSetupPropertyValuersAuthorityResponse</returns>
        BankSetupPropertyValuersAuthorityResponse UpdatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel body);

        /// <summary>
        /// Delete BankSetupPropertyValuers.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeletePropertyValuersAuthority(ParameterModel body);
    }
}
