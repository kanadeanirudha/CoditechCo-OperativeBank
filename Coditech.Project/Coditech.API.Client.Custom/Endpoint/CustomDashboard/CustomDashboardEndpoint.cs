using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;

namespace Coditech.API.Endpoint
{
    public class CustomDashboardEndpoint : BaseEndpoint
    {
        public string GetCustomDashboardDetailsAsync(int selectedAdminRoleMasterId,long userMasterId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/CustomDashboardController/GetCustomDashboardDetails?selectedAdminRoleMasterId={selectedAdminRoleMasterId}&userMasterId={userMasterId}";
    }
}
