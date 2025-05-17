using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
namespace Coditech.API.Client
{
    public interface IBankProductClient : IBaseClient
    {
        /// <summary>
        /// Get list of BankProduct.
        /// </summary>
        /// <returns>BankProductListResponse</returns>
        BankProductListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize);

        /// <summary>
        /// Create BankProduct.
        /// </summary>
        /// <param name="BankProductModel">BankProductModel.</param>
        /// <returns>Returns BankProductResponse.</returns>
        BankProductResponse CreateBankProduct(BankProductModel body);

        /// <summary>
        /// Get BankProduct by bankProductId.
        /// </summary>
        /// <param name="bankProductId">bankProductId</param>
        /// <returns>Returns BankProductResponse.</returns>
        BankProductResponse GetBankProduct(short bankProductId);

        /// <summary>
        /// Update BankProduct
        /// </summary>
        /// <param name="BankProductModel">BankProductModel.</param>
        /// <returns>Returns updated BankProductResponse</returns>
        BankProductResponse UpdateBankProduct(BankProductModel body);

        /// <summary>
        /// Delete BankProduct.
        /// </summary>
        /// <param name="ParameterModel">ParameterModel.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        TrueFalseResponse DeleteBankProduct(ParameterModel body);
    }
}
