using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankPostingLoanAccountService
    {
        BankPostingLoanAccountListModel GetBankPostingLoanAccountList(int bankMemberId,FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankPostingLoanAccountModel CreatePostingLoanAccount(BankPostingLoanAccountModel model);
        BankPostingLoanAccountModel GetPostingLoanAccount(int bankPostingLoanAccountId);
        bool UpdatePostingLoanAccount(BankPostingLoanAccountModel model);
        bool DeletePostingLoanAccount(ParameterModel parameterModel);
    }
}
