using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankFixedDepositAccountEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankFixedDepositAccount/GetBankFixedDepositAccountList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankFixedDepositAccountAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankFixedDepositAccount/CreateBankFixedDepositAccount";

        public string GetBankFixedDepositAccountAsync(short bankFixedDepositAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankFixedDepositAccount/GetBankFixedDepositAccount?bankFixedDepositAccountId={bankFixedDepositAccountId}";

        public string UpdateBankFixedDepositAccountAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankFixedDepositAccount/UpdateBankFixedDepositAccount";

        public string DeleteBankFixedDepositAccountAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankFixedDepositAccount/DeleteBankFixedDepositAccount";
    }
}