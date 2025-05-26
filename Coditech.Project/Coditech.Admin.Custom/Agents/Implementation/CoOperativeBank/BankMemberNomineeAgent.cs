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
    public class BankMemberNomineeAgent : BaseAgent, IBankMemberNomineeAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankMemberNomineeClient _bankMemberNomineeClient;
        private readonly IUserClient _userClient;
        #endregion

        #region Public Constructor
        public BankMemberNomineeAgent(ICoditechLogging coditechLogging, IBankMemberNomineeClient bankMemberNomineeClient)
        {
            _coditechLogging = coditechLogging;
            _bankMemberNomineeClient = GetClient(bankMemberNomineeClient);
        }
        #endregion

        #region Public Methods
        public virtual BankMemberNomineeListViewModel GetMemberNomineeList(DataTableViewModel dataTableModel)
        {
            //FilterCollection filters = null;
            FilterCollection filters = new FilterCollection();
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters.Add("FirstName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("LastName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);

                filters.Add("RelationTypeEnum", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("PercentageShare", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }
            filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dataTableModel.SelectedCentreCode);

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankMemberNomineeListResponse response = _bankMemberNomineeClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankMemberNomineeListModel BankMemberNomineeList = new BankMemberNomineeListModel { BankMemberNomineeList = response?.BankMemberNomineeList };
            BankMemberNomineeListViewModel listViewModel = new BankMemberNomineeListViewModel();
            listViewModel.BankMemberNomineeList = BankMemberNomineeList?.BankMemberNomineeList?.ToViewModel<BankMemberNomineeViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankMemberNomineeList.Count, BindColumns());
            return listViewModel;
        }

        //Create  Bank Member Nominee.
        public virtual BankMemberNomineeViewModel CreateMemberNominee(BankMemberNomineeViewModel bankMemberNomineeViewModel)
        {
            try
            {
                BankMemberNomineeResponse response = _bankMemberNomineeClient.CreateMemberNominee(bankMemberNomineeViewModel.ToModel<BankMemberNomineeModel>());
                BankMemberNomineeModel bankMemberNomineeModel = response?.BankMemberNomineeModel;
                return IsNotNull(bankMemberNomineeModel) ? bankMemberNomineeModel.ToViewModel<BankMemberNomineeViewModel>() : new BankMemberNomineeViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNominee", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankMemberNomineeViewModel)GetViewModelWithErrorMessage(bankMemberNomineeViewModel, ex.ErrorMessage);
                    default:
                        return (BankMemberNomineeViewModel)GetViewModelWithErrorMessage(bankMemberNomineeViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNominee", TraceLevel.Error);
                return (BankMemberNomineeViewModel)GetViewModelWithErrorMessage(bankMemberNomineeViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankMemberNominee by Bank Member Nominee id.
        public virtual BankMemberNomineeViewModel GetMemberNominee(int bankMemberId)
        {
            BankMemberNomineeResponse response = _bankMemberNomineeClient.GetMemberNominee(bankMemberId);
            return response?.BankMemberNomineeModel.ToViewModel<BankMemberNomineeViewModel>();
        }

        //Update BankMemberNominee.
        public virtual BankMemberNomineeViewModel UpdateMemberNominee(BankMemberNomineeViewModel bankMemberNomineeViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankMemberNominee", TraceLevel.Info);
                BankMemberNomineeResponse response = _bankMemberNomineeClient.UpdateMemberNominee(bankMemberNomineeViewModel.ToModel<BankMemberNomineeModel>());
                BankMemberNomineeModel bankMemberNomineeModel = response?.BankMemberNomineeModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankMemberNominee", TraceLevel.Info);
                return IsNotNull(bankMemberNomineeModel) ? bankMemberNomineeModel.ToViewModel<BankMemberNomineeViewModel>() : (BankMemberNomineeViewModel)GetViewModelWithErrorMessage(new MemberNomineeCreateEditViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNominee", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankMemberNomineeViewModel)GetViewModelWithErrorMessage(bankMemberNomineeViewModel, ex.ErrorMessage);
                    default:
                        return (BankMemberNomineeViewModel)GetViewModelWithErrorMessage(bankMemberNomineeViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNominee", TraceLevel.Error);
                return (BankMemberNomineeViewModel)GetViewModelWithErrorMessage(bankMemberNomineeViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankMemberNominee.
        public virtual bool DeleteMemberNominee(string bankMemberNomineeId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankMemberNominee", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankMemberNomineeClient.DeleteMemberNominee(new ParameterModel { Ids = bankMemberNomineeId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNominee", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankMemberNominee";
                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNominee", TraceLevel.Error);
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
                ColumnName = "First Name",
                ColumnCode = "FirstName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
           
            {
                ColumnName = "Last Name",
                ColumnCode = "LastName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()

            {
                ColumnName = "Percentage Share",
                ColumnCode = "PercentageShare",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
        #region
        //it will return get all BankMemberNominee list from database
        public virtual BankMemberNomineeListResponse GetMemberNomineeList()
        {
            BankMemberNomineeListResponse BankMemberNomineeList = _bankMemberNomineeClient.List(null, null, null, 1, int.MaxValue);
            return BankMemberNomineeList?.BankMemberNomineeList?.Count > 0 ? BankMemberNomineeList : new BankMemberNomineeListResponse();
        }
        #endregion
    }
}
