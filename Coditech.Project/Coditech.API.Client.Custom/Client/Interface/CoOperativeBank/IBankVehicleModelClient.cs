using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankVehicleModelClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankVehicleModel.
        /// </summary>
        /// <returns>BankVehicleModelListResponse</returns>
        BankVehicleModelListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankVehicleModel.
        /// </summary>
        /// <param name="BankVehicleModelModel">BankVehicleModelModel.</param>
        /// <returns>Returns BankVehicleModelResponse.</returns>
        BankVehicleModelResponse CreateVehicleModel(BankVehicleModelModel body);

        /// <summary>
        /// Get BankVehicleModel by bankVehicleModelId.
        /// </summary>
        /// <param name="bankVehicleModelId">bankVehicleModelId</param>
        /// <returns>Returns BankVehicleModelResponse.</returns>
        BankVehicleModelResponse GetVehicleModel(short bankVehicleModelId);

        /// <summary>
        /// Update BankVehicleModel.
        /// </summary>
        /// <param name="BankVehicleModelModel">BankVehicleModelModel.</param>
        /// <returns>Returns updated BankVehicleModelResponse</returns>
        BankVehicleModelResponse UpdateVehicleModel(BankVehicleModelModel body);

        /// <summary>
        /// Delete BankVehicleModel.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteVehicleModel(ParameterModel body);
    }
}
