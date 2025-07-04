﻿using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankFixedDepositAccountClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankFixedDepositAccount.
        /// </summary>
        /// <returns>BankFixedDepositAccountListResponse</returns>
        BankFixedDepositAccountListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankFixedDepositAccount.
        /// </summary>
        /// <param name="BankFixedDepositAccountModel">BankFixedDepositAccountModel.</param>
        /// <returns>Returns BankFixedDepositAccountResponse.</returns>
        BankFixedDepositAccountResponse CreateBankFixedDepositAccount(BankFixedDepositAccountModel body);

        /// <summary>
        /// Get BankFixedDepositAccount by bankFixedDepositAccountId.
        /// </summary>
        /// <param name="bankFixedDepositAccountId">bankFixedDepositAccountId</param>
        /// <returns>Returns BankFixedDepositAccountResponse.</returns>
        BankFixedDepositAccountResponse GetBankFixedDepositAccount(short bankFixedDepositAccountId);

        /// <summary>
        /// Update BankFixedDepositAccount
        /// </summary>
        /// <param name="BankFixedDepositAccountModel">BankFixedDepositAccountModel.</param>
        /// <returns>Returns updated BankFixedDepositAccountResponse</returns>
        BankFixedDepositAccountResponse UpdateBankFixedDepositAccount(BankFixedDepositAccountModel body);

        /// <summary>
        /// Delete BankFixedDepositAccount.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankFixedDepositAccount(ParameterModel body);

        #region BankFixedDepositClosure

        /// <summary>
        /// Create BankFixedDepositClosure.
        /// </summary>
        /// <param name="BankFixedDepositClosureModel">BankFixedDepositClosureModel.</param>
        /// <returns>Returns BankFixedDepositClosureResponse.</returns>
        BankFixedDepositClosureResponse CreateBankFixedDepositClosure(BankFixedDepositClosureModel body);

        /// <summary>
        /// Get BankFixedDepositClosure by bankFixedDepositAccountId.
        /// </summary>
        /// <param name="bankFixedDepositAccountId">bankFixedDepositAccountId</param>
        /// <returns>Returns BankFixedDepositClosureResponse.</returns>
        BankFixedDepositClosureResponse GetBankFixedDepositClosure(short bankFixedDepositAccountId);

        /// <summary>
        /// Update BankFixedDepositClosure
        /// </summary>
        /// <param name="BankFixedDepositClosureModel">BankFixedDepositClosureModel.</param>
        /// <returns>Returns updated BankFixedDepositClosureResponse</returns>
        BankFixedDepositClosureResponse UpdateBankFixedDepositClosure(BankFixedDepositClosureModel body);
        #endregion

        #region BankFixedDepositInterestPostings
        /// <summary>
        /// Create BankFixedDepositInterestPostings.
        /// </summary>
        /// <param name="BankFixedDepositInterestPostingsModel">BankFixedDepositInterestPostingsModel.</param>
        /// <returns>Returns BankFixedDepositInterestPostingsResponse.</returns>
        BankFixedDepositInterestPostingsResponse CreateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsModel body);

        /// <summary>
        /// Get BankFixedDepositInterestPostings by bankFixedDepositAccountId.
        /// </summary>
        /// <param name="bankFixedDepositAccountId">bankFixedDepositAccountId</param>
        /// <returns>Returns BankFixedDepositInterestPostingsResponse.</returns>
        BankFixedDepositInterestPostingsResponse GetBankFixedDepositInterestPostings(short bankFixedDepositAccountId);

        /// <summary>
        /// Update BankFixedDepositInterestPostings
        /// </summary>
        /// <param name="BankFixedDepositInterestPostingsModel">BankFixedDepositInterestPostingsModel.</param>
        /// <returns>Returns updated BankFixedDepositInterestPostingsResponse</returns>
        BankFixedDepositInterestPostingsResponse UpdateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsModel body);

        #endregion
    }
}
