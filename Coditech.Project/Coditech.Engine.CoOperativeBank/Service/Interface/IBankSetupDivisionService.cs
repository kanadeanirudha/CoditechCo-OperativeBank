using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSetupDivisionService
    {
        BankSetupDivisionListModel GetBankSetupDivisionList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSetupDivisionModel CreateBankSetupDivision(BankSetupDivisionModel model);
        BankSetupDivisionModel GetBankSetupDivision(short bankSetupDivisionId);
        bool UpdateBankSetupDivision(BankSetupDivisionModel model);
        bool DeleteBankSetupDivision(ParameterModel parameterModel);
    }
}
