using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankRecurringDepositAccountEndpoint : BaseEndpoint
    {
        public string ListAsync(string centreCode, IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/GetBankRecurringDepositAccountList?centreCode={centreCode}{BuildEndpointQueryString(true, expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankRecurringDepositAccountAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/CreateBankRecurringDepositAccount";

        public string GetBankRecurringDepositAccountAsync(int bankRecurringDepositAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/GetBankRecurringDepositAccount?bankRecurringDepositAccountId={bankRecurringDepositAccountId}";

        public string UpdateBankRecurringDepositAccountAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/UpdateBankRecurringDepositAccount";

        public string DeleteBankRecurringDepositAccountAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/DeleteBankRecurringDepositAccount";

        public string CreateBankRecurringDepositClosureAsync() =>
         $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/CreateBankRecurringDepositClosure";

        public string GetBankRecurringDepositClosureAsync(int bankRecurringDepositAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/GetBankRecurringDepositClosure?bankRecurringDepositAccountId={bankRecurringDepositAccountId}";

        public string UpdateBankRecurringDepositClosureAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/UpdateBankRecurringDepositClosure";

        public string CreateBankRecurringDepositInterestPostingAsync() =>
          $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/CreateBankRecurringDepositInterestPosting";

        public string GetBankRecurringDepositInterestPostingAsync(int bankRecurringDepositAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/GetBankRecurringDepositInterestPosting?bankRecurringDepositAccountId={bankRecurringDepositAccountId}";

        public string UpdateBankRecurringDepositInterestPostingAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankRecurringDepositAccount/UpdateBankRecurringDepositInterestPosting";

    }
}