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
            CreateMap<BankMemberNominee, BankMemberNomineeModel>().ReverseMap();
            CreateMap<BankInsurancePoliciesTypeModel, BankInsurancePoliciesType>().ReverseMap();
            CreateMap<BankSetupDivisionModel, BankSetupDivision>().ReverseMap();
            CreateMap<BankSetupOfficesModel, BankSetupOffices>().ReverseMap();
            CreateMap<BankSavingsAccountModel, BankSavingsAccount>().ReverseMap();
            CreateMap<BankSavingAccountIntrestPostingsModel, BankSavingAccountIntrestPostings>().ReverseMap();
            CreateMap<BankFixedDepositAccountModel, BankFixedDepositAccount>().ReverseMap();
            CreateMap<BankProductModel, BankProduct>().ReverseMap();
            CreateMap<BankPostingLoanAccountModel, BankPostingLoanAccount>().ReverseMap();
            CreateMap<BankSavingsAccount, BankSavingsAccountClosuresModel>().ReverseMap();
            CreateMap<BankSavingsAccountClosures, BankSavingsAccountClosuresModel>().ReverseMap();
            CreateMap<BankPostingLoanAccount, BankLoanForeClosuresModel>().ReverseMap();
            CreateMap<BankLoanForeClosures, BankLoanForeClosuresModel>().ReverseMap();
            CreateMap<BankFixedDepositAccount, BankFixedDepositClosureModel>().ReverseMap();
            CreateMap<BankFixedDepositClosure, BankFixedDepositClosureModel>().ReverseMap();
            CreateMap<BankRecurringDepositAccount, BankRecurringDepositAccountModel>().ReverseMap();
            CreateMap<BankFixedDepositAccount, BankFixedDepositInterestPostingsModel>().ReverseMap();
            CreateMap<BankFixedDepositInterestPostings, BankFixedDepositInterestPostingsModel>().ReverseMap();
            CreateMap<BankSavingsAccountTransactionsModel, BankSavingsAccountTransactions>().ReverseMap();
            CreateMap<BankLoanScheduleModel, BankLoanSchedule>().ReverseMap();
            CreateMap<BankRecurringDepositAccount, BankRecurringDepositClosureModel>().ReverseMap();
            CreateMap<BankRecurringDepositClosure, BankRecurringDepositClosureModel>().ReverseMap();
            CreateMap<BankRecurringDepositInterestPosting, BankRecurringDepositAccountModel>().ReverseMap();
            CreateMap<BankRecurringDepositInterestPosting, BankRecurringDepositInterestPostingModel>().ReverseMap();

            #endregion
        }
    }
}
