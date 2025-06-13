using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
namespace Coditech.API.Client
{
    public interface IBankLoanScheduleClient : IBaseClient
    {
        /// <summary>
        /// Create BankLoanSchedule.
        /// </summary>
        /// <param name="BankLoanScheduleModel">BankLoanScheduleModel.</param>
        /// <returns>Returns BankLoanScheduleResponse.</returns>
        BankLoanScheduleResponse CreateBankLoanSchedule(BankLoanScheduleModel body);

        /// <summary>
        /// Get BankLoanSchedule by BankPostingLoanAccountId.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId</param>
        /// <returns>Returns BankLoanScheduleResponse.</returns>
        BankLoanScheduleResponse GetBankLoanSchedule(int bankPostingLoanAccountId);

        /// <summary>
        /// Update BankLoanSchedule.
        /// </summary>
        /// <param name="bankLoanScheduleModel">BankLoanScheduleModel.</param>
        /// <returns>Returns updated BankLoanScheduleResponse</returns>
        BankLoanScheduleResponse UpdateBankLoanSchedule(BankLoanScheduleModel body);
    }
}
