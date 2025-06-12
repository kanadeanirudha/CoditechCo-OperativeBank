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

        #region BankRecurringDepositClosure
        /// <summary>
        /// Create BankRecurringDepositClosure.
        /// </summary>
        /// <param name="BankRecurringDepositClosureModel">BankRecurringDepositClosureModel.</param>
        /// <returns>Returns BankRecurringDepositAccountResponse.</returns>
        BankRecurringDepositClosureResponse CreateBankRecurringDepositClosure(BankRecurringDepositClosureModel body);

        /// <summary>
        /// Get BankRecurringDepositClosure by bankRecurringDepositAccountId.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId</param>
        /// <returns>Returns BankRecurringDepositClosureResponse.</returns>
        BankRecurringDepositClosureResponse GetBankRecurringDepositClosure(int bankRecurringDepositAccountId);

        /// <summary>
        /// Update BankRecurringDepositClosure
        /// </summary>
        /// <param name="BankRecurringDepositClosureModel">BankRecurringDepositClosureModel.</param>
        /// <returns>Returns updated BankRecurringDepositClosureResponse</returns>
        BankRecurringDepositClosureResponse UpdateBankRecurringDepositClosure(BankRecurringDepositClosureModel body);
        #endregion

        #region  BankRecurringDepositInterestPosting

        /// <summary>
        /// Create BankRecurringDepositInterestPostingId.
        /// </summary>
        /// <param name="BankRecurringDepositInterestPostingModel">BankRecurringDepositInterestPostingModel.</param>
        /// <returns>Returns BankRecurringDepositInterestPostingResponse.</returns>
        BankRecurringDepositInterestPostingResponse CreateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingModel body);

        /// <summary>
        /// Get BankRecurringDepositInterestPostingId by bankRecurringDepositAccountId.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId</param>
        /// <returns>Returns BankRecurringDepositInterestPostingResponse.</returns>
        BankRecurringDepositInterestPostingResponse GetBankRecurringDepositInterestPosting(int bankRecurringDepositAccountId);

        /// <summary>
        /// Update BankRecurringDepositInterestPosting
        /// </summary>
        /// <param name="BankRecurringDepositInterestPostingModel">BankRecurringDepositInterestPostingModel.</param>
        /// <returns>Returns updated BankRecurringDepositInterestPostingResponse</returns>
        BankRecurringDepositInterestPostingResponse UpdateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingModel body);


        #endregion

    }
}
