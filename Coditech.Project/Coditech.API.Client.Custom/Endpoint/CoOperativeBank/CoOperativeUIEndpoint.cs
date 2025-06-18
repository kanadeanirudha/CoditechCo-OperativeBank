using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;

namespace Coditech.API.Endpoint
{
    public class CoOperativeUIEndpoint : BaseEndpoint
    {
        public string GetCoOperativeUIDetailsAsync(int selectedBalanceSheeetId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/CoOperativeUIController/GetCoOperativeUIDetails?selectedBalanceSheeetId={selectedBalanceSheeetId}";
        public string GetCoOperativeUIAsync(int bankMemberId, int navbarEnumId) =>
           $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/CoOperativeUIController/GetCoOperativeUI?bankMemberId={bankMemberId}&navbarEnumId={navbarEnumId}";
    }
}
    