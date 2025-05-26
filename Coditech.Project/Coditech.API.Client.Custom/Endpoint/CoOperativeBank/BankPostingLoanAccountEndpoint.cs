using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankPostingLoanAccountEndpoint : BaseEndpoint
    {
        public string ListAsync(int bankMemberId, IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankPostingLoanAccount/GetBankPostingLoanAccountList?bankMemberId={bankMemberId}{BuildEndpointQueryString(true, expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreatePostingLoanAccountAsync() =>
           $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankPostingLoanAccount/CreatePostingLoanAccount";
        public string GetPostingLoanAccountAsync(int bankPostingLoanAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankPostingLoanAccount/GetPostingLoanAccount?bankPostingLoanAccountId={bankPostingLoanAccountId}";

        public string UpdatePostingLoanAccountAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankPostingLoanAccount/UpdatePostingLoanAccount";

        public string DeletePostingLoanAccountAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankPostingLoanAccount/DeletePostingLoanAccount";
    }
}
