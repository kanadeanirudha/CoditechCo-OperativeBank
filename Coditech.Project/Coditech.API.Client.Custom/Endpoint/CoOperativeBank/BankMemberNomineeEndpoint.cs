using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankMemberNomineeEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberNominee/GetMemberNomineeList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateMemberNomineeAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberNominee/CreateMemberNominee";

        public string GetMemberNomineeAsync(int bankMemberNomineeId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberNominee/GetMemberNominee?bankMemberNomineeId={bankMemberNomineeId}";

        public string UpdateMemberNomineeAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberNominee/UpdateMemberNominee";

        public string DeleteMemberNomineeAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMemberNominee/DeleteMemberNominee";
    }
}
