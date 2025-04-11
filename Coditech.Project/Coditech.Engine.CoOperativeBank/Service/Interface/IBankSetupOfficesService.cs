using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSetupOfficesService
    {
        BankSetupOfficesListModel GetBankSetupOfficesList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSetupOfficesModel CreateBankSetupOffices(BankSetupOfficesModel model);
        BankSetupOfficesModel GetBankSetupOffices(short bankSetupOfficeId);
        bool UpdateBankSetupOffices(BankSetupOfficesModel model);
        bool DeleteBankSetupOffices(ParameterModel parameterModel);
    }
}
