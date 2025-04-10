using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSetupDivisionClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSetupDivision.
        /// </summary>
        /// <returns>BankSetupDivisionListResponse</returns>
        BankSetupDivisionListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSetupDivision.
        /// </summary>
        /// <param name="BankSetupDivisionModel">BankSetupDivisionModel.</param>
        /// <returns>Returns BankSetupDivisionResponse.</returns>
        BankSetupDivisionResponse CreateBankSetupDivision(BankSetupDivisionModel body);

        /// <summary>
        /// Get BankSetupDivision by bankSetupDivisionId.
        /// </summary>
        /// <param name="bankSetupDivisionId">bankSetupDivisionId</param>
        /// <returns>Returns DBTMTraineeDetailsResponse.</returns>
        BankSetupDivisionResponse GetBankSetupDivision(short bankSetupDivisionId);

        /// <summary>
        /// Update BankSetupDivision
        /// </summary>
        /// <param name="BankSetupDivisionModel">BankSetupDivisionModel.</param>
        /// <returns>Returns updated BankSetupDivisionResponse</returns>
        BankSetupDivisionResponse UpdateBankSetupDivision(BankSetupDivisionModel body);

        /// <summary>
        /// Delete BankSetupDivision.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankSetupDivision(ParameterModel body);
    }
}
