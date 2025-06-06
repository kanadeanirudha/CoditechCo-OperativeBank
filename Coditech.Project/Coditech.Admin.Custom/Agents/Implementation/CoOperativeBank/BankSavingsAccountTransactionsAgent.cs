using Coditech.Admin.Custom.Agents.Interface.CoOperativeBank;
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
    public class BankSavingsAccountTransactionsAgent : BaseAgent, IBankSavingsAccountTransactionsAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSavingsAccountTransactionsClient _bankSavingsAccountTransactionsClient;
        #endregion

        #region Public Constructor
        public BankSavingsAccountTransactionsAgent(ICoditechLogging coditechLogging, IBankSavingsAccountTransactionsClient bankSavingsAccountTransactionsClient)
        {
            _coditechLogging = coditechLogging;
            _bankSavingsAccountTransactionsClient = GetClient<IBankSavingsAccountTransactionsClient>(bankSavingsAccountTransactionsClient);
        }
        #endregion

        #region Public Methods

        //Create BankSavingsAccountTransactions
        public virtual BankSavingsAccountTransactionsViewModel CreateBankSavingsAccountTransactions(BankSavingsAccountTransactionsViewModel bankSavingsAccountTransactionsViewModel)
        {
            try
            {
                BankSavingsAccountTransactionsResponse response = _bankSavingsAccountTransactionsClient.CreateBankSavingsAccountTransactions(bankSavingsAccountTransactionsViewModel.ToModel<BankSavingsAccountTransactionsModel>());
                BankSavingsAccountTransactionsModel bankSavingsAccountTransactionsModel = response?.BankSavingsAccountTransactionsModel;
                return IsNotNull(bankSavingsAccountTransactionsModel) ? bankSavingsAccountTransactionsModel.ToViewModel<BankSavingsAccountTransactionsViewModel>() : new BankSavingsAccountTransactionsViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingsAccountTransactionsViewModel)GetViewModelWithErrorMessage(bankSavingsAccountTransactionsViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingsAccountTransactionsViewModel)GetViewModelWithErrorMessage(bankSavingsAccountTransactionsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Error);
                return (BankSavingsAccountTransactionsViewModel)GetViewModelWithErrorMessage(bankSavingsAccountTransactionsViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSavingsAccountTransactions by bankSavingsAccountId.
        public virtual BankSavingsAccountTransactionsViewModel GetBankSavingsAccountTransactions(long bankSavingsAccountId)
        {
            BankSavingsAccountTransactionsResponse response = _bankSavingsAccountTransactionsClient.GetBankSavingsAccountTransactions(bankSavingsAccountId);
            return response?.BankSavingsAccountTransactionsModel.ToViewModel<BankSavingsAccountTransactionsViewModel>();
        }

        //Update BankSavingsAccountTransactions.
        public virtual BankSavingsAccountTransactionsViewModel UpdateBankSavingsAccountTransactions(BankSavingsAccountTransactionsViewModel bankSavingsAccountTransactionsViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Info);
                BankSavingsAccountTransactionsResponse response = _bankSavingsAccountTransactionsClient.UpdateBankSavingsAccountTransactions(bankSavingsAccountTransactionsViewModel.ToModel<BankSavingsAccountTransactionsModel>());
                BankSavingsAccountTransactionsModel bankSavingsAccountTransactionsModel = response?.BankSavingsAccountTransactionsModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Info);
                return IsNotNull(bankSavingsAccountTransactionsModel) ? bankSavingsAccountTransactionsModel.ToViewModel<BankSavingsAccountTransactionsViewModel>() : (BankSavingsAccountTransactionsViewModel)GetViewModelWithErrorMessage(new BankSavingsAccountTransactionsViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingsAccountTransactionsViewModel)GetViewModelWithErrorMessage(bankSavingsAccountTransactionsViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingsAccountTransactionsViewModel)GetViewModelWithErrorMessage(bankSavingsAccountTransactionsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankSavingsAccountTransactionsViewModel)GetViewModelWithErrorMessage(bankSavingsAccountTransactionsViewModel, GeneralResources.UpdateErrorMessage);
            }
        }
        #endregion

    }
}
