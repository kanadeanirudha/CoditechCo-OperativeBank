using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSavingAccountInterestPostingsEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountInterestPostings/GetBankSavingAccountInterestPostingsList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankSavingAccountInterestPostingsAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountInterestPostings/CreateBankSavingAccountInterestPostings";

        public string GetBankSavingAccountInterestPostingsAsync(int bankSavingsAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountInterestPostings/GetBankSavingAccountInterestPostings?bankSavingsAccountId={bankSavingsAccountId}";

        public string UpdateBankSavingAccountInterestPostingsAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountInterestPostings/UpdateBankSavingAccountInterestPostings";

        public string DeleteBankSavingAccountInterestPostingsAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountInterestPostings/DeleteBankSavingAccountInterestPostings";
    }
}