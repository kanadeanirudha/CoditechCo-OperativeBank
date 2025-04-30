using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSetupPropertyValuersAuthorityEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuersAuthority/GetPropertyValuersAuthorityList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreatePropertyValuersAuthorityAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuersAuthority/CreatePropertyValuersAuthority";

        public string GetPropertyValuersAuthorityAsync(short bankSetupPropertyValuersAuthorityId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuersAuthority/GetPropertyValuersAuthority?bankSetupPropertyValuersAuthorityId={bankSetupPropertyValuersAuthorityId}";

        public string UpdatePropertyValuersAuthorityAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuersAuthority/UpdatePropertyValuersAuthority";

        public string DeletePropertyValuersAuthorityAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuersAuthority/DeletePropertyValuersAuthority";
    }
}
