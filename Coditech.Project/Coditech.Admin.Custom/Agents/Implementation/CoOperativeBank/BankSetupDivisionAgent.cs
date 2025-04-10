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
    public class BankSetupDivisionAgent : BaseAgent, IBankSetupDivisionAgent
    {

        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSetupDivisionClient _bankSetupDivisionClient;
        #endregion

        #region Public Constructor
        public BankSetupDivisionAgent(ICoditechLogging coditechLogging, IBankSetupDivisionClient bankSetupDivisionClient)
        {
            _coditechLogging = coditechLogging;
            _bankSetupDivisionClient = GetClient<IBankSetupDivisionClient>(bankSetupDivisionClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSetupDivisionListViewModel GetBankSetupDivisionList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("SetupDivision", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "SetupDivision" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankSetupDivisionListResponse response = _bankSetupDivisionClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSetupDivisionListModel BankSetupDivisionList = new BankSetupDivisionListModel { BankSetupDivisionList = response?.BankSetupDivisionList };
            BankSetupDivisionListViewModel listViewModel = new BankSetupDivisionListViewModel();
            listViewModel.BankSetupDivisionList = BankSetupDivisionList?.BankSetupDivisionList?.ToViewModel<BankSetupDivisionViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSetupDivisionList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankSetupDivision
        public virtual BankSetupDivisionViewModel CreateBankSetupDivision(BankSetupDivisionViewModel bankSetupDivisionViewModel)
        {
            try
            {
                BankSetupDivisionResponse response = _bankSetupDivisionClient.CreateBankSetupDivision(bankSetupDivisionViewModel.ToModel<BankSetupDivisionModel>());
                BankSetupDivisionModel bankSetupDivisionModel = response?.BankSetupDivisionModel;
                return IsNotNull(bankSetupDivisionModel) ? bankSetupDivisionModel.ToViewModel<BankSetupDivisionViewModel>() : new BankSetupDivisionViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupDivisionViewModel)GetViewModelWithErrorMessage(bankSetupDivisionViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupDivisionViewModel)GetViewModelWithErrorMessage(bankSetupDivisionViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankSetupDivisionViewModel)GetViewModelWithErrorMessage(bankSetupDivisionViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSetupDivision by BankSetupDivisionId.
        public virtual BankSetupDivisionViewModel GetBankSetupDivision(short bankSetupDivisionId)
        {
            BankSetupDivisionResponse response = _bankSetupDivisionClient.GetBankSetupDivision(bankSetupDivisionId);
            return response?.BankSetupDivisionModel.ToViewModel<BankSetupDivisionViewModel>();
        }

        //Update BankSetupDivision.
        public virtual BankSetupDivisionViewModel UpdateBankSetupDivision(BankSetupDivisionViewModel bankSetupDivisionViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Info);
                BankSetupDivisionResponse response = _bankSetupDivisionClient.UpdateBankSetupDivision(bankSetupDivisionViewModel.ToModel<BankSetupDivisionModel>());
                BankSetupDivisionModel bankSetupDivisionModel = response?.BankSetupDivisionModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Info);
                return IsNotNull(bankSetupDivisionModel) ? bankSetupDivisionModel.ToViewModel<BankSetupDivisionViewModel>() : (BankSetupDivisionViewModel)GetViewModelWithErrorMessage(new BankSetupDivisionViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupDivisionViewModel)GetViewModelWithErrorMessage(bankSetupDivisionViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupDivisionViewModel)GetViewModelWithErrorMessage(bankSetupDivisionViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Error);
                return (BankSetupDivisionViewModel)GetViewModelWithErrorMessage(bankSetupDivisionViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSetupDivision.
        public virtual bool DeleteBankSetupDivision(string bankSetupDivisionId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSetupDivisionClient.DeleteBankSetupDivision(new ParameterModel { Ids = bankSetupDivisionId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSetupDivision";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Error);
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
                ColumnName = "Bank Setup Division",
                ColumnCode = "SetupDivision",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        // it will return get all BankSetupDivision list from database 
        public virtual BankSetupDivisionListResponse GetBankSetupDivisionList()
        {
            BankSetupDivisionListResponse BankSetupDivisionList = _bankSetupDivisionClient.List(null, null, null, 1, int.MaxValue);
            return BankSetupDivisionList?.BankSetupDivisionList?.Count > 0 ? BankSetupDivisionList : new BankSetupDivisionListResponse();
        }
        #endregion
    }
}
