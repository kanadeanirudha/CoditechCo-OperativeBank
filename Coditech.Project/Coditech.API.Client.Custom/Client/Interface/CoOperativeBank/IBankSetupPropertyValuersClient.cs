using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSetupPropertyValuersClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSetupPropertyValuers.
        /// </summary>
        /// <returns>BankSetupPropertyValuersListResponse</returns>
        BankSetupPropertyValuersListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSetupPropertyValuers.
        /// </summary>
        /// <param name="BankSetupPropertyValuersModel">BankSetupPropertyValuersModel.</param>
        /// <returns>Returns BankSetupPropertyValuersResponse.</returns>
        BankSetupPropertyValuersResponse CreatePropertyValuers(BankSetupPropertyValuersModel body);

        /// <summary>
        /// Get BankSetupPropertyValuers by bankSetupPropertyValuersId.
        /// </summary>
        /// <param name="bankSetupPropertyValuersId">BankSetupPropertyValuersId</param>
        /// <returns>Returns BankSetupPropertyValuersResponse.</returns>
        BankSetupPropertyValuersResponse GetPropertyValuers(long generalPersonAddressId);

        /// <summary>
        /// Update BankSetupPropertyValuers.
        /// </summary>
        /// <param name="BankSetupPropertyValuersModel">BankSetupPropertyValuersModel.</param>
        /// <returns>Returns updated BankSetupPropertyValuersResponse</returns>
        BankSetupPropertyValuersResponse UpdatePropertyValuers(BankSetupPropertyValuersModel body);

        /// <summary>
        /// Delete BankSetupPropertyValuers.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeletePropertyValuers(ParameterModel body);
    }
}
