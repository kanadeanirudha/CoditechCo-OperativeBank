using Coditech.Admin.ViewModel;
using Coditech.API.Client;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Resources;
using System.Diagnostics;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.Admin.Agents
{
    public class BankLoanScheduleAgent : BaseAgent, IBankLoanScheduleAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankLoanScheduleClient _bankLoanScheduleClient;
        #endregion

        #region Public Constructor
        public BankLoanScheduleAgent(ICoditechLogging coditechLogging, IBankLoanScheduleClient bankLoanScheduleClient)
        {
            _coditechLogging = coditechLogging;
            _bankLoanScheduleClient = GetClient<IBankLoanScheduleClient>(bankLoanScheduleClient);
        }
        #endregion

        #region Public Methods

        //Create BankLoanSchedule
        public virtual BankLoanScheduleViewModel CreateBankLoanSchedule(BankLoanScheduleViewModel bankLoanScheduleViewModel)
        {
            try
            {
                BankLoanScheduleResponse response = _bankLoanScheduleClient.CreateBankLoanSchedule(bankLoanScheduleViewModel.ToModel<BankLoanScheduleModel>());
                BankLoanScheduleModel bankLoanScheduleModel = response?.BankLoanScheduleModel;
                return IsNotNull(bankLoanScheduleModel) ? bankLoanScheduleModel.ToViewModel<BankLoanScheduleViewModel>() : new BankLoanScheduleViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankLoanScheduleViewModel)GetViewModelWithErrorMessage(bankLoanScheduleViewModel, ex.ErrorMessage);
                    default:
                        return (BankLoanScheduleViewModel)GetViewModelWithErrorMessage(bankLoanScheduleViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Error);
                return (BankLoanScheduleViewModel)GetViewModelWithErrorMessage(bankLoanScheduleViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankLoanSchedule by bankPostingLoanAccountId.
        public virtual BankLoanScheduleViewModel GetBankLoanSchedule(int bankPostingLoanAccountId)
        {
            BankLoanScheduleResponse response = _bankLoanScheduleClient.GetBankLoanSchedule(bankPostingLoanAccountId);
            return response?.BankLoanScheduleModel.ToViewModel<BankLoanScheduleViewModel>();
        }

        //Update BankLoanSchedule.
        public virtual BankLoanScheduleViewModel UpdateBankLoanSchedule(BankLoanScheduleViewModel bankLoanScheduleViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Info);
                BankLoanScheduleResponse response = _bankLoanScheduleClient.UpdateBankLoanSchedule(bankLoanScheduleViewModel.ToModel<BankLoanScheduleModel>());
                BankLoanScheduleModel bankLoanScheduleModel = response?.BankLoanScheduleModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Info);
                return IsNotNull(bankLoanScheduleModel) ? bankLoanScheduleModel.ToViewModel<BankLoanScheduleViewModel>() : (BankLoanScheduleViewModel)GetViewModelWithErrorMessage(new BankLoanScheduleViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankLoanScheduleViewModel)GetViewModelWithErrorMessage(bankLoanScheduleViewModel, ex.ErrorMessage);
                    default:
                        return (BankLoanScheduleViewModel)GetViewModelWithErrorMessage(bankLoanScheduleViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankLoanScheduleViewModel)GetViewModelWithErrorMessage(bankLoanScheduleViewModel, GeneralResources.UpdateErrorMessage);
            }
        }
        #endregion

    }
}
