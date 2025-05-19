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
    public class BankProductAgent : BaseAgent, IBankProductAgent
    {

        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankProductClient _bankProductClient;
        #endregion

        #region Public Constructor
        public BankProductAgent(ICoditechLogging coditechLogging, IBankProductClient bankProductClient)
        {
            _coditechLogging = coditechLogging;
            _bankProductClient = GetClient<IBankProductClient>(bankProductClient);
        }
        #endregion

        #region Public Methods
        public virtual BankProductListViewModel GetBankProductList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = new FilterCollection();
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dataTableModel.SelectedCentreCode);
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters.Add("ProductName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("RateOfIntrest", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("InitialDepositAmount", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MinimumBalanceAmount", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }

            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);

            BankProductListResponse response = _bankProductClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankProductListModel BankProductList = new BankProductListModel { BankProductList = response?.BankProductList };
            BankProductListViewModel listViewModel = new BankProductListViewModel();
            listViewModel.BankProductList = BankProductList?.BankProductList?.ToViewModel<BankProductViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankProductList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankProduct
        public virtual BankProductViewModel CreateBankProduct(BankProductViewModel bankProductViewModel)
        {
            try
            {
                BankProductResponse response = _bankProductClient.CreateBankProduct(bankProductViewModel.ToModel<BankProductModel>());
                BankProductModel bankProductModel = response?.BankProductModel;
                return IsNotNull(bankProductModel) ? bankProductModel.ToViewModel<BankProductViewModel>() : new BankProductViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankProductViewModel)GetViewModelWithErrorMessage(bankProductViewModel, ex.ErrorMessage);
                    default:
                        return (BankProductViewModel)GetViewModelWithErrorMessage(bankProductViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Error);
                return (BankProductViewModel)GetViewModelWithErrorMessage(bankProductViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankProduct by bankProductId.
        public virtual BankProductViewModel GetBankProduct(short bankProductId)
        {
            BankProductResponse response = _bankProductClient.GetBankProduct(bankProductId);
            return response?.BankProductModel.ToViewModel<BankProductViewModel>();
        }

        //Update BankProduct.
        public virtual BankProductViewModel UpdateBankProduct(BankProductViewModel bankProductViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Info);
                BankProductResponse response = _bankProductClient.UpdateBankProduct(bankProductViewModel.ToModel<BankProductModel>());
                BankProductModel bankProductModel = response?.BankProductModel;
                _coditechLogging.LogMessage("Agent method execution done.", LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Info);
                return IsNotNull(bankProductModel) ? bankProductModel.ToViewModel<BankProductViewModel>() : (BankProductViewModel)GetViewModelWithErrorMessage(new BankProductViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankProductViewModel)GetViewModelWithErrorMessage(bankProductViewModel, ex.ErrorMessage);
                    default:
                        return (BankProductViewModel)GetViewModelWithErrorMessage(bankProductViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Error);
                return (BankProductViewModel)GetViewModelWithErrorMessage(bankProductViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankProduct.
        public virtual bool DeleteBankProduct(string bankProductId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankProductClient.DeleteBankProduct(new ParameterModel { Ids = bankProductId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankProduct";

                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Error);
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
                ColumnName = "Product Name",
                ColumnCode = "ProductName",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Rate Of Intrest",
                ColumnCode = "RateOfIntrest",
                IsSortable = true,
            });

            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Initial Deposit Amount",
                ColumnCode = "InitialDepositAmount",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Minimum Balance Amount",
                ColumnCode = "MinimumBalanceAmount",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Account Type",
                ColumnCode = "AccountTypeEnumId",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
    }
}
