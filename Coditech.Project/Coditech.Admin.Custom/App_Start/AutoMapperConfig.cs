using AutoMapper;
using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;

namespace Coditech.Admin.Custom
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            #region CoOperativeBnak
            CreateMap<BankSetupMortagePropertyTypeModel, BankSetupMortagePropertyTypeViewModel>().ReverseMap();
            CreateMap<BankSetupMortagePropertyTypeListModel, BankSetupMortagePropertyTypeListViewModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuersModel, BankSetupPropertyValuersViewModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuersListModel, BankSetupPropertyValuersListViewModel>().ReverseMap();
            CreateMap<BankVehicleModelModel, BankVehicleModelViewModel>().ReverseMap();
            CreateMap<BankVehicleModelListModel, BankVehicleModelListViewModel>().ReverseMap();


            #endregion
        }
    }
}
