using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankVehicleModelService
    {
        BankVehicleModelListModel GetVehicleModelList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankVehicleModelModel CreateVehicleModel(BankVehicleModelModel model);
        BankVehicleModelModel GetVehicleModel(short bankVehicleModelId);
        bool UpdateVehicleModel(BankVehicleModelModel model);
        bool DeleteVehicleModel(ParameterModel parameterModel);
    }
}
