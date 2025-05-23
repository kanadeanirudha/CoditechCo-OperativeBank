using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSavingsAccountEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/GetBankSavingsAccountList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankSavingsAccountAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/CreateBankSavingsAccount";

        public string GetBankSavingsAccountAsync(long bankSavingsAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/GetBankSavingsAccount?bankSavingsAccountId={bankSavingsAccountId}";

        public string UpdateBankSavingsAccountAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/UpdateBankSavingsAccount";

        public string DeleteBankSavingsAccountAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/DeleteBankSavingsAccount";

        public string CreateBankSavingsAccountClosuresAsync() =>
           $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/CreateBankSavingsAccountClosures";


        public string GetBankSavingsAccountClosuresAsync(long bankSavingsAccountId) =>
          $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/GetBankSavingsAccountClosures?bankSavingsAccountId={bankSavingsAccountId}";

        public string UpdateBankSavingsAccountClosuresAsync() =>
              $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccount/UpdateBankSavingsAccountClosures";

    }
}