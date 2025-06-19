using Coditech.Admin.Helpers;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.API.Client;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using static Coditech.Common.Helper.HelperUtility;

namespace Coditech.Admin.Agents
{
    public class CoOperativeUIAgent : BaseAgent, ICoOperativeUIAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoOperativeUIClient _coOperativeUIClient;
        private readonly IGeneralFinancialYearClient _generalFinancialYearClient;
        private readonly IUserClient _userClient;
        private readonly IBankMemberClient _bankMemberClient;
        #endregion

        #region Public Constructor
        public CoOperativeUIAgent(ICoditechLogging coditechLogging, ICoOperativeUIClient coOperativeUIClient, IGeneralFinancialYearClient generalFinancialYearClient, IUserClient userClient, IBankMemberClient bankMemberClient)
        {
            _coditechLogging = coditechLogging;
            _coOperativeUIClient = GetClient(coOperativeUIClient);
            _generalFinancialYearClient = generalFinancialYearClient;
            _userClient = GetClient<IUserClient>(userClient);
            _bankMemberClient = GetClient(bankMemberClient);
        }
        #endregion
        #region Public Methods
        public virtual CoOperativeUIViewModel GetCoOperativeUIDetails(string selectedcentreCode, int bankMemberId, int accSetupBalanceSheetId)
        {
            int selectedBalanceSheeetId = SessionHelper.GetDataFromSession<UserModel>(AdminConstants.UserDataSession)?.SelectedBalanceSheetId ?? 0;

            CoOperativeUIViewModel coOperativeUIViewModel = new CoOperativeUIViewModel();
            if (selectedBalanceSheeetId > 0)
            {
                CoOperativeUIResponse response = _coOperativeUIClient.GetCoOperativeUIDetails(selectedBalanceSheeetId);
                coOperativeUIViewModel = response?.CoOperativeUIModel?.ToViewModel<CoOperativeUIViewModel>();
            }
            return coOperativeUIViewModel;
        }
        public virtual GeneralFinancialYearModel GetCurrentFinancialYear()
        {
            int accSetupBalanceSheetId = AdminGeneralHelper.GetSelectedBalanceSheetId();
            GeneralFinancialYearResponse financialyearresponse = _generalFinancialYearClient.GetCurrentFinancialYear(accSetupBalanceSheetId);
            return financialyearresponse?.GeneralFinancialYearModel.ToViewModel<GeneralFinancialYearModel>();
        }
        public virtual MemberCreateEditViewModel GetCoOperativeUI(string centreCode, int bankMemberId)
        {
            // Get Bank Member Details
            BankMemberResponse bankMemberResponse = _bankMemberClient.GetMemberOtherDetail(bankMemberId);
            MemberCreateEditViewModel coOperativeUIViewModel = new MemberCreateEditViewModel();
            if (IsNotNull(bankMemberResponse))
            {
                coOperativeUIViewModel.PersonId = bankMemberResponse.BankMemberModel.PersonId;
                GeneralPersonResponse response = _userClient.GetPersonInformation(coOperativeUIViewModel.PersonId);
                coOperativeUIViewModel = response?.GeneralPersonModel.ToViewModel<MemberCreateEditViewModel>();
                coOperativeUIViewModel.SelectedCentreCode = bankMemberResponse.BankMemberModel.CentreCode;
                coOperativeUIViewModel.BankMemberId = bankMemberId;
            }          
            return coOperativeUIViewModel;
        }
        #endregion
    }
}
