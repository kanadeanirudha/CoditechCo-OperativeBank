using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankMemberShareCapitalEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberShareCapital/GetMemberShareCapitalList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateMemberShareCapitalAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberShareCapital/CreateMemberShareCapital";

        public string GetMemberShareCapitalAsync(int bankMemberShareCapitalId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberShareCapital/GetMemberShareCapital?bankMemberShareCapitalId={bankMemberShareCapitalId}";

        public string UpdateMemberShareCapitalAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberShareCapital/UpdateMemberShareCapital";

        public string DeleteMemberShareCapitalAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberShareCapital/DeleteMemberShareCapital";
    }
}
