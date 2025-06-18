using Coditech.Common.API.Model.Responses;
namespace Coditech.API.Client
{
    public interface ICoOperativeUIClient : IBaseClient
    {       
        /// <summary>
        /// Get CoOperative UI  by selectedBalanceSheeetId.
        /// </summary>
        /// <param name="selectedBalanceSheeetId">selectedBalanceSheeetId</param>
        /// <returns>Returns CoOperativeUIResponse.</returns>
        CoOperativeUIResponse GetCoOperativeUIDetails(int selectedBalanceSheeetId);

        /// <summary>
        /// Get CoOperative UI  by bankMemberId.
        /// </summary>
        /// <param name="bankMemberId">bankMemberId</param>
        /// <param name="navbarEnumId">navbarEnumId</param>
        /// <returns>Returns CoOperativeUIResponse.</returns>
        CoOperativeUIResponse GetCoOperativeUI(int bankMemberId, int navbarEnumId);
    }
}
