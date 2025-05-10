using AutoMapper;
using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;

namespace Coditech.API.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FilterTuple, FilterDataTuple>().ReverseMap();
            CreateMap<GeneralPerson, GeneralPersonModel>().ReverseMap();
            CreateMap<UserMaster, GeneralPersonModel>().ReverseMap();
            CreateMap<AdminSanctionPostModel, AdminSanctionPost>().ReverseMap();

            #region CoOperativeBank
            CreateMap<BankSetupMortagePropertyType, BankSetupMortagePropertyTypeModel>().ReverseMap();
            CreateMap<BankVehicleModel, BankVehicleModelModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuers, BankSetupPropertyValuersModel>().ReverseMap();
            CreateMap<BankSetupPropertyValuersAuthority, BankSetupPropertyValuersAuthorityModel>().ReverseMap();
            CreateMap<BankMemberShareCapital, BankMemberShareCapitalModel>().ReverseMap();
            CreateMap<BankMember, BankMemberModel>().ReverseMap();
            CreateMap<BankInsurancePoliciesTypeModel, BankInsurancePoliciesType>().ReverseMap();
            CreateMap<BankSetupDivisionModel, BankSetupDivision>().ReverseMap();
            CreateMap<BankSetupOfficesModel, BankSetupOffices>().ReverseMap();
            CreateMap<BankSavingsAccountModel, BankSavingsAccount>().ReverseMap();
            CreateMap<BankSavingAccountIntrestPostingsModel, BankSavingAccountIntrestPostings>().ReverseMap();

            #endregion

        }
    }
}
