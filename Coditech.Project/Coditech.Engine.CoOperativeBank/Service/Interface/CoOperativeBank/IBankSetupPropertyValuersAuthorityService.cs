using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSetupPropertyValuersAuthorityService
    {
        BankSetupPropertyValuersAuthorityListModel GetPropertyValuersAuthorityList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSetupPropertyValuersAuthorityModel CreatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel model);
        BankSetupPropertyValuersAuthorityModel GetPropertyValuersAuthority(short bankSetupPropertyValuersValuersAuthorityId);
        bool UpdatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel model);
        bool DeletePropertyValuersAuthority(ParameterModel parameterModel);
    }
}
