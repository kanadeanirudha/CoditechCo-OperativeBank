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
    public class BankPostingLoanAccountAgent : BaseAgent, IBankPostingLoanAccountAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankPostingLoanAccountClient _bankPostingLoanAccountClient;
        private readonly IUserClient _userClient;
        #endregion

        #region Public Constructor
        public BankPostingLoanAccountAgent(ICoditechLogging coditechLogging, IBankPostingLoanAccountClient bankPostingLoanAccountClient, IUserClient userClient)
        {
            _coditechLogging = coditechLogging;
            _bankPostingLoanAccountClient = GetClient(bankPostingLoanAccountClient);
            _userClient = GetClient<IUserClient>(userClient);
        }
        #endregion

        #region Public Methods
        public virtual BankPostingLoanAccountListViewModel GetBankPostingLoanAccountList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = new FilterCollection();
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters.Add("FirstName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("LastName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("EmailId", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MobileNumber", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("PostingLoanAccountCode", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }
            filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dataTableModel.SelectedCentreCode);
            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);
            BankPostingLoanAccountListResponse response = _bankPostingLoanAccountClient.List(Convert.ToInt32(dataTableModel.SelectedParameter1), null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankPostingLoanAccountListModel bankPostingLoanAccountList = new BankPostingLoanAccountListModel { BankPostingLoanAccountList = response?.BankPostingLoanAccountList };
            BankPostingLoanAccountListViewModel listViewModel = new BankPostingLoanAccountListViewModel();
            listViewModel.BankPostingLoanAccountList = bankPostingLoanAccountList?.BankPostingLoanAccountList?.ToViewModel<BankPostingLoanAccountViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankPostingLoanAccountList.Count, BindColumns());
            return listViewModel;
        }

        //Create BankPostingLoanAccount
        public virtual BankPostingLoanAccountViewModel CreatePostingLoanAccount(BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel)
        {
            try
            {
                BankPostingLoanAccountResponse response = _bankPostingLoanAccountClient.CreatePostingLoanAccount(bankPostingLoanAccountViewModel.ToModel<BankPostingLoanAccountModel>());
                BankPostingLoanAccountModel bankPostingLoanAccountModel = response?.BankPostingLoanAccountModel;
                return IsNotNull(bankPostingLoanAccountModel) ? bankPostingLoanAccountModel.ToViewModel<BankPostingLoanAccountViewModel>() : new BankPostingLoanAccountViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get Bank Posting Loan Account by Bank Posting Loan Account id.
        public virtual BankPostingLoanAccountViewModel GetPostingLoanAccount(int bankPostingLoanAccountId)
        {
            BankPostingLoanAccountResponse response = _bankPostingLoanAccountClient.GetPostingLoanAccount(bankPostingLoanAccountId);
            return response?.BankPostingLoanAccountModel.ToViewModel<BankPostingLoanAccountViewModel>();
        }

        //Update BankPostingLoanAccount.
        public virtual BankPostingLoanAccountViewModel UpdatePostingLoanAccount(BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankPostingLoanAccount", TraceLevel.Info);
                BankPostingLoanAccountResponse response = _bankPostingLoanAccountClient.UpdatePostingLoanAccount(bankPostingLoanAccountViewModel.ToModel<BankPostingLoanAccountModel>());
                BankPostingLoanAccountModel bankPostingLoanAccountModel = response?.BankPostingLoanAccountModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankPostingLoanAccount", TraceLevel.Info);
                return IsNotNull(bankPostingLoanAccountModel) ? bankPostingLoanAccountModel.ToViewModel<BankPostingLoanAccountViewModel>() : (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(new BankPostingLoanAccountViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, ex.ErrorMessage);
                    default:
                        return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankPostingLoanAccount.
        public virtual bool DeletePostingLoanAccount(string bankPostingLoanAccountId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankPostingLoanAccount", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankPostingLoanAccountClient.DeletePostingLoanAccount(new ParameterModel { Ids = bankPostingLoanAccountId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankPostingLoanAccount";
                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankBankPostingLoanAccount", TraceLevel.Error);
                errorMessage = GeneralResources.ErrorFailedToDelete;
                return false;
            }
        }
        #region BankLoanForeClosures

        //Create BankLoanForeClosures
        public virtual BankLoanForeClosuresViewModel CreateBankLoanForeClosures(BankLoanForeClosuresViewModel bankLoanForeClosuresViewModel)
        {
            try
            {
                BankLoanForeClosuresResponse response = _bankPostingLoanAccountClient.CreateBankLoanForeClosures(bankLoanForeClosuresViewModel.ToModel<BankLoanForeClosuresModel>());
                BankLoanForeClosuresModel bankLoanForeClosuresModel = response?.BankLoanForeClosuresModel;
                return IsNotNull(bankLoanForeClosuresModel) ? bankLoanForeClosuresModel.ToViewModel<BankLoanForeClosuresViewModel>() : new BankLoanForeClosuresViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Error);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankLoanForeClosuresViewModel)GetViewModelWithErrorMessage(bankLoanForeClosuresViewModel, ex.ErrorMessage);
                    default:
                        return (BankLoanForeClosuresViewModel)GetViewModelWithErrorMessage(bankLoanForeClosuresViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Error);
                return (BankLoanForeClosuresViewModel)GetViewModelWithErrorMessage(bankLoanForeClosuresViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get BankLoanForeClosures bankPostingLoanAccountId
        public virtual BankLoanForeClosuresViewModel GetBankLoanForeClosures(int bankPostingLoanAccountId)
        {
            BankLoanForeClosuresResponse response = _bankPostingLoanAccountClient.GetBankLoanForeClosures(bankPostingLoanAccountId);
            return response?.BankLoanForeClosuresModel.ToViewModel<BankLoanForeClosuresViewModel>();
        }

        //Update BankLoanForeClosures.
        public virtual BankLoanForeClosuresViewModel UpdateBankLoanForeClosures(BankLoanForeClosuresViewModel bankLoanForeClosuresViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankLoanForeClosures", TraceLevel.Info);
                BankLoanForeClosuresResponse response = _bankPostingLoanAccountClient.UpdateBankLoanForeClosures(bankLoanForeClosuresViewModel.ToModel<BankLoanForeClosuresModel>());
                BankLoanForeClosuresModel bankLoanForeClosuresModel = response?.BankLoanForeClosuresModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankLoanForeClosures", TraceLevel.Info);
                return IsNotNull(bankLoanForeClosuresModel) ? bankLoanForeClosuresModel.ToViewModel<BankLoanForeClosuresViewModel>() : (BankLoanForeClosuresViewModel)GetViewModelWithErrorMessage(new BankLoanForeClosuresViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankLoanForeClosuresViewModel)GetViewModelWithErrorMessage(bankLoanForeClosuresViewModel, ex.ErrorMessage);
                    default:
                        return (BankLoanForeClosuresViewModel)GetViewModelWithErrorMessage(bankLoanForeClosuresViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Error);
                return (BankLoanForeClosuresViewModel)GetViewModelWithErrorMessage(bankLoanForeClosuresViewModel, GeneralResources.UpdateErrorMessage);
            }
        }
        #endregion
        #endregion

        #region protected
        protected virtual List<DatatableColumns> BindColumns()
        {
            List<DatatableColumns> datatableColumnList = new List<DatatableColumns>();
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Loan Account Number",
                ColumnCode = "LoanAccountNumber",
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Loan Type ",
                ColumnCode = "LoanTypeEnumId",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Loan Amount ",
                ColumnCode = "LoanAmount",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Sanctioned Date",
                ColumnCode = "SanctionedDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Interest Date",
                ColumnCode = "InterestDate",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Account Status",
                ColumnCode = "AccountStatusEnumId",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "EMI Amount",
                ColumnCode = "EMIAmount",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Repayment Mode",
                ColumnCode = "RepaymentModeEnumId",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
    }
}
































//Create  Bank Setup Property Valuers.
//public virtual BankPostingLoanAccountViewModel CreateBankPostingLoanAccount(BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel)
//{
//    try
//    {
//        BankPostingLoanAccountResponse response = _bankPostingLoanAccountClient.CreateBankPostingLoanAccount(bankPostingLoanAccountViewModel.ToModel<BankPostingLoanAccountModel>());
//        BankPostingLoanAccountModel bankPostingLoanAccountModel = response?.BankPostingLoanAccountModel;
//        return IsNotNull(bankPostingLoanAccountModel) ? bankPostingLoanAccountModel.ToViewModel<BankPostingLoanAccountViewModel>() : new BankPostingLoanAccountViewModel();
//    }
//    catch (CoditechException ex)
//    {
//        _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Warning);
//        switch (ex.ErrorCode)
//        {
//            case ErrorCodes.AlreadyExist:
//                return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, ex.ErrorMessage);
//            default:
//                return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, GeneralResources.ErrorFailedToCreate);
//        }
//    }
//    catch (Exception ex)
//    {
//        _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
//        return (BankPostingLoanAccountViewModel)GetViewModelWithErrorMessage(bankPostingLoanAccountViewModel, GeneralResources.ErrorFailedToCreate);
//    }
//}