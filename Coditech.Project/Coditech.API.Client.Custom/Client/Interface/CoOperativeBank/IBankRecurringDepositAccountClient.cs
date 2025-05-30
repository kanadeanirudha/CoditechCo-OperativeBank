using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankRecurringDepositAccountClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankRecurringDepositAccount.
        /// </summary>
        /// <returns>BankRecurringDepositAccountListResponse</returns>
        BankRecurringDepositAccountListResponse List(string centreCode,IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankRecurringDepositAccount.
        /// </summary>
        /// <param name="BankRecurringDepositAccountModel">BankRecurringDepositAccountModel.</param>
        /// <returns>Returns BankRecurringDepositAccountResponse.</returns>
        BankRecurringDepositAccountResponse CreateBankRecurringDepositAccount(BankRecurringDepositAccountModel body);

        /// <summary>
        /// Get BankRecurringDepositAccount by bankRecurringDepositAccountId.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId</param>
        /// <returns>Returns BankRecurringDepositAccountResponse.</returns>
        BankRecurringDepositAccountResponse GetBankRecurringDepositAccount(int bankRecurringDepositAccountId);

        /// <summary>
        /// Update BankRecurringDepositAccount
        /// </summary>
        /// <param name="BankRecurringDepositAccountModel">BankSavingsAccountModel.</param>
        /// <returns>Returns updated BankSavingsAccountResponse</returns>
        BankRecurringDepositAccountResponse UpdateBankRecurringDepositAccount(BankRecurringDepositAccountModel body);

        /// <summary>
        /// Delete BankRecurringDepositAccount.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankRecurringDepositAccount(ParameterModel body);
    }
}
