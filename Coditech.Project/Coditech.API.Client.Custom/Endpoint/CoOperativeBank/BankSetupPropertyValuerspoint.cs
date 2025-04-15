using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSetupPropertyValuersEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuers/GetPropertyValuersList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreatePropertyValuersAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuers/CreatePropertyValuers";

        public string GetPropertyValuersAsync(short bankSetupPropertyValuersId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuers/GetPropertyValuers?bankSetupPropertyValuersId={bankSetupPropertyValuersId}";

        public string UpdatePropertyValuersAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuers/UpdatePropertyValuers";

        public string DeletePropertyValuersAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupPropertyValuers/DeletePropertyValuers";
    }
}
