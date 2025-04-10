using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankInsurancePoliciesTypeClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankInsurancePoliciesType.
        /// </summary>
        /// <returns>BankInsurancePoliciesTypeListResponse</returns>
        BankInsurancePoliciesTypeListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankInsurancePoliciesType.
        /// </summary>
        /// <param name="BankInsurancePoliciesTypeModel">BankInsurancePoliciesTypeModel.</param>
        /// <returns>Returns BankInsurancePoliciesTypeResponse.</returns>
        BankInsurancePoliciesTypeResponse CreateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel body);

        /// <summary>
        /// Get BankInsurancePoliciesType by bankInsurancePoliciesTypeId.
        /// </summary>
        /// <param name="bankInsurancePoliciesTypeId">bankInsurancePoliciesTypeId</param>
        /// <returns>Returns BankInsurancePoliciesTypeResponse.</returns>
        BankInsurancePoliciesTypeResponse GetBankInsurancePoliciesType(short bankInsurancePoliciesTypeId);

        /// <summary>
        /// Update BankInsurancePoliciesType
        /// </summary>
        /// <param name="BankInsurancePoliciesTypeModel">BankInsurancePoliciesTypeModel.</param>
        /// <returns>Returns updated BankInsurancePoliciesTypeResponse</returns>
        BankInsurancePoliciesTypeResponse UpdateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel body);

        /// <summary>
        /// Delete BankInsurancePoliciesType.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankInsurancePoliciesType(ParameterModel body);
    }
}
