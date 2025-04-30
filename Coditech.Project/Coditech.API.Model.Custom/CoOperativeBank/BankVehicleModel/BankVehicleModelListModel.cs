namespace Coditech.Common.API.Model
{
    public partial class BankVehicleModelListModel : BaseListModel
    {
        public List<BankVehicleModelModel> BankVehicleModelList { get; set; }
        public BankVehicleModelListModel()
        {
            BankVehicleModelList = new List<BankVehicleModelModel>();
        }

    }
}
