using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
namespace Coditech.API.Endpoint
{
    public class BankLoanScheduleEndpoint : BaseEndpoint
    {
        public string CreateBankLoanScheduleAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankLoanSchedule/CreateBankLoanSchedule";

        public string GetBankLoanScheduleAsync(int bankPostingLoanAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankLoanSchedule/GetBankLoanSchedule?bankPostingLoanAccountId={bankPostingLoanAccountId}";

        public string UpdateBankLoanScheduleAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankLoanSchedule/UpdateBankLoanSchedule";
    }
}