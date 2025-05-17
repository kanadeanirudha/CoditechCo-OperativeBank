using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankProductAgent
    {
        /// <summary>
        /// Get list of BankProduct.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankProductListViewModel</returns>
        BankProductListViewModel GetBankProductList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankProduct.
        /// </summary>
        /// <param name="bankProductViewModel">bankProduct.</param>
        /// <returns>Returns created model.</returns>
        BankProductViewModel CreateBankProduct(BankProductViewModel bankProductViewModel);

        /// <summary>
        /// Get BankProduct by bankProductId.
        /// </summary>
        /// <param name="bankProductId">bankProductId</param>
        /// <returns>Returns BankProductViewModel.</returns>
        BankProductViewModel GetBankProduct(short bankProductId);

        /// <summary>
        /// Update BankProduct.
        /// </summary>
        /// <param name="bankProductViewModel">bankProductViewModel.</param>
        /// <returns>Returns updated BankProductViewModel</returns>
        BankProductViewModel UpdateBankProduct(BankProductViewModel bankProductViewModel);

        /// <summary>
        /// Delete BankProduct.
        /// </summary>
        /// <param name="bankProductId">bankProductId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteBankProduct(string bankProductId, out string errorMessage);
    }
}
