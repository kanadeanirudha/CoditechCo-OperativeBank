using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSetupMortagePropertyTypeEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupMortagePropertyType/GetPropertyTypeList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreatePropertyTypeAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupMortagePropertyType/CreatePropertyType";

        public string GetPropertyTypeAsync(short bankSetupMortagePropertyTypeId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupMortagePropertyType/GetPropertyType?bankSetupMortagePropertyTypeId={bankSetupMortagePropertyTypeId}";

        public string UpdatePropertyTypeAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupMortagePropertyType/UpdatePropertyType";

        public string DeletePropertyTypeAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupMortagePropertyType/DeletePropertyType";
    }
}
