using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankPostingLoanAccountService
    {
        BankPostingLoanAccountListModel GetBankPostingLoanAccountList(string centreCode, int bankMemberId, FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankPostingLoanAccountModel CreatePostingLoanAccount(BankPostingLoanAccountModel model);
        BankPostingLoanAccountModel GetPostingLoanAccount(int bankPostingLoanAccountId);
        bool UpdatePostingLoanAccount(BankPostingLoanAccountModel model);
        bool DeletePostingLoanAccount(ParameterModel parameterModel);
        BankLoanForeClosuresModel CreateBankLoanForeClosures(BankLoanForeClosuresModel model);
        BankLoanForeClosuresModel GetBankLoanForeClosures(int bankPostingLoanAccountId);
        bool UpdateBankLoanForeClosures(BankLoanForeClosuresModel model);
        BankLoanRepaymentModel GetLoanRepayment(int bankPostingLoanAccountId);
        bool UpdateLoanRepayment(BankLoanRepaymentModel model);
    }
}
