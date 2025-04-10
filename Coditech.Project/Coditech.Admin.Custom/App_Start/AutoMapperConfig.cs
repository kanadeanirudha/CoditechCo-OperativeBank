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
            CreateMap<BankInsurancePoliciesTypeModel, BankInsurancePoliciesTypeViewModel>().ReverseMap();
            CreateMap<BankInsurancePoliciesTypeViewModel, BankInsurancePoliciesTypeListViewModel>().ReverseMap();
            CreateMap<BankSetupDivisionModel, BankSetupDivisionViewModel>().ReverseMap();
            CreateMap<BankSetupDivisionViewModel, BankSetupDivisionListViewModel>().ReverseMap();
            #endregion
        }
    }
}
