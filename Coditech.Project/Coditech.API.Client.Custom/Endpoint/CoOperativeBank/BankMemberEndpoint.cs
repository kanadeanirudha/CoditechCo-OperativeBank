using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankMemberEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMember/GetBankMemberList{BuildEndpointQueryString( expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string GetMemberOtherDetailAsync(int bankMemberId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMember/GetMemberOtherDetail?bankMemberId={bankMemberId}";

        public string UpdateMemberOtherDetailAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMember/UpdateMemberOtherDetail";

        public string DeleteBankMemberAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankMember/DeleteBankMember";
    }
}
