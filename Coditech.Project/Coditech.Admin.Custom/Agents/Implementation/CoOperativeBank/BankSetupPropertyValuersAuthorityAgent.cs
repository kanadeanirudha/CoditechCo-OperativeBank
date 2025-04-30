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
    public class BankSetupPropertyValuersAuthorityAgent : BaseAgent, IBankSetupPropertyValuersAuthorityAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankSetupPropertyValuersAuthorityClient _bankSetupPropertyValuersAuthorityClient;
        #endregion

        #region Public Constructor
        public BankSetupPropertyValuersAuthorityAgent(ICoditechLogging coditechLogging, IBankSetupPropertyValuersAuthorityClient bankSetupPropertyValuersAuthorityClient)
        {
            _coditechLogging = coditechLogging;
            _bankSetupPropertyValuersAuthorityClient = GetClient(bankSetupPropertyValuersAuthorityClient);
        }
        #endregion

        #region Public Methods
        public virtual BankSetupPropertyValuersAuthorityListViewModel GetPropertyValuersAuthorityList(DataTableViewModel dataTableModel)
        {
            //FilterCollection filters = null;
            FilterCollection filters = new FilterCollection();
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {           
                filters.Add("PropertyName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("FromPropertyValueRangeStart", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("FromPropertyValueRangeEnd", ProcedureFilterOperators.Like, dataTableModel.SearchBy); 
            }
            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankSetupPropertyValuersAuthorityListResponse response = _bankSetupPropertyValuersAuthorityClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankSetupPropertyValuersAuthorityListModel bankSetupPropertyValuersAuthorityList = new BankSetupPropertyValuersAuthorityListModel { BankSetupPropertyValuersAuthorityList = response?.BankSetupPropertyValuersAuthorityList };
            BankSetupPropertyValuersAuthorityListViewModel listViewModel = new BankSetupPropertyValuersAuthorityListViewModel();
            listViewModel.BankSetupPropertyValuersAuthorityList = bankSetupPropertyValuersAuthorityList?.BankSetupPropertyValuersAuthorityList?.ToViewModel<BankSetupPropertyValuersAuthorityViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankSetupPropertyValuersAuthorityList.Count, BindColumns());
            return listViewModel;
        }

        //Create  Bank Setup Property Valuers.
        public virtual BankSetupPropertyValuersAuthorityViewModel CreatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityViewModel bankSetupPropertyValuersAuthorityViewModel)
        {
            try
            {
                BankSetupPropertyValuersAuthorityResponse response = _bankSetupPropertyValuersAuthorityClient.CreatePropertyValuersAuthority(bankSetupPropertyValuersAuthorityViewModel.ToModel<BankSetupPropertyValuersAuthorityModel>());
                BankSetupPropertyValuersAuthorityModel bankSetupPropertyValuersAuthorityModel = response?.BankSetupPropertyValuersAuthorityModel;
                return IsNotNull(bankSetupPropertyValuersAuthorityModel) ? bankSetupPropertyValuersAuthorityModel.ToViewModel<BankSetupPropertyValuersAuthorityViewModel>() : new BankSetupPropertyValuersAuthorityViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupPropertyValuersAuthorityViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersAuthorityViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupPropertyValuersAuthorityViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersAuthorityViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return (BankSetupPropertyValuersAuthorityViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersAuthorityViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankSetupPropertyValuersAuthority by Bank Setup Property Valuers Authority id.
        public virtual BankSetupPropertyValuersAuthorityViewModel GetPropertyValuersAuthority(short bankSetupPropertyValuersAuthorityId)
        {
            BankSetupPropertyValuersAuthorityResponse response = _bankSetupPropertyValuersAuthorityClient.GetPropertyValuersAuthority(bankSetupPropertyValuersAuthorityId);
            return response?.BankSetupPropertyValuersAuthorityModel.ToViewModel<BankSetupPropertyValuersAuthorityViewModel>();
        }

        //Update BankSetupPropertyValuersAuthority.
        public virtual BankSetupPropertyValuersAuthorityViewModel UpdatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityViewModel bankSetupPropertyValuersAuthorityViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankSetupPropertyValuersAuthority", TraceLevel.Info);
                BankSetupPropertyValuersAuthorityResponse response = _bankSetupPropertyValuersAuthorityClient.UpdatePropertyValuersAuthority(bankSetupPropertyValuersAuthorityViewModel.ToModel<BankSetupPropertyValuersAuthorityModel>());
                BankSetupPropertyValuersAuthorityModel bankSetupPropertyValuersAuthorityModel = response?.BankSetupPropertyValuersAuthorityModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankSetupPropertyValuersAuthority", TraceLevel.Info);
                return IsNotNull(bankSetupPropertyValuersAuthorityModel) ? bankSetupPropertyValuersAuthorityModel.ToViewModel<BankSetupPropertyValuersAuthorityViewModel>() : (BankSetupPropertyValuersAuthorityViewModel)GetViewModelWithErrorMessage(new BankSetupPropertyValuersAuthorityViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankSetupPropertyValuersAuthorityViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersAuthorityViewModel, ex.ErrorMessage);
                    default:
                        return (BankSetupPropertyValuersAuthorityViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersAuthorityViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return (BankSetupPropertyValuersAuthorityViewModel)GetViewModelWithErrorMessage(bankSetupPropertyValuersAuthorityViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankSetupPropertyValuersAuthority.
        public virtual bool DeletePropertyValuersAuthority(string bankSetupPropertyValuersAuthorityId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankSetupPropertyValuersAuthority", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankSetupPropertyValuersAuthorityClient.DeletePropertyValuersAuthority(new ParameterModel { Ids = bankSetupPropertyValuersAuthorityId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankSetupPropertyValuersAuthority";
                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
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
                ColumnName = "Mortage Property Type",
                ColumnCode = "PropertyName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
           
            {
                ColumnName = "From Property Value Range Start",
                ColumnCode = "FromPropertyValueRangeStart",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "From Property Value Range End",
                ColumnCode = "FromPropertyValueRangeEnd",
                IsSortable = true,
            });
           
            return datatableColumnList;
        }
        #endregion
        #region
        //it will return get all BankSetupPropertyValuersAuthority list from database
        public virtual BankSetupPropertyValuersAuthorityListResponse GetPropertyValuersAuthorityList()
        {
            BankSetupPropertyValuersAuthorityListResponse BankSetupPropertyValuersAuthorityList = _bankSetupPropertyValuersAuthorityClient.List(null, null, null, 1, int.MaxValue);
            return BankSetupPropertyValuersAuthorityList?.BankSetupPropertyValuersAuthorityList?.Count > 0 ? BankSetupPropertyValuersAuthorityList : new BankSetupPropertyValuersAuthorityListResponse();
        }
        #endregion
    }
}
