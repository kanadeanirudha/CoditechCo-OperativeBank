using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSavingAccountIntrestPostingsClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSavingAccountIntrestPostings.
        /// </summary>
        /// <returns>BankSavingAccountIntrestPostingsListResponse</returns>
        BankSavingAccountIntrestPostingsListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="BankSavingAccountIntrestPostingsModel">BankSavingAccountIntrestPostingsModel.</param>
        /// <returns>Returns BankSavingAccountIntrestPostingsResponse.</returns>
        BankSavingAccountIntrestPostingsResponse CreateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel body);

        /// <summary>
        /// Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsId">bankSavingAccountIntrestPostingsId</param>
        /// <returns>Returns BankSavingAccountIntrestPostingsResponse.</returns>
        BankSavingAccountIntrestPostingsResponse GetBankSavingAccountIntrestPostings(int bankSavingAccountIntrestPostingsId);

        /// <summary>
        /// Update BankSavingAccountIntrestPostings
        /// </summary>
        /// <param name="BankSavingAccountIntrestPostingsModel">BankSavingAccountIntrestPostingsModel.</param>
        /// <returns>Returns updated BankSavingAccountIntrestPostingsResponse</returns>
        BankSavingAccountIntrestPostingsResponse UpdateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel body);

        /// <summary>
        /// Delete BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankSavingAccountIntrestPostings(ParameterModel body);
    }
}
