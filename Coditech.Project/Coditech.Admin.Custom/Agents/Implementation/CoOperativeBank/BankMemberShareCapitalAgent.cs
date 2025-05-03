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
    public class BankMemberShareCapitalAgent : BaseAgent, IBankMemberShareCapitalAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankMemberShareCapitalClient _bankMemberShareCapitalClient;
        #endregion

        #region Public Constructor
        public BankMemberShareCapitalAgent(ICoditechLogging coditechLogging, IBankMemberShareCapitalClient bankMemberShareCapitalClient)
        {
            _coditechLogging = coditechLogging;
            _bankMemberShareCapitalClient = GetClient(bankMemberShareCapitalClient);
        }
        #endregion

        #region Public Methods
        public virtual BankMemberShareCapitalListViewModel GetMemberShareCapitalList(DataTableViewModel dataTableModel)
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

            BankMemberShareCapitalListResponse response = _bankMemberShareCapitalClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankMemberShareCapitalListModel bankMemberShareCapitalList = new BankMemberShareCapitalListModel { BankMemberShareCapitalList = response?.BankMemberShareCapitalList };
            BankMemberShareCapitalListViewModel listViewModel = new BankMemberShareCapitalListViewModel();
            listViewModel.BankMemberShareCapitalList = bankMemberShareCapitalList?.BankMemberShareCapitalList?.ToViewModel<BankMemberShareCapitalViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankMemberShareCapitalList.Count, BindColumns());
            return listViewModel;
        }

        //Create  Bank Setup Property Valuers.
        public virtual BankMemberShareCapitalViewModel CreateMemberShareCapital(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel)
        {
            try
            {
                BankMemberShareCapitalResponse response = _bankMemberShareCapitalClient.CreateMemberShareCapital(bankMemberShareCapitalViewModel.ToModel<BankMemberShareCapitalModel>());
                BankMemberShareCapitalModel bankMemberShareCapitalModel = response?.BankMemberShareCapitalModel;
                return IsNotNull(bankMemberShareCapitalModel) ? bankMemberShareCapitalModel.ToViewModel<BankMemberShareCapitalViewModel>() : new BankMemberShareCapitalViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankMemberShareCapitalViewModel)GetViewModelWithErrorMessage(bankMemberShareCapitalViewModel, ex.ErrorMessage);
                    default:
                        return (BankMemberShareCapitalViewModel)GetViewModelWithErrorMessage(bankMemberShareCapitalViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return (BankMemberShareCapitalViewModel)GetViewModelWithErrorMessage(bankMemberShareCapitalViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankMemberShareCapital by Bank Member Share Capital id.
        public virtual BankMemberShareCapitalViewModel GetMemberShareCapital(int bankMemberShareCapitalId)
        {
            BankMemberShareCapitalResponse response = _bankMemberShareCapitalClient.GetMemberShareCapital(bankMemberShareCapitalId);
            return response?.BankMemberShareCapitalModel.ToViewModel<BankMemberShareCapitalViewModel>();
        }

        //Update BankMemberShareCapital.
        public virtual BankMemberShareCapitalViewModel UpdateMemberShareCapital(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankMemberShareCapital", TraceLevel.Info);
                BankMemberShareCapitalResponse response = _bankMemberShareCapitalClient.UpdateMemberShareCapital(bankMemberShareCapitalViewModel.ToModel<BankMemberShareCapitalModel>());
                BankMemberShareCapitalModel bankMemberShareCapitalModel = response?.BankMemberShareCapitalModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankMemberShareCapital", TraceLevel.Info);
                return IsNotNull(bankMemberShareCapitalModel) ? bankMemberShareCapitalModel.ToViewModel<BankMemberShareCapitalViewModel>() : (BankMemberShareCapitalViewModel)GetViewModelWithErrorMessage(new BankMemberShareCapitalViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankMemberShareCapitalViewModel)GetViewModelWithErrorMessage(bankMemberShareCapitalViewModel, ex.ErrorMessage);
                    default:
                        return (BankMemberShareCapitalViewModel)GetViewModelWithErrorMessage(bankMemberShareCapitalViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return (BankMemberShareCapitalViewModel)GetViewModelWithErrorMessage(bankMemberShareCapitalViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankMemberShareCapital.
        public virtual bool DeleteMemberShareCapital(string bankMemberShareCapitalId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankMemberShareCapital", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankMemberShareCapitalClient.DeleteMemberShareCapital(new ParameterModel { Ids = bankMemberShareCapitalId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankMemberShareCapital";
                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
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
                ColumnName = "Number Of Shares",
                ColumnCode = "NumberOfShares",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
           
            {
                ColumnName = "Amount Invested",
                ColumnCode = "AmountInvested",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Purchase Date",
                ColumnCode = "PurchaseDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()

            {
                ColumnName = "Share Price ",
                ColumnCode = "SharePrice",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()

            {
                ColumnName = "Payment Mode ",
                ColumnCode = "PaymentModeEnumId",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()

            {
                ColumnName = "Transcation Reference ",
                ColumnCode = "TranscationReference",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()

            {
                ColumnName = "Remarks ",
                ColumnCode = "Remarks",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()

            {
                ColumnName = "Is Active ",
                ColumnCode = "IsActive",
                IsSortable = true,
            });

            return datatableColumnList;
        }
        #endregion
        #region
        //it will return get all BankMemberShareCapital list from database
        public virtual BankMemberShareCapitalListResponse GetMemberShareCapitalList()
        {
            BankMemberShareCapitalListResponse BankMemberShareCapitalList = _bankMemberShareCapitalClient.List(null, null, null, 1, int.MaxValue);
            return BankMemberShareCapitalList?.BankMemberShareCapitalList?.Count > 0 ? BankMemberShareCapitalList : new BankMemberShareCapitalListResponse();
        }
        #endregion
    }
}
