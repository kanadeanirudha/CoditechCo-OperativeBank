using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankRecurringDepositAccountService
    {
        BankRecurringDepositAccountListModel GetBankRecurringDepositAccountList(string centreCode,FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankRecurringDepositAccountModel CreateBankRecurringDepositAccount(BankRecurringDepositAccountModel model);
        BankRecurringDepositAccountModel GetBankRecurringDepositAccount(int bankRecurringDepositAccountId);
        bool UpdateBankRecurringDepositAccount(BankRecurringDepositAccountModel model);
        bool DeleteBankRecurringDepositAccount(ParameterModel parameterModel);
        BankRecurringDepositClosureModel CreateBankRecurringDepositClosure(BankRecurringDepositClosureModel model);
        BankRecurringDepositClosureModel GetBankRecurringDepositClosure(int bankRecurringDepositAccountId);
        bool UpdateBankRecurringDepositClosure(BankRecurringDepositClosureModel model);
    }
}
