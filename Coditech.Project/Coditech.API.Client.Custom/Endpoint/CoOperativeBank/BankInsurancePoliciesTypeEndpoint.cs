using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankInsurancePoliciesTypeEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankInsurancePoliciesType/GetBankInsurancePoliciesTypeList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankInsurancePoliciesTypeAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankInsurancePoliciesType/CreateBankInsurancePoliciesType";

        public string GetBankInsurancePoliciesTypeAsync(short bankInsurancePoliciesTypeId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankInsurancePoliciesType/GetBankInsurancePoliciesType?bankInsurancePoliciesTypeId={bankInsurancePoliciesTypeId}";

        public string UpdateBankInsurancePoliciesTypeAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankInsurancePoliciesType/UpdateBankInsurancePoliciesType";

        public string DeleteBankInsurancePoliciesTypeAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankInsurancePoliciesType/DeleteBankInsurancePoliciesType";
    }
}