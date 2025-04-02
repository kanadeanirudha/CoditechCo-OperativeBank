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
            CreateMap<BankSetupMortagePropertyTypeViewModel, BankSetupMortagePropertyTypeListViewModel>().ReverseMap();
            #endregion
        }
    }
}
