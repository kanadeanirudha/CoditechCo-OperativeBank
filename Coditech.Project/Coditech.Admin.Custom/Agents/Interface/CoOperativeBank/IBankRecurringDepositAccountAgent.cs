using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
namespace Coditech.Admin.Agents
{
    public interface IBankRecurringDepositAccountAgent
    {
        /// <summary>
        /// Get list of BankRecurringDepositAccount.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankRecurringDepositAccountListViewModel</returns>
        BankRecurringDepositAccountListViewModel GetBankRecurringDepositAccountList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankRecurringDepositAccount.
        /// </summary>
        /// <param name="bankRecurringDepositAccountViewModel">BankRecurringDepositAccountViewModel.</param>
        /// <returns>Returns created model.</returns>
        BankRecurringDepositAccountViewModel CreateBankRecurringDepositAccount(BankRecurringDepositAccountViewModel bankRecurringDepositAccountViewModel);

        /// <summary>
        /// Get BankRecurringDepositAccount by bankRecurringDepositAccountId.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId</param>
        /// <returns>Returns BankRecurringDepositAccountViewModel.</returns>
        BankRecurringDepositAccountViewModel GetBankRecurringDepositAccount(int bankRecurringDepositAccountId);

        /// <summary>
        /// Update BankRecurringDepositAccount.
        /// </summary>
        /// <param name="bankRecurringDepositAccountViewModel">bankRecurringDepositAccountViewModel.</param>
        /// <returns>Returns updated BankRecurringDepositAccountViewModel</returns>
        BankRecurringDepositAccountViewModel UpdateBankRecurringDepositAccount(BankRecurringDepositAccountViewModel bankRecurringDepositAccountModel);

        /// <summary>
        /// Delete BankRecurringDepositAccount.
        /// </summary>
        /// <param name="bankRecurringDepositAccountId">bankRecurringDepositAccountId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankRecurringDepositAccount(string bankRecurringDepositAccountId, out string errorMessage);
        //BankRecurringDepositAccountResponse GetBankRecurringDepositAccountList();

       // BankRecurringDepositAccountListResponse GetBankRecurringDepositAccountList();
    }
}
