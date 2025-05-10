using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSavingAccountIntrestPostingsService
    {
        BankSavingAccountIntrestPostingsListModel GetBankSavingAccountIntrestPostingsList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSavingAccountIntrestPostingsModel CreateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel model);
        BankSavingAccountIntrestPostingsModel GetBankSavingAccountIntrestPostings(int bankSavingAccountIntrestPostingsId);
        bool UpdateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel model);
        bool DeleteBankSavingAccountIntrestPostings(ParameterModel parameterModel);
    }
}
