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
    public class BankInsurancePoliciesTypeAgent : BaseAgent, IBankInsurancePoliciesTypeAgent
    {

        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankInsurancePoliciesTypeClient _bankInsurancePoliciesTypeClient;
        #endregion

        #region Public Constructor
        public BankInsurancePoliciesTypeAgent(ICoditechLogging coditechLogging, IBankInsurancePoliciesTypeClient bankInsurancePoliciesTypeClient)
        {
            _coditechLogging = coditechLogging;
            _bankInsurancePoliciesTypeClient = GetClient<IBankInsurancePoliciesTypeClient>(bankInsurancePoliciesTypeClient);
        }
        #endregion

        #region Public Methods
        public virtual BankInsurancePoliciesTypeListViewModel GetBankInsurancePoliciesTypeList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = null;
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters = new FilterCollection();
                filters.Add("InsurancePoliciesType", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("InsurancePoliciesTypeCode", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "InsurancePoliciesType" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankInsurancePoliciesTypeListResponse response = _bankInsurancePoliciesTypeClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankInsurancePoliciesTypeListModel BankInsurancePoliciesTypeList = new BankInsurancePoliciesTypeListModel { BankInsurancePoliciesTypeList = response?.BankInsurancePoliciesTypeList };
            BankInsurancePoliciesTypeListViewModel listViewModel = new BankInsurancePoliciesTypeListViewModel();
            listViewModel.BankInsurancePoliciesTypeList = BankInsurancePoliciesTypeList?.BankInsurancePoliciesTypeList?.ToViewModel<BankInsurancePoliciesTypeViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankInsurancePoliciesTypeList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankInsurancePoliciesType
        public virtual BankInsurancePoliciesTypeViewModel CreateBankInsurancePoliciesType(BankInsurancePoliciesTypeViewModel bankInsurancePoliciesTypeViewModel)
        {
            try
            {
                BankInsurancePoliciesTypeResponse response = _bankInsurancePoliciesTypeClient.CreateBankInsurancePoliciesType(bankInsurancePoliciesTypeViewModel.ToModel<BankInsurancePoliciesTypeModel>());
                BankInsurancePoliciesTypeModel bankInsurancePoliciesTypeModel = response?.BankInsurancePoliciesTypeModel;
                return IsNotNull(bankInsurancePoliciesTypeModel) ? bankInsurancePoliciesTypeModel.ToViewModel<BankInsurancePoliciesTypeViewModel>() : new BankInsurancePoliciesTypeViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankInsurancePoliciesTypeViewModel)GetViewModelWithErrorMessage(bankInsurancePoliciesTypeViewModel, ex.ErrorMessage);
                    default:
                        return (BankInsurancePoliciesTypeViewModel)GetViewModelWithErrorMessage(bankInsurancePoliciesTypeViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankInsurancePoliciesTypeViewModel)GetViewModelWithErrorMessage(bankInsurancePoliciesTypeViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankInsurancePoliciesType by BankInsurancePoliciesTypeId.
        public virtual BankInsurancePoliciesTypeViewModel GetBankInsurancePoliciesType(short bankInsurancePoliciesTypeId)
        {
            BankInsurancePoliciesTypeResponse response = _bankInsurancePoliciesTypeClient.GetBankInsurancePoliciesType(bankInsurancePoliciesTypeId);
            return response?.BankInsurancePoliciesTypeModel.ToViewModel<BankInsurancePoliciesTypeViewModel>();
        }

        //Update BankInsurancePoliciesType.
        public virtual BankInsurancePoliciesTypeViewModel UpdateBankInsurancePoliciesType(BankInsurancePoliciesTypeViewModel bankInsurancePoliciesTypeViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Info);
                BankInsurancePoliciesTypeResponse response = _bankInsurancePoliciesTypeClient.UpdateBankInsurancePoliciesType(bankInsurancePoliciesTypeViewModel.ToModel<BankInsurancePoliciesTypeModel>());
                BankInsurancePoliciesTypeModel bankInsurancePoliciesTypeModel = response?.BankInsurancePoliciesTypeModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Info);
                return IsNotNull(bankInsurancePoliciesTypeModel) ? bankInsurancePoliciesTypeModel.ToViewModel<BankInsurancePoliciesTypeViewModel>() : (BankInsurancePoliciesTypeViewModel)GetViewModelWithErrorMessage(new BankInsurancePoliciesTypeViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankInsurancePoliciesTypeViewModel)GetViewModelWithErrorMessage(bankInsurancePoliciesTypeViewModel, ex.ErrorMessage);
                    default:
                        return (BankInsurancePoliciesTypeViewModel)GetViewModelWithErrorMessage(bankInsurancePoliciesTypeViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
                return (BankInsurancePoliciesTypeViewModel)GetViewModelWithErrorMessage(bankInsurancePoliciesTypeViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankInsurancePoliciesType.
        public virtual bool DeleteBankInsurancePoliciesType(string bankInsurancePoliciesTypeId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankInsurancePoliciesTypeClient.DeleteBankInsurancePoliciesType(new ParameterModel { Ids = bankInsurancePoliciesTypeId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankInsurancePoliciesType";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Error);
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
                ColumnName = "Insurance Policies Type",
                ColumnCode = "InsurancePoliciesType",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Insurance Policies Type Code",
                ColumnCode = "InsurancePoliciesTypeCode",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Insurance Type Major",
                ColumnCode = "InsuranceTypeMajorEnumId",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        // it will return get all BankInsurancePoliciesType list from database 
        public virtual BankInsurancePoliciesTypeListResponse GetBankInsurancePoliciesTypeList()
        {
            BankInsurancePoliciesTypeListResponse BankInsurancePoliciesTypeList = _bankInsurancePoliciesTypeClient.List(null, null, null, 1, int.MaxValue);
            return BankInsurancePoliciesTypeList?.BankInsurancePoliciesTypeList?.Count > 0 ? BankInsurancePoliciesTypeList : new BankInsurancePoliciesTypeListResponse();
        }
        #endregion
    }
}
