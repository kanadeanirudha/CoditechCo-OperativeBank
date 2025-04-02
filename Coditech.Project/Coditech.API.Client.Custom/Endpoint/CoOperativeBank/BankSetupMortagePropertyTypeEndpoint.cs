using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSetupMortagePropertyTypeEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCustomApiRootUri}/BankSetupMortagePropertyType/GetPropertyTypeList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreatePropertyTypeAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCustomApiRootUri}/BankSetupMortagePropertyType/CreatePropertyType";

        public string GetPropertyTypeAsync(short bankSetupMortagePropertyTypeId) =>
            $"{CoditechCustomAdminSettings.CoditechCustomApiRootUri}/BankSetupMortagePropertyType/GetPropertyType?bankSetupMortagePropertyTypeId={bankSetupMortagePropertyTypeId}";

        public string UpdatePropertyTypeAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCustomApiRootUri}/BankSetupMortagePropertyType/UpdatePropertyType";

        public string DeletePropertyTypeAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCustomApiRootUri}/BankSetupMortagePropertyType/DeletePropertyType";
    }
}
