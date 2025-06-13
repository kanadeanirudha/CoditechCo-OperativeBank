using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSavingAccountIntrestPostingsEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountIntrestPostings/GetBankSavingAccountIntrestPostingsList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankSavingAccountIntrestPostingsAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountIntrestPostings/CreateBankSavingAccountIntrestPostings";

        public string GetBankSavingAccountIntrestPostingsAsync(int bankSavingsAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountIntrestPostings/GetBankSavingAccountIntrestPostings?bankSavingsAccountId={bankSavingsAccountId}";

        public string UpdateBankSavingAccountIntrestPostingsAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountIntrestPostings/UpdateBankSavingAccountIntrestPostings";

        public string DeleteBankSavingAccountIntrestPostingsAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingAccountIntrestPostings/DeleteBankSavingAccountIntrestPostings";
    }
}