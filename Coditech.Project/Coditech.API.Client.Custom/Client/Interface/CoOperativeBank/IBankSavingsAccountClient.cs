using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankSavingsAccountClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankSavingsAccount.
        /// </summary>
        /// <returns>BankSavingsAccountListResponse</returns>
        BankSavingsAccountListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankSavingsAccount.
        /// </summary>
        /// <param name="BankSavingsAccountModel">BankSavingsAccountModel.</param>
        /// <returns>Returns BankSavingsAccountResponse.</returns>
        BankSavingsAccountResponse CreateBankSavingsAccount(BankSavingsAccountModel body);

        /// <summary>
        /// Get BankSavingsAccount by bankSavingsAccountId.
        /// </summary>
        /// <param name="bankSavingsAccountId">bankSavingsAccountId</param>
        /// <returns>Returns BankSavingsAccountResponse.</returns>
        BankSavingsAccountResponse GetBankSavingsAccount(long bankSavingsAccountId);

        /// <summary>
        /// Update BankSavingsAccount
        /// </summary>
        /// <param name="BankSavingsAccountModel">BankSavingsAccountModel.</param>
        /// <returns>Returns updated BankSavingsAccountResponse</returns>
        BankSavingsAccountResponse UpdateBankSavingsAccount(BankSavingsAccountModel body);

        /// <summary>
        /// Delete BankSavingsAccount.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankSavingsAccount(ParameterModel body);
    }
}
