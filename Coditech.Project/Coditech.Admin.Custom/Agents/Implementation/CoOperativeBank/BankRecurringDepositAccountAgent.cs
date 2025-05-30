using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.API.Client;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Resources;
using System.Diagnostics;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.Admin.Agents
{
    public class BankRecurringDepositAccountAgent : BaseAgent, IBankRecurringDepositAccountAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankRecurringDepositAccountClient _bankRecurringDepositAccountClient;
        #endregion

        #region Public Constructor
        public BankRecurringDepositAccountAgent(ICoditechLogging coditechLogging, IBankRecurringDepositAccountClient bankRecurringDepositAccountClient)
        {
            _coditechLogging = coditechLogging;
            _bankRecurringDepositAccountClient = GetClient<IBankRecurringDepositAccountClient>(bankRecurringDepositAccountClient);
        }
        #endregion

        #region Public Methods
        public virtual BankRecurringDepositAccountListViewModel GetBankRecurringDepositAccountList(DataTableViewModel dataTableModel)
        {
            string centreCode = SessionHelper.GetDataFromSession<UserModel>(AdminConstants.UserDataSession)?.SelectedCentreCode;
            FilterCollection filters = new FilterCollection();
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {

                filters.Add("AccountNumber", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("StartDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("DurationMonths", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MaturityDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("ClosureDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankRecurringDepositAccountListResponse response = _bankRecurringDepositAccountClient.List(centreCode,null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankRecurringDepositAccountListModel BankRecurringDepositAccountList = new BankRecurringDepositAccountListModel { BankRecurringDepositAccountList = response?.BankRecurringDepositAccountList };
            BankRecurringDepositAccountListViewModel listViewModel = new BankRecurringDepositAccountListViewModel();
            listViewModel.BankRecurringDepositAccountList = BankRecurringDepositAccountList?.BankRecurringDepositAccountList?.ToViewModel<BankRecurringDepositAccountViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankRecurringDepositAccountList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankRecurringDepositAccount
        public virtual BankRecurringDepositAccountViewModel CreateBankRecurringDepositAccount(BankRecurringDepositAccountViewModel bankRecurringDepositAccountViewModel)
        {
            try
            {
                BankRecurringDepositAccountResponse response = _bankRecurringDepositAccountClient.CreateBankRecurringDepositAccount(bankRecurringDepositAccountViewModel.ToModel<BankRecurringDepositAccountModel>());
                BankRecurringDepositAccountModel bankRecurringDepositAccountModel = response?.BankRecurringDepositAccountModel;
                return IsNotNull(bankRecurringDepositAccountModel) ? bankRecurringDepositAccountModel.ToViewModel<BankRecurringDepositAccountViewModel>() : new BankRecurringDepositAccountViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankRecurringDepositAccountViewModel)GetViewModelWithErrorMessage(bankRecurringDepositAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankRecurringDepositAccountViewModel)GetViewModelWithErrorMessage(bankRecurringDepositAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Error);
                return (BankRecurringDepositAccountViewModel)GetViewModelWithErrorMessage(bankRecurringDepositAccountViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankRecurringDepositAccount by bankRecurringDepositAccountId.
        public virtual BankRecurringDepositAccountViewModel GetBankRecurringDepositAccount(int bankRecurringDepositAccountId)
        {
            BankRecurringDepositAccountResponse response = _bankRecurringDepositAccountClient.GetBankRecurringDepositAccount(bankRecurringDepositAccountId);
            return response?.BankRecurringDepositAccountModel.ToViewModel<BankRecurringDepositAccountViewModel>();
        }

        //Update BankRecurringDepositAccount.
        public virtual BankRecurringDepositAccountViewModel UpdateBankRecurringDepositAccount(BankRecurringDepositAccountViewModel bankRecurringDepositAccountViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankRecurringDepositAccount", TraceLevel.Info);
                BankRecurringDepositAccountResponse response = _bankRecurringDepositAccountClient.UpdateBankRecurringDepositAccount(bankRecurringDepositAccountViewModel.ToModel<BankRecurringDepositAccountModel>());
                BankRecurringDepositAccountModel bankRecurringDepositAccountModel = response?.BankRecurringDepositAccountModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankRecurringDepositAccount", TraceLevel.Info);
                return IsNotNull(bankRecurringDepositAccountModel) ? bankRecurringDepositAccountModel.ToViewModel<BankRecurringDepositAccountViewModel>() : (BankRecurringDepositAccountViewModel)GetViewModelWithErrorMessage(new BankRecurringDepositAccountViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankRecurringDepositAccount", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankRecurringDepositAccountViewModel)GetViewModelWithErrorMessage(bankRecurringDepositAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankRecurringDepositAccountViewModel)GetViewModelWithErrorMessage(bankRecurringDepositAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankRecurringDepositAccount", TraceLevel.Error);
                return (BankRecurringDepositAccountViewModel)GetViewModelWithErrorMessage(bankRecurringDepositAccountViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankRecurringDepositAccount.
        public virtual bool DeleteBankRecurringDepositAccount(string bankRecurringDepositAccountId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankRecurringDepositAccountClient.DeleteBankRecurringDepositAccount(new ParameterModel { Ids = bankRecurringDepositAccountId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankRecurringDepositAccount";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Error);
                errorMessage = GeneralResources.ErrorFailedToDelete;
                return false;
            }
        }
        #endregion

        #region protected
        protected virtual List<DatatableColumns> BindColumns()
        {
            List<DatatableColumns> datatableColumnList = new List<DatatableColumns>();
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Account Number",
                ColumnCode = "AccountNumber",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Start Date ",
                ColumnCode = "StartDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Duration Months ",
                ColumnCode = "DurationMonths",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Maturity Date ",
                ColumnCode = "MaturityDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Closure Date ",
                ColumnCode = "ClosureDate",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        //// it will return get all BankRecurringDepositAccount list from database 
        //public virtual BankRecurringDepositAccountListResponse GetBankRecurringDepositAccountList()
        //{
        //    BankRecurringDepositAccountListResponse BankRecurringDepositAccountList = _bankRecurringDepositAccountClient.List(null, null, null, 1, int.MaxValue);
        //    return BankRecurringDepositAccountList?.BankRecurringDepositAccountList?.Count > 0 ? BankRecurringDepositAccountList : new BankRecurringDepositAccountListResponse();
        //}
        #endregion
    }
}
