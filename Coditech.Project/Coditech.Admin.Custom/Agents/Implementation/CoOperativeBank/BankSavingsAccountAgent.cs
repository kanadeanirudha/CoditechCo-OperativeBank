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
    public class BankSavingsAccountAgent : BaseAgent, IBankSavingsAccountAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSavingsAccountClient _bankSavingsAccountClient;
        #endregion

        #region Public Constructor
        public BankSavingsAccountAgent(ICoditechLogging coditechLogging, IBankSavingsAccountClient bankSavingsAccountClient)
        {
            _coditechLogging = coditechLogging;
            _bankSavingsAccountClient = GetClient<IBankSavingsAccountClient>(bankSavingsAccountClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSavingsAccountListViewModel GetBankSavingsAccountList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("SavingAccountNumber", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("BalanceAmount", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankSavingsAccountListResponse response = _bankSavingsAccountClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSavingsAccountListModel BankSavingsAccountList = new BankSavingsAccountListModel { BankSavingsAccountList = response?.BankSavingsAccountList };
            BankSavingsAccountListViewModel listViewModel = new BankSavingsAccountListViewModel();
            listViewModel.BankSavingsAccountList = BankSavingsAccountList?.BankSavingsAccountList?.ToViewModel<BankSavingsAccountViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSavingsAccountList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankSavingsAccount
        public virtual BankSavingsAccountViewModel CreateBankSavingsAccount(BankSavingsAccountViewModel bankSavingsAccountViewModel)
        {
            try
            {
                BankSavingsAccountResponse response = _bankSavingsAccountClient.CreateBankSavingsAccount(bankSavingsAccountViewModel.ToModel<BankSavingsAccountModel>());
                BankSavingsAccountModel bankSavingsAccountModel = response?.BankSavingsAccountModel;
                return IsNotNull(bankSavingsAccountModel) ? bankSavingsAccountModel.ToViewModel<BankSavingsAccountViewModel>() : new BankSavingsAccountViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingsAccountViewModel)GetViewModelWithErrorMessage(bankSavingsAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingsAccountViewModel)GetViewModelWithErrorMessage(bankSavingsAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Error);
                return (BankSavingsAccountViewModel)GetViewModelWithErrorMessage(bankSavingsAccountViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSavingsAccount by bankSavingsAccountId.
        public virtual BankSavingsAccountViewModel GetBankSavingsAccount(long bankSavingsAccountId)
        {
            BankSavingsAccountResponse response = _bankSavingsAccountClient.GetBankSavingsAccount(bankSavingsAccountId);
            return response?.BankSavingsAccountModel.ToViewModel<BankSavingsAccountViewModel>();
        }

        //Update BankSavingsAccount.
        public virtual BankSavingsAccountViewModel UpdateBankSavingsAccount(BankSavingsAccountViewModel bankSavingsAccountViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Info);
                BankSavingsAccountResponse response = _bankSavingsAccountClient.UpdateBankSavingsAccount(bankSavingsAccountViewModel.ToModel<BankSavingsAccountModel>());
                BankSavingsAccountModel bankSavingsAccountModel = response?.BankSavingsAccountModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Info);
                return IsNotNull(bankSavingsAccountModel) ? bankSavingsAccountModel.ToViewModel<BankSavingsAccountViewModel>() : (BankSavingsAccountViewModel)GetViewModelWithErrorMessage(new BankSavingsAccountViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingsAccountViewModel)GetViewModelWithErrorMessage(bankSavingsAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingsAccountViewModel)GetViewModelWithErrorMessage(bankSavingsAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankSavingsAccountViewModel)GetViewModelWithErrorMessage(bankSavingsAccountViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSavingsAccount.
        public virtual bool DeleteBankSavingsAccount(string bankSavingsAccountId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSavingsAccountClient.DeleteBankSavingsAccount(new ParameterModel { Ids = bankSavingsAccountId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSavingsAccount";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Error);
                errorMessage = GeneralResources.ErrorFailedToDelete;
                return false;
            }
        }
        //Create Create BankSavingsAccountClosures
        public virtual BankSavingsAccountClosuresViewModel CreateBankSavingsAccountClosures(BankSavingsAccountClosuresViewModel bankSavingsAccountClosuresViewModel)
        {
            try
            {
                BankSavingsAccountClosuresResponse response = _bankSavingsAccountClient.CreateBankSavingsAccountClosures(bankSavingsAccountClosuresViewModel.ToModel<BankSavingsAccountClosuresModel>());
                BankSavingsAccountClosuresModel bankSavingsAccountClosuresModel = response?.BankSavingsAccountClosuresModel;
                return IsNotNull(bankSavingsAccountClosuresModel) ? bankSavingsAccountClosuresModel.ToViewModel<BankSavingsAccountClosuresViewModel>() : new BankSavingsAccountClosuresViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingsAccountClosuresViewModel)GetViewModelWithErrorMessage(bankSavingsAccountClosuresViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingsAccountClosuresViewModel)GetViewModelWithErrorMessage(bankSavingsAccountClosuresViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Error);
                return (BankSavingsAccountClosuresViewModel)GetViewModelWithErrorMessage(bankSavingsAccountClosuresViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSavingsAccountClosures by bankSavingsAccountId.
        public virtual BankSavingsAccountClosuresViewModel GetBankSavingsAccountClosures(long bankSavingsAccountId)
        {
            BankSavingsAccountClosuresResponse response = _bankSavingsAccountClient.GetBankSavingsAccountClosures(bankSavingsAccountId);
            return response?.BankSavingsAccountClosuresModel.ToViewModel<BankSavingsAccountClosuresViewModel>();
        }

        //Update BankSavingsAccountClosures.
        public virtual BankSavingsAccountClosuresViewModel UpdateBankSavingsAccountClosures(BankSavingsAccountClosuresViewModel bankSavingsAccountClosuresViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Info);
                BankSavingsAccountClosuresResponse response = _bankSavingsAccountClient.UpdateBankSavingsAccountClosures(bankSavingsAccountClosuresViewModel.ToModel<BankSavingsAccountClosuresModel>());
                BankSavingsAccountClosuresModel bankSavingsAccountClosuresModel = response?.BankSavingsAccountClosuresModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Info);
                return IsNotNull(bankSavingsAccountClosuresModel) ? bankSavingsAccountClosuresModel.ToViewModel<BankSavingsAccountClosuresViewModel>() : (BankSavingsAccountClosuresViewModel)GetViewModelWithErrorMessage(new BankSavingsAccountClosuresViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingsAccountClosuresViewModel)GetViewModelWithErrorMessage(bankSavingsAccountClosuresViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingsAccountClosuresViewModel)GetViewModelWithErrorMessage(bankSavingsAccountClosuresViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Error);
                return (BankSavingsAccountClosuresViewModel)GetViewModelWithErrorMessage(bankSavingsAccountClosuresViewModel, GeneralResources.UpdateErrorMessage);
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
                ColumnCode = "SavingAccountNumber",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Account Status",
                ColumnCode = "AccountStatusEnumId",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Balance Amount",
                ColumnCode = "BalanceAmount",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Opening Date",
                ColumnCode = "OpeningDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "KYC Status",
                ColumnCode = "KYCStatus",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        // it will return get all BankSavingsAccount list from database 
        public virtual BankSavingsAccountListResponse GetBankSavingsAccountList()
        {
            BankSavingsAccountListResponse BankSavingsAccountList = _bankSavingsAccountClient.List(null, null, null, 1, int.MaxValue);
            return BankSavingsAccountList?.BankSavingsAccountList?.Count > 0 ? BankSavingsAccountList : new BankSavingsAccountListResponse();
        }
        #endregion
    }
}
