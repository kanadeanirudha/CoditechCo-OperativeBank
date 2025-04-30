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
using System.Resources;
using static Coditech.Common.Helper.HelperUtility;

namespace Coditech.Admin.Agents
{
    public class BankVehicleModelAgent : BaseAgent, IBankVehicleModelAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankVehicleModelClient _bankVehicleModelClient;
        #endregion

        #region Public Constructor
        public BankVehicleModelAgent(ICoditechLogging coditechLogging, IBankVehicleModelClient bankVehicleModelClient)
        {
            _coditechLogging = coditechLogging;
            _bankVehicleModelClient = GetClient(bankVehicleModelClient);
        }
        #endregion

        #region Public Methods
        public virtual BankVehicleModelListViewModel GetVehicleModelList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("VehicleModel", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                //filters.Add("PropertyName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                //filters.Add("LPropertyName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankVehicleModelListResponse response = _bankVehicleModelClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankVehicleModelListModel bankVehicleModelList = new BankVehicleModelListModel { BankVehicleModelList = response?.BankVehicleModelList };
            BankVehicleModelListViewModel listViewModel = new BankVehicleModelListViewModel();
            listViewModel.BankVehicleModelList = bankVehicleModelList?.BankVehicleModelList?.ToViewModel<BankVehicleModelViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankVehicleModelList.Count, BindColumns());
            return listViewModel;
        }

        //Create Bank Vehicle Model.
        public virtual BankVehicleModelViewModel CreateVehicleModel(BankVehicleModelViewModel bankVehicleModelViewModel)
        {
            try
            {
                BankVehicleModelResponse response = _bankVehicleModelClient.CreateVehicleModel(bankVehicleModelViewModel.ToModel<BankVehicleModelModel>());
                BankVehicleModelModel bankVehicleModelModel = response?.BankVehicleModelModel;
                return IsNotNull(bankVehicleModelModel) ? bankVehicleModelModel.ToViewModel<BankVehicleModelViewModel>() : new BankVehicleModelViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankVehicleModelViewModel)GetViewModelWithErrorMessage(bankVehicleModelViewModel, ex.ErrorMessage);
                    default:
                        return (BankVehicleModelViewModel)GetViewModelWithErrorMessage(bankVehicleModelViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
                return (BankVehicleModelViewModel)GetViewModelWithErrorMessage(bankVehicleModelViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankVehicleModel by Bank Vehicle Model id.
        public virtual BankVehicleModelViewModel GetVehicleModel(short bankVehicleModelId)
        {
            BankVehicleModelResponse response = _bankVehicleModelClient.GetVehicleModel(bankVehicleModelId);
            return response?.BankVehicleModelModel.ToViewModel<BankVehicleModelViewModel>();
        }

        //Update Bank Vehicle Model.
        public virtual BankVehicleModelViewModel UpdateVehicleModel(BankVehicleModelViewModel bankVehicleModelViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankVehicleModel", TraceLevel.Info);
                BankVehicleModelResponse response = _bankVehicleModelClient.UpdateVehicleModel(bankVehicleModelViewModel.ToModel<BankVehicleModelModel>());
                BankVehicleModelModel bankVehicleModelModel = response?.BankVehicleModelModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankVehicleModel", TraceLevel.Info);
                return IsNotNull(bankVehicleModelModel) ? bankVehicleModelModel.ToViewModel<BankVehicleModelViewModel>() : (BankVehicleModelViewModel)GetViewModelWithErrorMessage(new BankVehicleModelViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankVehicleModelViewModel)GetViewModelWithErrorMessage(bankVehicleModelViewModel, ex.ErrorMessage);
                    default:
                        return (BankVehicleModelViewModel)GetViewModelWithErrorMessage(bankVehicleModelViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
                return (BankVehicleModelViewModel)GetViewModelWithErrorMessage(bankVehicleModelViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankVehicleModel.
        public virtual bool DeleteVehicleModel(string bankVehicleModelId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.","BankVehicleModel", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankVehicleModelClient.DeleteVehicleModel(new ParameterModel { Ids = bankVehicleModelId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSetupMortagePropertyType";
                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
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
                ColumnName = "Vehicle Model ",
                ColumnCode = "VehicleModel",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Vehicle Company",
                ColumnCode = "VehicleCompanyEnumId",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        //it will return get all BankVehicleModel list from database
        public virtual BankVehicleModelListResponse GetBankVehicleModelList()
        {
            BankVehicleModelListResponse BankVehicleModelList = _bankVehicleModelClient.List(null, null, null, 1, int.MaxValue);
            return BankVehicleModelList?.BankVehicleModelList?.Count > 0 ? BankVehicleModelList : new BankVehicleModelListResponse();
        }
        #endregion
    }
}
