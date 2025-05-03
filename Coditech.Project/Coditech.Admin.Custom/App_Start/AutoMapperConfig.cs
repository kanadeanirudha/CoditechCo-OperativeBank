using AutoMapper;
using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;

namespace Coditech.Admin.Custom
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            #region CoOperativeBank
            CreateMap<BankSetupMortagePropertyTypeModel, BankSetupMortagePropertyTypeViewModel>().ReverseMap();
            CreateMap<BankSetupMortagePropertyTypeListModel, BankSetupMortagePropertyTypeListViewModel>().ReverseMap();
            CreateMap<BankVehicleModelModel, BankVehicleModelViewModel>().ReverseMap();
            CreateMap<BankVehicleModelListModel, BankVehicleModelListViewModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuersModel, BankSetupPropertyValuersViewModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuersListModel, BankSetupPropertyValuersListViewModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuersAuthorityModel, BankSetupPropertyValuersAuthorityViewModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuersAuthorityListModel, BankSetupPropertyValuersAuthorityListViewModel>().ReverseMap();
            CreateMap<BankMemberShareCapitalModel, BankMemberShareCapitalViewModel>().ReverseMap();
            CreateMap<BankMemberShareCapitalListModel, BankMemberShareCapitalListViewModel>().ReverseMap();

            CreateMap<BankMemberModel, BankMemberViewModel>().ReverseMap();
            CreateMap<BankMemberListModel, BankMemberListViewModel>().ReverseMap();
            CreateMap<MemberCreateEditViewModel, GeneralPersonViewModel>().ReverseMap();
            CreateMap<MemberCreateEditViewModel, GeneralPersonModel>().ReverseMap();
            #endregion
        }
    }
}
