using Coditech.Common.API.Model;
namespace Coditech.API.Service
{
    public interface ICoOperativeUIService
    {
        CoOperativeUIModel GetCoOperativeUI(int bankMemberId, int navbarEnumId);
        CoOperativeUIModel GetCoOperativeUIDetails(int selectedBalanceSheeetId);
    }
}
