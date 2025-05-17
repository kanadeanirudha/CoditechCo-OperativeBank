using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Common.Service;

using static Coditech.Common.Helper.HelperUtility;

namespace Coditech.API.Service
{
    public class BankUserService : UserService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankMember> _bankMemberDetailsRepository;

        public BankUserService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider, ICoditechEmail coditechEmail, ICoditechSMS coditechSMS, ICoditechWhatsApp coditechWhatsApp) : base(coditechLogging, serviceProvider, coditechEmail, coditechSMS, coditechWhatsApp)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankMemberDetailsRepository = new CoditechRepository<BankMember>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        protected override GeneralPersonModel GetGeneralPersonDetailsByEntityType(long entityId, string entityType)
        {
            long personId = 0;
            string centreCode = string.Empty;
            string personCode = string.Empty;
            short generalDepartmentMasterId = 0;
            if (entityType == UserTypeCustomEnum.BankMember.ToString())
            {
                BankMember bankMemberDetails = new CoditechRepository<BankMember>(_serviceProvider.GetService<CoditechCustom_Entities>()).Table.Where(x => x.BankMemberId == entityId)?.FirstOrDefault();
                if (IsNotNull(bankMemberDetails))
                {
                    personId = bankMemberDetails.PersonId;
                    centreCode = bankMemberDetails.CentreCode;
                }
                return base.BindGeneralPersonInformation(personId, centreCode, personCode, generalDepartmentMasterId, bankMemberDetails.IsActive);
            }
            else
            {
                return base.GetGeneralPersonDetailsByEntityType(entityId, entityType);
            }
        }

        protected override void InsertPersonDetails(GeneralPersonModel generalPersonModel, List<GeneralSystemGlobleSettingModel> settingMasterList)
        {
            if (generalPersonModel.UserType.Equals(UserTypeCustomEnum.BankMember.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                InsertBankMember(generalPersonModel, settingMasterList);
            }
            else
            {
                base.InsertPersonDetails(generalPersonModel, settingMasterList);
            }
        }
        protected override bool ValidateUserwiseGeneralPerson(GeneralPersonModel generalPersonModel, ref string errorMessage, ref int generalEnumaratorId)
        {
            if (generalPersonModel.UserType.Equals(UserTypeCustomEnum.BankMember.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(generalPersonModel.SelectedCentreCode))
                {
                    errorMessage = "Selected Centre Code is Required.";
                    return false;
                }
                generalEnumaratorId = GetEnumIdByEnumCode(GeneralRunningNumberForCustomEnum.BankMemberRegistration.ToString(), GeneralEnumaratorGroupCodeEnum.GeneralRunningNumberFor.ToString());
                if (generalEnumaratorId == 0)
                {
                    errorMessage = "BankMemberRegistration is null";
                    return false;
                }
                return true;
            }
            else
            {
                return base.ValidateUserwiseGeneralPerson(generalPersonModel, ref errorMessage, ref generalEnumaratorId);
            }
        }

        private void InsertBankMember(GeneralPersonModel generalPersonModel, List<GeneralSystemGlobleSettingModel> settingMasterList)
        {
            generalPersonModel.PersonCode = GenerateRegistrationCode(GeneralRunningNumberForCustomEnum.BankMemberRegistration.ToString(), generalPersonModel.SelectedCentreCode);
            BankMember bankMemberDetails = new BankMember()
            {
                CentreCode = generalPersonModel.SelectedCentreCode,
                PersonId = generalPersonModel.PersonId,
                MemberCode = generalPersonModel.PersonCode,
                UserType = generalPersonModel.UserType,
                JoiningDate = DateTime.Now           
            };
            bankMemberDetails = _bankMemberDetailsRepository.Insert(bankMemberDetails);
        }

        protected virtual string ReplaceBankMemberEmailTemplate(GeneralPersonModel generalPersonModel, string emailTemplate)
        {
            string messageText = emailTemplate;
            messageText = ReplaceTokenWithMessageText(EmailTemplateTokenConstant.FirstName, generalPersonModel.FirstName, messageText);
            messageText = ReplaceTokenWithMessageText(EmailTemplateTokenConstant.LastName, generalPersonModel.LastName, messageText);
            return ReplaceEmailTemplateFooter(generalPersonModel.SelectedCentreCode, messageText);
        }
    }
}
