using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSavingAccountInterestPostingsClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSavingAccountIntrestPostings.
        /// </summary>
        /// <returns>BankSavingAccountIntrestPostingsListResponse</returns>
        BankSavingAccountInterestPostingsListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="BankSavingAccountIntrestPostingsModel">BankSavingAccountIntrestPostingsModel.</param>
        /// <returns>Returns BankSavingAccountIntrestPostingsResponse.</returns>
        BankSavingAccountInterestPostingsResponse CreateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsModel body);

        /// <summary>
        /// Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        /// </summary>
        /// <param name="bankSavingAccountIntrestPostingsId">bankSavingAccountIntrestPostingsId</param>
        /// <returns>Returns BankSavingAccountIntrestPostingsResponse.</returns>
        BankSavingAccountInterestPostingsResponse GetBankSavingAccountInterestPostings(int bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingAccountIntrestPostings
        /// </summary>
        /// <param name="BankSavingAccountIntrestPostingsModel">BankSavingAccountIntrestPostingsModel.</param>
        /// <returns>Returns updated BankSavingAccountIntrestPostingsResponse</returns>
        BankSavingAccountInterestPostingsResponse UpdateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsModel body);

        /// <summary>
        /// Delete BankSavingAccountIntrestPostings.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankSavingAccountInterestPostings(ParameterModel body);
    }
}
