using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSetupPropertyValuersService
    {
        BankSetupPropertyValuersListModel GetPropertyValuersList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSetupPropertyValuersModel CreatePropertyValuers(BankSetupPropertyValuersModel model);
        BankSetupPropertyValuersModel GetPropertyValuers(long generalPersonAddressId);
        bool UpdatePropertyValuers(BankSetupPropertyValuersModel model);
        bool DeletePropertyValuers(ParameterModel parameterModel);
    }
}
