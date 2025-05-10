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
    public class BankSavingAccountIntrestPostingsAgent : BaseAgent, IBankSavingAccountIntrestPostingsAgent
    {

        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSavingAccountIntrestPostingsClient _bankSavingAccountIntrestPostingsClient;
        #endregion

        #region Public Constructor
        public BankSavingAccountIntrestPostingsAgent(ICoditechLogging coditechLogging, IBankSavingAccountIntrestPostingsClient bankSavingAccountIntrestPostingsClient)
        {
            _coditechLogging = coditechLogging;
            _bankSavingAccountIntrestPostingsClient = GetClient<IBankSavingAccountIntrestPostingsClient>(bankSavingAccountIntrestPostingsClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSavingAccountIntrestPostingsListViewModel GetBankSavingAccountIntrestPostingsList(DataTableViewModel dataTableModel)
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

            BankSavingAccountIntrestPostingsListResponse response = _bankSavingAccountIntrestPostingsClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSavingAccountIntrestPostingsListModel BankSavingAccountIntrestPostingsList = new BankSavingAccountIntrestPostingsListModel { BankSavingAccountIntrestPostingsList = response?.BankSavingAccountIntrestPostingsList };
            BankSavingAccountIntrestPostingsListViewModel listViewModel = new BankSavingAccountIntrestPostingsListViewModel();
            listViewModel.BankSavingAccountIntrestPostingsList = BankSavingAccountIntrestPostingsList?.BankSavingAccountIntrestPostingsList?.ToViewModel<BankSavingAccountIntrestPostingsViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSavingAccountIntrestPostingsList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankSavingAccountIntrestPostings
        public virtual BankSavingAccountIntrestPostingsViewModel CreateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel)
        {
            try
            {
                BankSavingAccountIntrestPostingsResponse response = _bankSavingAccountIntrestPostingsClient.CreateBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsViewModel.ToModel<BankSavingAccountIntrestPostingsModel>());
                BankSavingAccountIntrestPostingsModel bankSavingAccountIntrestPostingsModel = response?.BankSavingAccountIntrestPostingsModel;
                return IsNotNull(bankSavingAccountIntrestPostingsModel) ? bankSavingAccountIntrestPostingsModel.ToViewModel<BankSavingAccountIntrestPostingsViewModel>() : new BankSavingAccountIntrestPostingsViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingAccountIntrestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountIntrestPostingsViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingAccountIntrestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountIntrestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Error);
                return (BankSavingAccountIntrestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountIntrestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        public virtual BankSavingAccountIntrestPostingsViewModel GetBankSavingAccountIntrestPostings(int bankSavingAccountIntrestPostingsId)
        {
            BankSavingAccountIntrestPostingsResponse response = _bankSavingAccountIntrestPostingsClient.GetBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsId);
            return response?.BankSavingAccountIntrestPostingsModel.ToViewModel<BankSavingAccountIntrestPostingsViewModel>();
        }

        //Update BankSavingAccountIntrestPostings.
        public virtual BankSavingAccountIntrestPostingsViewModel UpdateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Info);
                BankSavingAccountIntrestPostingsResponse response = _bankSavingAccountIntrestPostingsClient.UpdateBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsViewModel.ToModel<BankSavingAccountIntrestPostingsModel>());
                BankSavingAccountIntrestPostingsModel bankSavingAccountIntrestPostingsModel = response?.BankSavingAccountIntrestPostingsModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Info);
                return IsNotNull(bankSavingAccountIntrestPostingsModel) ? bankSavingAccountIntrestPostingsModel.ToViewModel<BankSavingAccountIntrestPostingsViewModel>() : (BankSavingAccountIntrestPostingsViewModel)GetViewModelWithErrorMessage(new BankSavingAccountIntrestPostingsViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSavingAccountIntrestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountIntrestPostingsViewModel, ex.ErrorMessage);
                    default:
                        return (BankSavingAccountIntrestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountIntrestPostingsViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankSavingAccountIntrestPostingsViewModel)GetViewModelWithErrorMessage(bankSavingAccountIntrestPostingsViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSavingAccountIntrestPostings.
        public virtual bool DeleteBankSavingAccountIntrestPostings(string bankSavingAccountIntrestPostingsId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSavingAccountIntrestPostingsClient.DeleteBankSavingAccountIntrestPostings(new ParameterModel { Ids = bankSavingAccountIntrestPostingsId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSavingAccountIntrestPostings";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Error);
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
        #region
        // it will return get all BankSavingAccountIntrestPostings list from database 
        public virtual BankSavingAccountIntrestPostingsListResponse GetBankSavingAccountIntrestPostingsList()
        {
            BankSavingAccountIntrestPostingsListResponse BankSavingAccountIntrestPostingsList = _bankSavingAccountIntrestPostingsClient.List(null, null, null, 1, int.MaxValue);
            return BankSavingAccountIntrestPostingsList?.BankSavingAccountIntrestPostingsList?.Count > 0 ? BankSavingAccountIntrestPostingsList : new BankSavingAccountIntrestPostingsListResponse();
        }
        #endregion
    }
}
