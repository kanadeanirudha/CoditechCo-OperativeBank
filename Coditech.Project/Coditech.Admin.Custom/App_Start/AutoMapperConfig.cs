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
            CreateMap<BankSetupOfficesModel, BankSetupOfficesViewModel>().ReverseMap();
            CreateMap<BankSetupOfficesViewModel, BankSetupOfficesListViewModel>().ReverseMap();
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
            CreateMap<MemberCreateEditViewModel, BankMemberModel>().ReverseMap();
            CreateMap<BankMemberNomineeModel, BankMemberNomineeViewModel>().ReverseMap();
            CreateMap<BankMemberNomineeListModel, BankMemberNomineeListViewModel>().ReverseMap();
            CreateMap<MemberNomineeCreateEditViewModel, GeneralPersonViewModel>().ReverseMap();
            CreateMap<MemberNomineeCreateEditViewModel, GeneralPersonModel>().ReverseMap();
            CreateMap<BankSavingsAccountModel, BankSavingsAccountViewModel>().ReverseMap();
            CreateMap<BankSavingsAccountListModel, BankSavingsAccountListViewModel>().ReverseMap();
            CreateMap<BankSavingAccountIntrestPostingsModel, BankSavingAccountIntrestPostingsViewModel>().ReverseMap();
            CreateMap<BankSavingAccountIntrestPostingsListModel, BankSavingAccountIntrestPostingsListViewModel>().ReverseMap();
            CreateMap<BankFixedDepositAccountModel, BankFixedDepositAccountViewModel>().ReverseMap();
            CreateMap<BankFixedDepositAccountListModel, BankFixedDepositAccountListViewModel>().ReverseMap();
            CreateMap<BankProductModel, BankProductViewModel>().ReverseMap();
            CreateMap<BankProductListModel, BankProductListViewModel>().ReverseMap();
            CreateMap<BankPostingLoanAccountModel, BankPostingLoanAccountViewModel>().ReverseMap();
            CreateMap<BankPostingLoanAccountListModel, BankPostingLoanAccountListViewModel>().ReverseMap();

            #endregion
        }
    }
}
