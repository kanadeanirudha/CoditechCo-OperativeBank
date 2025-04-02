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
    public class BankSetupMortagePropertyTypeAgent : BaseAgent, IBankSetupMortagePropertyTypeAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSetupMortagePropertyTypeClient _bankSetupMortagePropertyTypeClient;
        #endregion

        #region Public Constructor
        public BankSetupMortagePropertyTypeAgent(ICoditechLogging coditechLogging, IBankSetupMortagePropertyTypeClient bankSetupMortagePropertyTypeClient)
        {
            _coditechLogging = coditechLogging;
            _bankSetupMortagePropertyTypeClient = GetClient(bankSetupMortagePropertyTypeClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSetupMortagePropertyTypeListViewModel GetPropertyTypeList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("PropertyCode", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("PropertyName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("LPropertyName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankSetupMortagePropertyTypeListResponse response = _bankSetupMortagePropertyTypeClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSetupMortagePropertyTypeListModel bankSetupMortagePropertyTypeList = new BankSetupMortagePropertyTypeListModel { BankSetupMortagePropertyTypeList = response?.BankSetupMortagePropertyTypeList };
            BankSetupMortagePropertyTypeListViewModel listViewModel = new BankSetupMortagePropertyTypeListViewModel();
            listViewModel.BankSetupMortagePropertyTypeList = bankSetupMortagePropertyTypeList?.BankSetupMortagePropertyTypeList?.ToViewModel<BankSetupMortagePropertyTypeViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSetupMortagePropertyTypeList.Count, BindColumns());
            return listViewModel;
        }

        //Create Acc Setup TransactionType.
        public virtual BankSetupMortagePropertyTypeViewModel CreatePropertyType(BankSetupMortagePropertyTypeViewModel bankSetupMortagePropertyTypeViewModel)
        {
            try
            {
                BankSetupMortagePropertyTypeResponse response = _bankSetupMortagePropertyTypeClient.CreatePropertyType(bankSetupMortagePropertyTypeViewModel.ToModel<BankSetupMortagePropertyTypeModel>());
                BankSetupMortagePropertyTypeModel bankSetupMortagePropertyTypeModel = response?.BankSetupMortagePropertyTypeModel;
                return IsNotNull(bankSetupMortagePropertyTypeModel) ? bankSetupMortagePropertyTypeModel.ToViewModel<BankSetupMortagePropertyTypeViewModel>() : new BankSetupMortagePropertyTypeViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupMortagePropertyTypeViewModel)GetViewModelWithErrorMessage(bankSetupMortagePropertyTypeViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupMortagePropertyTypeViewModel)GetViewModelWithErrorMessage(bankSetupMortagePropertyTypeViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Error);
                return (BankSetupMortagePropertyTypeViewModel)GetViewModelWithErrorMessage(bankSetupMortagePropertyTypeViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSetupMortagePropertyType by Bank SetupMortage PropertyType id.
        public virtual BankSetupMortagePropertyTypeViewModel GetPropertyType(short bankSetupMortagePropertyTypeId)
        {
            BankSetupMortagePropertyTypeResponse response = _bankSetupMortagePropertyTypeClient.GetPropertyType(bankSetupMortagePropertyTypeId);
            return response?.BankSetupMortagePropertyTypeModel.ToViewModel<BankSetupMortagePropertyTypeViewModel>();
        }

        //Update BankSetupMortagePropertyType.
        public virtual BankSetupMortagePropertyTypeViewModel UpdatePropertyType(BankSetupMortagePropertyTypeViewModel bankSetupMortagePropertyTypeViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankSetupMortagePropertyType", TraceLevel.Info);
                BankSetupMortagePropertyTypeResponse response = _bankSetupMortagePropertyTypeClient.UpdatePropertyType(bankSetupMortagePropertyTypeViewModel.ToModel<BankSetupMortagePropertyTypeModel>());
                BankSetupMortagePropertyTypeModel bankSetupMortagePropertyTypeModel = response?.BankSetupMortagePropertyTypeModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankSetupMortagePropertyType", TraceLevel.Info);
                return IsNotNull(bankSetupMortagePropertyTypeModel) ? bankSetupMortagePropertyTypeModel.ToViewModel<BankSetupMortagePropertyTypeViewModel>() : (BankSetupMortagePropertyTypeViewModel)GetViewModelWithErrorMessage(new BankSetupMortagePropertyTypeViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex,"BankSetupMortagePropertyType", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupMortagePropertyTypeViewModel)GetViewModelWithErrorMessage(bankSetupMortagePropertyTypeViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupMortagePropertyTypeViewModel)GetViewModelWithErrorMessage(bankSetupMortagePropertyTypeViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex,"BankSetupMortagePropertyType", TraceLevel.Error);
                return (BankSetupMortagePropertyTypeViewModel)GetViewModelWithErrorMessage(bankSetupMortagePropertyTypeViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSetupMortagePropertyType.
        public virtual bool DeletePropertyType(string bankSetupMortagePropertyTypeId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.","BankSetupMortagePropertyType", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSetupMortagePropertyTypeClient.DeletePropertyType(new ParameterModel { Ids = bankSetupMortagePropertyTypeId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Warning);
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
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Error);
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
                ColumnName = "Property Code",
                ColumnCode = "PropertyCode",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Property Name",
                ColumnCode = "PropertyName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "LProperty Name",
                ColumnCode = "LPropertyName",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        //it will return get all BankSetupMortagePropertyType list from database
        public virtual BankSetupMortagePropertyTypeListResponse GetPropertyTypeList()
        {
            BankSetupMortagePropertyTypeListResponse BankSetupMortagePropertyTypeList = _bankSetupMortagePropertyTypeClient.List(null, null, null, 1, int.MaxValue);
            return BankSetupMortagePropertyTypeList?.BankSetupMortagePropertyTypeList?.Count > 0 ? BankSetupMortagePropertyTypeList : new BankSetupMortagePropertyTypeListResponse();
        }
        #endregion
    }
}
