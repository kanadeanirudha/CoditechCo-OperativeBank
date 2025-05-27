using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankPostingLoanAccountClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankPostingLoanAccount.
        /// </summary>
        /// <returns>BankPostingLoanAccountListResponse</returns>
        BankPostingLoanAccountListResponse List(int bankMemberId, IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create GeneralBatch.
        /// </summary>
        /// <param name="BankPostingLoanAccountModel">GeneralBatchModel.</param>
        /// <returns>Returns GeneralBatchResponse.</returns>
        BankPostingLoanAccountResponse CreatePostingLoanAccount(BankPostingLoanAccountModel body);

        /// <summary>
        /// Get Member Other Detail by BankPostingLoanAccountId.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId</param>
        /// <returns>Returns BankPostingLoanAccountResponse.</returns>
        BankPostingLoanAccountResponse GetPostingLoanAccount(int bankPostingLoanAccountId);

        /// <summary>
        /// Update Member Other Detail.
        /// </summary>
        /// <param name="bankPostingLoanAccountModel">BankPostingLoanAccountModel.</param>
        /// <returns>Returns updated BankPostingLoanAccountResponse</returns>
        BankPostingLoanAccountResponse UpdatePostingLoanAccount(BankPostingLoanAccountModel body);

        /// <summary>
        /// Delete BankPostingLoanAccount.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeletePostingLoanAccount(ParameterModel body);

        #region BankLoanForeClosures

        /// <summary>
        /// Create BankLoanForeClosures.
        /// </summary>
        /// <param name="BankLoanForeClosuresModel">BankLoanForeClosuresModel.</param>
        /// <returns>Returns BankLoanForeClosuresResponse.</returns>
        BankLoanForeClosuresResponse CreateBankLoanForeClosures(BankLoanForeClosuresModel body);

        /// <summary>
        /// Get BankLoanForeClosures Detail by BankPostingLoanAccountId.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId</param>
        /// <returns>Returns BankLoanForeClosuresResponse.</returns>
        BankLoanForeClosuresResponse GetBankLoanForeClosures(int bankPostingLoanAccountId);

        /// <summary>
        /// Update BankLoanForeClosures Detail.
        /// </summary>
        /// <param name="BankLoanForeClosuresModel">BankLoanForeClosuresModel.</param>
        /// <returns>Returns updated BankLoanForeClosuresResponse</returns>
        BankLoanForeClosuresResponse UpdateBankLoanForeClosures(BankLoanForeClosuresModel body);
        #endregion
    }
}
