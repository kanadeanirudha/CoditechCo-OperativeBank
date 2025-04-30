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
    public class BankSetupPropertyValuersAgent : BaseAgent, IBankSetupPropertyValuersAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSetupPropertyValuersClient _bankSetupPropertyValuersClient;
        #endregion

        #region Public Constructor
        public BankSetupPropertyValuersAgent(ICoditechLogging coditechLogging, IBankSetupPropertyValuersClient bankSetupPropertyValuersClient)
        {
            _coditechLogging = coditechLogging;
            _bankSetupPropertyValuersClient = GetClient(bankSetupPropertyValuersClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSetupPropertyValuersListViewModel GetPropertyValuersList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("FirstName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("LastName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MobileNumber", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }
            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);
            BankSetupPropertyValuersListResponse response = _bankSetupPropertyValuersClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSetupPropertyValuersListModel bankSetupPropertyValuersList = new BankSetupPropertyValuersListModel { BankSetupPropertyValuersList = response?.BankSetupPropertyValuersList };
            BankSetupPropertyValuersListViewModel listViewModel = new BankSetupPropertyValuersListViewModel();
            listViewModel.BankSetupPropertyValuersList = bankSetupPropertyValuersList?.BankSetupPropertyValuersList?.ToViewModel<BankSetupPropertyValuersViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSetupPropertyValuersList.Count, BindColumns());
            return listViewModel;
        }

        //Create  Bank Setup Property Valuers.
        public virtual BankSetupPropertyValuersViewModel CreatePropertyValuers(BankSetupPropertyValuersViewModel bankSetupPropertyValuersViewModel)
        {
            try
            {
                BankSetupPropertyValuersResponse response = _bankSetupPropertyValuersClient.CreatePropertyValuers(bankSetupPropertyValuersViewModel.ToModel<BankSetupPropertyValuersModel>());
                BankSetupPropertyValuersModel bankSetupPropertyValuersModel = response?.BankSetupPropertyValuersModel;
                return IsNotNull(bankSetupPropertyValuersModel) ? bankSetupPropertyValuersModel.ToViewModel<BankSetupPropertyValuersViewModel>() : new BankSetupPropertyValuersViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupPropertyValuersViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupPropertyValuersViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return (BankSetupPropertyValuersViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSetupPropertyValuers by Bank Bank Setup Property Valuers id.
        public virtual BankSetupPropertyValuersViewModel GetPropertyValuers(long generalPersonAddressId)
        {
            BankSetupPropertyValuersResponse response = _bankSetupPropertyValuersClient.GetPropertyValuers(generalPersonAddressId);
            return response?.BankSetupPropertyValuersModel.ToViewModel<BankSetupPropertyValuersViewModel>();
        }

        //Update BankSetupPropertyValuers.
        public virtual BankSetupPropertyValuersViewModel UpdatePropertyValuers(BankSetupPropertyValuersViewModel bankSetupPropertyValuersViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankSetupPropertyValuers", TraceLevel.Info);
                BankSetupPropertyValuersResponse response = _bankSetupPropertyValuersClient.UpdatePropertyValuers(bankSetupPropertyValuersViewModel.ToModel<BankSetupPropertyValuersModel>());
                BankSetupPropertyValuersModel bankSetupPropertyValuersModel = response?.BankSetupPropertyValuersModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankSetupPropertyValuers", TraceLevel.Info);
                return IsNotNull(bankSetupPropertyValuersModel) ? bankSetupPropertyValuersModel.ToViewModel<BankSetupPropertyValuersViewModel>() : (BankSetupPropertyValuersViewModel)GetViewModelWithErrorMessage(new BankSetupPropertyValuersViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupPropertyValuersViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupPropertyValuersViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return (BankSetupPropertyValuersViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSetupPropertyValuers.
        public virtual bool DeletePropertyValuers(string bankSetupPropertyValuersId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankSetupPropertyValuers", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSetupPropertyValuersClient.DeletePropertyValuers(new ParameterModel { Ids = bankSetupPropertyValuersId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSetupPropertyValuers";
                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankBankSetupPropertyValuers", TraceLevel.Error);
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
                ColumnName = "First Name ",
                ColumnCode = "FirstName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Middle Name ",
                ColumnCode = "MiddleName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Last Name ",
                ColumnCode = "LastName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Mobile Number ",
                ColumnCode = "MobileNumber",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region     
        #endregion
    }
}
