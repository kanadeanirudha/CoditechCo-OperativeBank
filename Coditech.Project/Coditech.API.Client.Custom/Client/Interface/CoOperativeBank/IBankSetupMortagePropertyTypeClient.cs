using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSetupMortagePropertyTypeClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSetupMortagePropertyType.
        /// </summary>
        /// <returns>BankSetupMortagePropertyTypeListResponse</returns>
        BankSetupMortagePropertyTypeListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSetupMortagePropertyType.
        /// </summary>
        /// <param name="BankSetupMortagePropertyTypeModel">BankSetupMortagePropertyTypeModel.</param>
        /// <returns>Returns BankSetupMortagePropertyTypeResponse.</returns>
        BankSetupMortagePropertyTypeResponse CreatePropertyType(BankSetupMortagePropertyTypeModel body);

        /// <summary>
        /// Get BankSetupMortagePropertyType by bankSetupMortagePropertyTypeId.
        /// </summary>
        /// <param name="bankSetupMortagePropertyTypeId">bankSetupMortagePropertyTypeId</param>
        /// <returns>Returns BankSetupMortagePropertyTypeResponse.</returns>
        BankSetupMortagePropertyTypeResponse GetPropertyType(short bankSetupMortagePropertyTypeId);

        /// <summary>
        /// Update BankSetupMortagePropertyType.
        /// </summary>
        /// <param name="BankSetupMortagePropertyTypeModel">BankSetupMortagePropertyTypeModel.</param>
        /// <returns>Returns updated BankSetupMortagePropertyTypeResponse</returns>
        BankSetupMortagePropertyTypeResponse UpdatePropertyType(BankSetupMortagePropertyTypeModel body);

        /// <summary>
        /// Delete BankSetupMortagePropertyType.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeletePropertyType(ParameterModel body);
    }
}
