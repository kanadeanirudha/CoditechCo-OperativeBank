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
    public class BankSetupOfficesAgent : BaseAgent, IBankSetupOfficesAgent
    {

        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSetupOfficesClient _bankSetupOfficesClient;
        #endregion

        #region Public Constructor
        public BankSetupOfficesAgent(ICoditechLogging coditechLogging, IBankSetupOfficesClient bankSetupOfficesClient)
        {
            _coditechLogging = coditechLogging;
            _bankSetupOfficesClient = GetClient<IBankSetupOfficesClient>(bankSetupOfficesClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSetupOfficesListViewModel GetBankSetupOfficesList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("Office", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("LOffice", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "Office" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankSetupOfficesListResponse response = _bankSetupOfficesClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSetupOfficesListModel BankSetupOfficesList = new BankSetupOfficesListModel { BankSetupOfficesList = response?.BankSetupOfficesList };
            BankSetupOfficesListViewModel listViewModel = new BankSetupOfficesListViewModel();
            listViewModel.BankSetupOfficesList = BankSetupOfficesList?.BankSetupOfficesList?.ToViewModel<BankSetupOfficesViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSetupOfficesList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankSetupOffices
        public virtual BankSetupOfficesViewModel CreateBankSetupOffices(BankSetupOfficesViewModel bankSetupOfficesViewModel)
        {
            try
            {
                BankSetupOfficesResponse response = _bankSetupOfficesClient.CreateBankSetupOffices(bankSetupOfficesViewModel.ToModel<BankSetupOfficesModel>());
                BankSetupOfficesModel bankSetupOfficesModel = response?.BankSetupOfficesModel;
                return IsNotNull(bankSetupOfficesModel) ? bankSetupOfficesModel.ToViewModel<BankSetupOfficesViewModel>() : new BankSetupOfficesViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupOfficesViewModel)GetViewModelWithErrorMessage(bankSetupOfficesViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupOfficesViewModel)GetViewModelWithErrorMessage(bankSetupOfficesViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Error);
                return (BankSetupOfficesViewModel)GetViewModelWithErrorMessage(bankSetupOfficesViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSetupOffices by bankSetupOfficeId.
        public virtual BankSetupOfficesViewModel GetBankSetupOffices(short bankSetupOfficeId)
        {
            BankSetupOfficesResponse response = _bankSetupOfficesClient.GetBankSetupOffices(bankSetupOfficeId);
            return response?.BankSetupOfficesModel.ToViewModel<BankSetupOfficesViewModel>();
        }

        //Update BankSetupOffices.
        public virtual BankSetupOfficesViewModel UpdateBankSetupOffices(BankSetupOfficesViewModel bankSetupOfficesViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Info);
                BankSetupOfficesResponse response = _bankSetupOfficesClient.UpdateBankSetupOffices(bankSetupOfficesViewModel.ToModel<BankSetupOfficesModel>());
                BankSetupOfficesModel bankSetupOfficesModel = response?.BankSetupOfficesModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Info);
                return IsNotNull(bankSetupOfficesModel) ? bankSetupOfficesModel.ToViewModel<BankSetupOfficesViewModel>() : (BankSetupOfficesViewModel)GetViewModelWithErrorMessage(new BankSetupOfficesViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupOfficesViewModel)GetViewModelWithErrorMessage(bankSetupOfficesViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupOfficesViewModel)GetViewModelWithErrorMessage(bankSetupOfficesViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Error);
                return (BankSetupOfficesViewModel)GetViewModelWithErrorMessage(bankSetupOfficesViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSetupOffices.
        public virtual bool DeleteBankSetupOffices(string bankSetupOfficeId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSetupOfficesClient.DeleteBankSetupOffices(new ParameterModel { Ids = bankSetupOfficeId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSetupOffices";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Error);
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
                ColumnName = "Office",
                ColumnCode = "Office",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "LOffice",
                ColumnCode = "LOffice",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        // it will return get all BankSetupOffices list from database 
        public virtual BankSetupOfficesListResponse GetBankSetupOfficesList()
        {
            BankSetupOfficesListResponse BankSetupOfficesList = _bankSetupOfficesClient.List(null, null, null, 1, int.MaxValue);
            return BankSetupOfficesList?.BankSetupOfficesList?.Count > 0 ? BankSetupOfficesList : new BankSetupOfficesListResponse();
        }
        #endregion
    }
}
