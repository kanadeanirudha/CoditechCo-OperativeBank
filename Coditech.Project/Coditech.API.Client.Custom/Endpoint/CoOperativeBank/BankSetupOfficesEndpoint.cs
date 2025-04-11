using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSetupOfficesEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupOffices/GetBankSetupOfficesList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankSetupOfficesAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupOffices/CreateBankSetupOffices";

        public string GetBankSetupOfficesAsync(short bankSetupOfficeId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupOffices/GetBankSetupOffices?bankSetupOfficeId={bankSetupOfficeId}";

        public string UpdateBankSetupOfficesAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupOffices/UpdateBankSetupOffices";

        public string DeleteBankSetupOfficesAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupOffices/DeleteBankSetupOffices";
    }
}