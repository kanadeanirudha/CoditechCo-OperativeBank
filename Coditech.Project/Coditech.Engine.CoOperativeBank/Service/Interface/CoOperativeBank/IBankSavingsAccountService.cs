using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSavingsAccountService
    {
        BankSavingsAccountListModel GetBankSavingsAccountList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSavingsAccountModel CreateBankSavingsAccount(BankSavingsAccountModel model);
        BankSavingsAccountModel GetBankSavingsAccount(long bankSavingsAccountId);
        bool UpdateBankSavingsAccount(BankSavingsAccountModel model);
        BankSavingsAccountClosuresModel CreateBankSavingsAccountClosures(BankSavingsAccountClosuresModel model);
        BankSavingsAccountClosuresModel GetBankSavingsAccountClosures(long bankSavingsAccountId);
        bool UpdateBankSavingsAccountClosures(BankSavingsAccountClosuresModel model);
        bool DeleteBankSavingsAccount(ParameterModel parameterModel);
    }
}
