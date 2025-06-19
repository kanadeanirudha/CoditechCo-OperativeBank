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
    public class BankSavingAccountInterestPostingsAgent : BaseAgent, IBankSavingAccountInterestPostingsAgent
    {

        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSavingAccountInterestPostingsClient _bankSavingAccountInterestPostingsClient;
        #endregion

        #region Public Constructor
        public BankSavingAccountInterestPostingsAgent(ICoditechLogging coditechLogging, IBankSavingAccountInterestPostingsClient bankSavingAccountInterestPostingsClient)
        {
            _coditechLogging = coditechLogging;
            _bankSavingAccountInterestPostingsClient = GetClient<IBankSavingAccountInterestPostingsClient>(bankSavingAccountInterestPostingsClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSavingAccountInterestPostingsListViewModel GetBankSavingAccountInterestPostingsList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("PeriodStartDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("PeriodEndDate", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("InterestAmount", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("PostedOn", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankSavingAccountInterestPostingsListResponse response = _bankSavingAccountInterestPostingsClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSavingAccountInterestPostingsListModel BankSavingAccountInterestPostingsList = new BankSavingAccountInterestPostingsListModel { BankSavingAccountInterestPostingsList = response?.BankSavingAccountInterestPostingsList };
            BankSavingAccountInterestPostingsListViewModel listViewModel = new BankSavingAccountInterestPostingsListViewModel();
            listViewModel.BankSavingAccountInterestPostingsList = BankSavingAccountInterestPostingsList?.BankSavingAccountInterestPostingsList?.ToViewModel<BankSavingAccountInterestPostingsViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSavingAccountInterestPostingsList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankSavingAccountIntrestPostings
        public virtual BankSavingAccountInterestPostingsViewModel CreateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsViewModel bankSavingAccountInterestPostingsViewModel)
        {
            try
            {
                BankSavingAccountInterestPostingsResponse response = _bankSavingAccountInterestPostingsClient.CreateBankSavingAccountInterestPostings(bankSavingAccountInterestPostingsViewModel.ToModel<BankSavingAccountInterestPostingsModel>());
                BankSavingAccountInterestPostingsModel bankSavingAccountInterestPostingsModel = response?.BankSavingAccountInterestPostingsModel;
                return IsNotNull(bankSavingAccountInterestPostingsModel) ? bankSavingAccountInterestPostingsModel.ToViewModel<BankSavingAccountInterestPostingsViewModel>() : new BankSavingAccountInterestPostingsViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingAccountInterestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountInterestPostingsViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingAccountInterestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountInterestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Error);
                return (BankSavingAccountInterestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountInterestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        public virtual BankSavingAccountInterestPostingsViewModel GetBankSavingAccountInterestPostings(int bankSavingsAccountId)
        {
            BankSavingAccountInterestPostingsResponse response = _bankSavingAccountInterestPostingsClient.GetBankSavingAccountInterestPostings(bankSavingsAccountId);
            return response?.BankSavingAccountInterestPostingsModel.ToViewModel<BankSavingAccountInterestPostingsViewModel>();
        }

        //Update BankSavingAccountIntrestPostings.
        public virtual BankSavingAccountInterestPostingsViewModel UpdateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsViewModel bankSavingAccountInterestPostingsViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Info);
                BankSavingAccountInterestPostingsResponse response = _bankSavingAccountInterestPostingsClient.UpdateBankSavingAccountInterestPostings(bankSavingAccountInterestPostingsViewModel.ToModel<BankSavingAccountInterestPostingsModel>());
                BankSavingAccountInterestPostingsModel bankSavingAccountInterestPostingsModel = response?.BankSavingAccountInterestPostingsModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Info);
                return IsNotNull(bankSavingAccountInterestPostingsModel) ? bankSavingAccountInterestPostingsModel.ToViewModel<BankSavingAccountInterestPostingsViewModel>() : (BankSavingAccountInterestPostingsViewModel)GetViewModelWithErrorMessage(new BankSavingAccountInterestPostingsViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingAccountInterestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountInterestPostingsViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingAccountInterestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountInterestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankSavingAccountInterestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountInterestPostingsViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSavingAccountIntrestPostings.
        public virtual bool DeleteBankSavingAccountInterestPostings(string bankSavingAccountInterestPostingsId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSavingAccountInterestPostingsClient.DeleteBankSavingAccountInterestPostings(new ParameterModel { Ids = bankSavingAccountInterestPostingsId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSavingAccountInterestPostings";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Error);
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
                ColumnName = "Period Start Date",
                ColumnCode = "PeriodStartDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Period End Date",
                ColumnCode = "PeriodEndDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Interest Amount",
                ColumnCode = "InterestAmount",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Posted On",
                ColumnCode = "PostedOn",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
    }
}
