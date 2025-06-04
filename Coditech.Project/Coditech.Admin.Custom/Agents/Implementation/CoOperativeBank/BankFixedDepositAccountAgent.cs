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
    public class BankFixedDepositAccountAgent : BaseAgent, IBankFixedDepositAccountAgent
    {

        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankFixedDepositAccountClient _bankFixedDepositAccountClient;
        #endregion

        #region Public Constructor
        public BankFixedDepositAccountAgent(ICoditechLogging coditechLogging, IBankFixedDepositAccountClient bankFixedDepositAccountClient)
        {
            _coditechLogging = coditechLogging;
            _bankFixedDepositAccountClient = GetClient<IBankFixedDepositAccountClient>(bankFixedDepositAccountClient);
        }
        #endregion

        #region Public Methods
        public virtual BankFixedDepositAccountListViewModel GetBankFixedDepositAccountList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = new FilterCollection();
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dataTableModel.SelectedCentreCode);
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters.Add("FixedDepositAccountNumber", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("StartDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("TenureMonths", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MaturityDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MaturityAmount", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("ClosureDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankFixedDepositAccountListResponse response = _bankFixedDepositAccountClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankFixedDepositAccountListModel BankFixedDepositAccountList = new BankFixedDepositAccountListModel { BankFixedDepositAccountList = response?.BankFixedDepositAccountList };
            BankFixedDepositAccountListViewModel listViewModel = new BankFixedDepositAccountListViewModel();
            listViewModel.BankFixedDepositAccountList = BankFixedDepositAccountList?.BankFixedDepositAccountList?.ToViewModel<BankFixedDepositAccountViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankFixedDepositAccountList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankFixedDepositAccount
        public virtual BankFixedDepositAccountViewModel CreateBankFixedDepositAccount(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel)
        {
            try
            {
                BankFixedDepositAccountResponse response = _bankFixedDepositAccountClient.CreateBankFixedDepositAccount(bankFixedDepositAccountViewModel.ToModel<BankFixedDepositAccountModel>());
                BankFixedDepositAccountModel bankFixedDepositAccountModel = response?.BankFixedDepositAccountModel;
                return IsNotNull(bankFixedDepositAccountModel) ? bankFixedDepositAccountModel.ToViewModel<BankFixedDepositAccountViewModel>() : new BankFixedDepositAccountViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankFixedDepositAccountViewModel)GetViewModelWithErrorMessage(bankFixedDepositAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankFixedDepositAccountViewModel)GetViewModelWithErrorMessage(bankFixedDepositAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Error);
                return (BankFixedDepositAccountViewModel)GetViewModelWithErrorMessage(bankFixedDepositAccountViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankFixedDepositAccount by bankFixedDepositAccountId.
        public virtual BankFixedDepositAccountViewModel GetBankFixedDepositAccount(short bankFixedDepositAccountId)
        {
            BankFixedDepositAccountResponse response = _bankFixedDepositAccountClient.GetBankFixedDepositAccount(bankFixedDepositAccountId);
            return response?.BankFixedDepositAccountModel.ToViewModel<BankFixedDepositAccountViewModel>();
        }

        //Update BankFixedDepositAccount.
        public virtual BankFixedDepositAccountViewModel UpdateBankFixedDepositAccount(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Info);
                BankFixedDepositAccountResponse response = _bankFixedDepositAccountClient.UpdateBankFixedDepositAccount(bankFixedDepositAccountViewModel.ToModel<BankFixedDepositAccountModel>());
                BankFixedDepositAccountModel bankFixedDepositAccountModel = response?.BankFixedDepositAccountModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Info);
                return IsNotNull(bankFixedDepositAccountModel) ? bankFixedDepositAccountModel.ToViewModel<BankFixedDepositAccountViewModel>() : (BankFixedDepositAccountViewModel)GetViewModelWithErrorMessage(new BankFixedDepositAccountViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankFixedDepositAccountViewModel)GetViewModelWithErrorMessage(bankFixedDepositAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankFixedDepositAccountViewModel)GetViewModelWithErrorMessage(bankFixedDepositAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Error);
                return (BankFixedDepositAccountViewModel)GetViewModelWithErrorMessage(bankFixedDepositAccountViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankFixedDepositAccount.
        public virtual bool DeleteBankFixedDepositAccount(string bankFixedDepositAccountId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankFixedDepositAccountClient.DeleteBankFixedDepositAccount(new ParameterModel { Ids = bankFixedDepositAccountId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankFixedDepositAccount";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Error);
                errorMessage = GeneralResources.ErrorFailedToDelete;
                return false;
            }
        }
        #region BankFixedDepositClosure

        //Create BankFixedDepositClosure
        public virtual BankFixedDepositClosureViewModel CreateBankFixedDepositClosure(BankFixedDepositClosureViewModel bankFixedDepositClosureViewModel)
        {
            try
            {
                BankFixedDepositClosureResponse response = _bankFixedDepositAccountClient.CreateBankFixedDepositClosure(bankFixedDepositClosureViewModel.ToModel<BankFixedDepositClosureModel>());
                BankFixedDepositClosureModel bankFixedDepositClosureModel = response?.BankFixedDepositClosureModel;
                return IsNotNull(bankFixedDepositClosureModel) ? bankFixedDepositClosureModel.ToViewModel<BankFixedDepositClosureViewModel>() : new BankFixedDepositClosureViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankFixedDepositClosureViewModel)GetViewModelWithErrorMessage(bankFixedDepositClosureViewModel, ex.ErrorMessage);
                    default:
                        return (BankFixedDepositClosureViewModel)GetViewModelWithErrorMessage(bankFixedDepositClosureViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Error);
                return (BankFixedDepositClosureViewModel)GetViewModelWithErrorMessage(bankFixedDepositClosureViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankFixedDepositClosure by bankFixedDepositAccountId.
        public virtual BankFixedDepositClosureViewModel GetBankFixedDepositClosure(short bankFixedDepositAccountId)
        {
            BankFixedDepositClosureResponse response = _bankFixedDepositAccountClient.GetBankFixedDepositClosure(bankFixedDepositAccountId);
            return response?.BankFixedDepositClosureModel.ToViewModel<BankFixedDepositClosureViewModel>();
        }

        //Update BankFixedDepositClosure.
        public virtual BankFixedDepositClosureViewModel UpdateBankFixedDepositClosure(BankFixedDepositClosureViewModel bankFixedDepositClosureViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Info);
                BankFixedDepositClosureResponse response = _bankFixedDepositAccountClient.UpdateBankFixedDepositClosure(bankFixedDepositClosureViewModel.ToModel<BankFixedDepositClosureModel>());
                BankFixedDepositClosureModel bankFixedDepositClosureModel = response?.BankFixedDepositClosureModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Info);
                return IsNotNull(bankFixedDepositClosureModel) ? bankFixedDepositClosureModel.ToViewModel<BankFixedDepositClosureViewModel>() : (BankFixedDepositClosureViewModel)GetViewModelWithErrorMessage(new BankFixedDepositClosureViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankFixedDepositClosureViewModel)GetViewModelWithErrorMessage(bankFixedDepositClosureViewModel, ex.ErrorMessage);
                    default:
                        return (BankFixedDepositClosureViewModel)GetViewModelWithErrorMessage(bankFixedDepositClosureViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Error);
                return (BankFixedDepositClosureViewModel)GetViewModelWithErrorMessage(bankFixedDepositClosureViewModel, GeneralResources.UpdateErrorMessage);
            }
        }
        #endregion
        #region BankFixedDepositInterestPostings

        //Create BankFixedDepositInterestPostings
        public virtual BankFixedDepositInterestPostingsViewModel CreateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsViewModel bankFixedDepositInterestPostingsViewModel)
        {
            try
            {
                BankFixedDepositInterestPostingsResponse response = _bankFixedDepositAccountClient.CreateBankFixedDepositInterestPostings(bankFixedDepositInterestPostingsViewModel.ToModel<BankFixedDepositInterestPostingsModel>());
                BankFixedDepositInterestPostingsModel bankFixedDepositInterestPostingsModel = response?.BankFixedDepositInterestPostingsModel;
                return IsNotNull(bankFixedDepositInterestPostingsModel) ? bankFixedDepositInterestPostingsModel.ToViewModel<BankFixedDepositInterestPostingsViewModel>() : new BankFixedDepositInterestPostingsViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankFixedDepositInterestPostingsViewModel)GetViewModelWithErrorMessage(bankFixedDepositInterestPostingsViewModel, ex.ErrorMessage);
                    default:
                        return (BankFixedDepositInterestPostingsViewModel)GetViewModelWithErrorMessage(bankFixedDepositInterestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Error);
                return (BankFixedDepositInterestPostingsViewModel)GetViewModelWithErrorMessage(bankFixedDepositInterestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankFixedDepositInterestPostings by bankFixedDepositAccountId.
        public virtual BankFixedDepositInterestPostingsViewModel GetBankFixedDepositInterestPostings(short bankFixedDepositAccountId)
        {
            BankFixedDepositInterestPostingsResponse response = _bankFixedDepositAccountClient.GetBankFixedDepositInterestPostings(bankFixedDepositAccountId);
            return response?.BankFixedDepositInterestPostingsModel.ToViewModel<BankFixedDepositInterestPostingsViewModel>();
        }

        //Update BankFixedDepositInterestPostings.
        public virtual BankFixedDepositInterestPostingsViewModel UpdateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsViewModel bankFixedDepositInterestPostingsViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Info);
                BankFixedDepositInterestPostingsResponse response = _bankFixedDepositAccountClient.UpdateBankFixedDepositInterestPostings(bankFixedDepositInterestPostingsViewModel.ToModel<BankFixedDepositInterestPostingsModel>());
                BankFixedDepositInterestPostingsModel bankFixedDepositInterestPostingsModel = response?.BankFixedDepositInterestPostingsModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Info);
                return IsNotNull(bankFixedDepositInterestPostingsModel) ? bankFixedDepositInterestPostingsModel.ToViewModel<BankFixedDepositInterestPostingsViewModel>() : (BankFixedDepositInterestPostingsViewModel)GetViewModelWithErrorMessage(new BankFixedDepositInterestPostingsViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankFixedDepositInterestPostingsViewModel)GetViewModelWithErrorMessage(bankFixedDepositInterestPostingsViewModel, ex.ErrorMessage);
                    default:
                        return (BankFixedDepositInterestPostingsViewModel)GetViewModelWithErrorMessage(bankFixedDepositInterestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Error);
                return (BankFixedDepositInterestPostingsViewModel)GetViewModelWithErrorMessage(bankFixedDepositInterestPostingsViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        #endregion
        #endregion

        #region protected
        protected virtual List<DatatableColumns> BindColumns()
        {
            List<DatatableColumns> datatableColumnList = new List<DatatableColumns>();
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Fixed Deposit Account Number",
                ColumnCode = "FixedDepositAccountNumber",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Start Date",
                ColumnCode = "StartDate",
                IsSortable = true,
            });

            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Tenure Months",
                ColumnCode = "TenureMonths",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Maturity Date",
                ColumnCode = "MaturityDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Maturity Amount",
                ColumnCode = "MaturityAmount",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Closure Date",
                ColumnCode = "ClosureDate",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
    }
}
