using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSetupOfficesClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSetupOffices.
        /// </summary>
        /// <returns>BankSetupOfficesListResponse</returns>
        BankSetupOfficesListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSetupOffices.
        /// </summary>
        /// <param name="BankSetupOfficesModel">BankSetupOfficesModel.</param>
        /// <returns>Returns BankSetupOfficesResponse.</returns>
        BankSetupOfficesResponse CreateBankSetupOffices(BankSetupOfficesModel body);

        /// <summary>
        /// Get BankSetupOffices by bnkSetupOfficeId.
        /// </summary>
        /// <param name="bnkSetupOfficeId">bnkSetupOfficeId</param>
        /// <returns>Returns BankSetupOfficesResponse.</returns>
        BankSetupOfficesResponse GetBankSetupOffices(short bnkSetupOfficeId);

        /// <summary>
        /// Update BankSetupOffices
        /// </summary>
        /// <param name="BankSetupOfficesModel">BankSetupOfficesModel.</param>
        /// <returns>Returns updated BankSetupOfficesResponse</returns>
        BankSetupOfficesResponse UpdateBankSetupOffices(BankSetupOfficesModel body);

        /// <summary>
        /// Delete BankSetupOffices.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankSetupOffices(ParameterModel body);
    }
}
