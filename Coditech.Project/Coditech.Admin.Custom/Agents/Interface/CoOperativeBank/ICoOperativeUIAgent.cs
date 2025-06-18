using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;
namespace Coditech.Admin.Agents
{
    public interface ICoOperativeUIAgent
    {
        MemberCreateEditViewModel GetCoOperativeUI(string centreCode, int bankMemberId);
        CoOperativeUIViewModel GetCoOperativeUIDetails(string selectedcentreCode, int bankMemberId, int accSetupBalanceSheetId);
        GeneralFinancialYearModel GetCurrentFinancialYear();
    }
}
