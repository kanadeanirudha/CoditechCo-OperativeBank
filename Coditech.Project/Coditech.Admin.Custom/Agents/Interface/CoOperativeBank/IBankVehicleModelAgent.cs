using Coditech.Admin.ViewModel;
namespace Coditech.Admin.Agents
{
    public interface IBankVehicleModelAgent
    {
        /// <summary>
        /// Get list of BankVehicleModel.
        /// </summary>
        /// <param name="dataTableModel">DataTable ViewModel.</param>
        /// <returns>BankVehicleModelListViewModel</returns>
        BankVehicleModelListViewModel GetVehicleModelList(DataTableViewModel dataTableModel);

        /// <summary>
        /// Create BankVehicleModel.
        /// </summary>
        /// <param name="bankVehicleModelViewModel"> BankVehicleModel View Model.</param>
        /// <returns>Returns created model.</returns>
        BankVehicleModelViewModel CreateVehicleModel(BankVehicleModelViewModel bankVehicleModelViewModel);

        /// <summary>
        /// Get BankVehicleModel by bankVehicleModel.
        /// </summary>
        /// <param name="bankVehicleModelType">bankVehicleModelType</param>
        /// <returns>Returns BankVehicleModelViewModel.</returns>
        BankVehicleModelViewModel GetVehicleModel(short bankVehicleModelId);

        /// <summary>
        /// Update BankVehicleModel.
        /// </summary>
        /// <param name="bankVehicleModelViewModel">BankVehicleModelViewModel.</param>
        /// <returns>Returns updated BankVehicleModelViewModel</returns>
        BankVehicleModelViewModel UpdateVehicleModel(BankVehicleModelViewModel bankVehicleModelViewModel);

        /// <summary>
        /// Delete BankVehicleModel.
        /// </summary>
        /// <param name="bankVehicleModelId">BankVehicleModelId.</param>
        /// <returns>Returns true if deleted successfully else return false.</returns>
        bool DeleteVehicleModel(string bankVehicleModelId, out string errorMessage);

    }
}
