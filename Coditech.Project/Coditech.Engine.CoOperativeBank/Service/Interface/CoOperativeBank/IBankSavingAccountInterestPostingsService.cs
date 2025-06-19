using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSavingAccountInterestPostingsService
    {
        BankSavingAccountInterestPostingsListModel GetBankSavingAccountInterestPostingsList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSavingAccountInterestPostingsModel CreateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsModel model);
        BankSavingAccountInterestPostingsModel GetBankSavingAccountInterestPostings(int bankSavingsAccountId);
        bool UpdateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsModel model);
        bool DeleteBankSavingAccountInterestPostings(ParameterModel parameterModel);
    }
}
