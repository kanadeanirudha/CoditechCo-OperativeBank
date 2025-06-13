using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankLoanScheduleAgent
    {
        /// <summary>
        /// Create BankLoanSchedule.
        /// </summary>
        /// <param name="bankLoanScheduleViewModel"> BankLoanSchedule View Model.</param>
        /// <returns>Returns created model.</returns>
        BankLoanScheduleViewModel CreateBankLoanSchedule(BankLoanScheduleViewModel bankLoanScheduleViewModel);

        /// <summary>
        /// Get BankLoanSchedule by BankPostingLoanAccount.
        /// </summary>
        /// <param name="bankPostingLoanAccountId">BankPostingLoanAccountId</param>
        /// <returns>Returns BankLoanScheduleViewModel.</returns>
        BankLoanScheduleViewModel GetBankLoanSchedule(int bankPostingLoanAccountId);

        /// <summary>
        /// Update BankLoanSchedule.
        /// </summary>
        /// <param name="bankLoanScheduleViewModel">BankLoanScheduleViewModel.</param>
        /// <returns>Returns updated BankLoanScheduleViewModel</returns>
        BankLoanScheduleViewModel UpdateBankLoanSchedule(BankLoanScheduleViewModel bankLoanScheduleViewModel);
    }
}
