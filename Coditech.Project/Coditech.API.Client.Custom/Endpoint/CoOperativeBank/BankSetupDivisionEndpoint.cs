using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Endpoint
{
    public class BankSetupDivisionEndpoint : BaseEndpoint
    {
        public string ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            string endpoint = $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupDivision/GetBankSetupDivisionList{BuildEndpointQueryString(expand, filter, sort, pageIndex, pageSize)}";
            return endpoint;
        }
        public string CreateBankSetupDivisionAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupDivision/CreateBankSetupDivision";

        public string GetBankSetupDivisionAsync(short bankSetupDivisionId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupDivision/GetBankSetupDivision?bankSetupDivisionId={bankSetupDivisionId}";

        public string UpdateBankSetupDivisionAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupDivision/UpdateBankSetupDivision";

        public string DeleteBankSetupDivisionAsync() =>
                  $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSetupDivision/DeleteBankSetupDivision";
    }
}