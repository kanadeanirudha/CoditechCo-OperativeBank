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
    public class BankMemberAgent : BaseAgent, IBankMemberAgent
    {
        #region Private Variable
        protected readonly ICoditechLogging _coditechLogging;
        private readonly IBankMemberClient _bankMemberClient;
        private readonly IUserClient _userClient;
        #endregion

        #region Public Constructor
        public BankMemberAgent(ICoditechLogging coditechLogging, IBankMemberClient bankMemberClient, IUserClient userClient)
        {
            _coditechLogging = coditechLogging;
            _bankMemberClient = GetClient(bankMemberClient);
            _userClient = GetClient<IUserClient>(userClient);
        }
        #endregion

        #region Public Methods
        public virtual BankMemberListViewModel GetBankMemberList(DataTableViewModel dataTableModel)
        {
            FilterCollection filters = new FilterCollection();
            dataTableModel = dataTableModel ?? new DataTableViewModel();
            if (!string.IsNullOrEmpty(dataTableModel.SearchBy))
            {
                filters.Add("FirstName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("LastName", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("EmailId", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MobileNumber", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
                filters.Add("MemberCode", ProcedureFilterOperators.Like, dataTableModel.SearchBy);
            }
            filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dataTableModel.SelectedCentreCode);
            SortCollection sortlist = SortingData(dataTableModel.SortByColumn = string.IsNullOrEmpty(dataTableModel.SortByColumn) ? "" : dataTableModel.SortByColumn, dataTableModel.SortBy);
            BankMemberListResponse response = _bankMemberClient.List(null, filters, sortlist, dataTableModel.PageIndex, dataTableModel.PageSize);
            BankMemberListModel bankMemberList = new BankMemberListModel { BankMemberList = response?.BankMemberList };
            BankMemberListViewModel listViewModel = new BankMemberListViewModel();
            listViewModel.BankMemberList = bankMemberList?.BankMemberList?.ToViewModel<BankMemberViewModel>().ToList();

            SetListPagingData(listViewModel.PageListViewModel, response, dataTableModel, listViewModel.BankMemberList.Count, BindColumns());
            return listViewModel;
        }

        //Create Bank Member
        public virtual MemberCreateEditViewModel CreateBankMember(MemberCreateEditViewModel memberCreateEditViewModel)
        {
            try
            {
                memberCreateEditViewModel.UserType = UserTypeCustomEnum.BankMember.ToString(); 
                GeneralPersonModel generalPersonModel = memberCreateEditViewModel.ToModel<GeneralPersonModel>();
                generalPersonModel.SelectedCentreCode = memberCreateEditViewModel.SelectedCentreCode;
                GeneralPersonResponse response = _userClient.InsertPersonInformation(generalPersonModel);
                generalPersonModel = response?.GeneralPersonModel;
                return IsNotNull(generalPersonModel) ? generalPersonModel.ToViewModel<MemberCreateEditViewModel>() : new MemberCreateEditViewModel();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (MemberCreateEditViewModel)GetViewModelWithErrorMessage(memberCreateEditViewModel, ex.ErrorMessage);
                    default:
                        return (MemberCreateEditViewModel)GetViewModelWithErrorMessage(memberCreateEditViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return (MemberCreateEditViewModel)GetViewModelWithErrorMessage(memberCreateEditViewModel, GeneralResources.ErrorFailedToCreate);
            }
        }

        //Get Member Details by personId.
        public virtual MemberCreateEditViewModel GetMemberPersonalDetails(int bankMemberId, long personId)
        {
            GeneralPersonResponse response = _userClient.GetPersonInformation(personId);
            MemberCreateEditViewModel memberCreateEditViewModel = response?.GeneralPersonModel.ToViewModel<MemberCreateEditViewModel>();
            if (IsNotNull(memberCreateEditViewModel))
            {
                BankMemberResponse bankMemberResponse = _bankMemberClient.GetMemberOtherDetail(bankMemberId);
                if (IsNotNull(bankMemberResponse))
                {
                    memberCreateEditViewModel.SelectedCentreCode = bankMemberResponse.BankMemberModel.CentreCode;
                }
                memberCreateEditViewModel.BankMemberId = bankMemberId;
                memberCreateEditViewModel.PersonId = personId;
            }
            return memberCreateEditViewModel;
        }

        //Update Member Personal Details
        public virtual MemberCreateEditViewModel UpdateMemberPersonalDetails(MemberCreateEditViewModel memberCreateEditViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankMember", TraceLevel.Info);
                GeneralPersonModel generalPersonModel = memberCreateEditViewModel.ToModel<GeneralPersonModel>();
                generalPersonModel.EntityId = memberCreateEditViewModel.BankMemberId;
                generalPersonModel.UserType = "Member";
                GeneralPersonResponse response = _userClient.UpdatePersonInformation(generalPersonModel);
                generalPersonModel = response?.GeneralPersonModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankMember", TraceLevel.Info);
                return IsNotNull(generalPersonModel) ? generalPersonModel.ToViewModel<MemberCreateEditViewModel>() : (MemberCreateEditViewModel)GetViewModelWithErrorMessage(new MemberCreateEditViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return (MemberCreateEditViewModel)GetViewModelWithErrorMessage(memberCreateEditViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Get BankMember by Bank Bank Setup Property Valuers id.
        public virtual BankMemberViewModel GetMemberOtherDetail(int bankMemberId)
        {
            BankMemberResponse response = _bankMemberClient.GetMemberOtherDetail(bankMemberId);
            return response?.BankMemberModel.ToViewModel<BankMemberViewModel>();
        }

        //Update BankMember.
        public virtual BankMemberViewModel UpdateMemberOtherDetail(BankMemberViewModel bankMemberViewModel)
        {
            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankMember", TraceLevel.Info);
                BankMemberResponse response = _bankMemberClient.UpdateMemberOtherDetail(bankMemberViewModel.ToModel<BankMemberModel>());
                BankMemberModel bankMemberModel = response?.BankMemberModel;
                _coditechLogging.LogMessage("Agent method execution done.", "BankMember", TraceLevel.Info);
                return IsNotNull(bankMemberModel) ? bankMemberModel.ToViewModel<BankMemberViewModel>() : (BankMemberViewModel)GetViewModelWithErrorMessage(new BankMemberViewModel(), GeneralResources.UpdateErrorMessage);
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AlreadyExist:
                        return (BankMemberViewModel)GetViewModelWithErrorMessage(bankMemberViewModel, ex.ErrorMessage);
                    default:
                        return (BankMemberViewModel)GetViewModelWithErrorMessage(bankMemberViewModel, GeneralResources.ErrorFailedToCreate);
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return (BankMemberViewModel)GetViewModelWithErrorMessage(bankMemberViewModel, GeneralResources.UpdateErrorMessage);
            }
        }

        //Delete BankMember.
        public virtual bool DeleteBankMember(string bankMemberId, out string errorMessage)
        {
            errorMessage = GeneralResources.ErrorFailedToDelete;

            try
            {
                _coditechLogging.LogMessage("Agent method execution started.", "BankMember", TraceLevel.Info);
                TrueFalseResponse trueFalseResponse = _bankMemberClient.DeleteBankMember(new ParameterModel { Ids = bankMemberId });
                return trueFalseResponse.IsSuccess;
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Warning);
                switch (ex.ErrorCode)
                {
                    case ErrorCodes.AssociationDeleteError:
                        errorMessage = "ErrorDeleteBankMember";
                        return false;
                    default:
                        errorMessage = GeneralResources.ErrorFailedToDelete;
                        return false;
                }
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankBankMember", TraceLevel.Error);
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
                ColumnName = "Image",
                ColumnCode = "Image",
            });
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
                ColumnName = "Gender",
                ColumnCode = "GenderEnumId",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Contact",
                ColumnCode = "MobileNumber",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Email Id",
                ColumnCode = "EmailId",
                IsSortable = true,
            });
            datatableColumnList.Add(new DatatableColumns()
            {
                ColumnName = "Is Active",
                ColumnCode = "IsActive",
                IsSortable = true,
            });
            return datatableColumnList;
        }
        #endregion
    }
}
































//Create  Bank Setup Property Valuers.
//public virtual BankMemberViewModel CreateBankMember(BankMemberViewModel bankMemberViewModel)
//{
//    try
//    {
//        BankMemberResponse response = _bankMemberClient.CreateBankMember(bankMemberViewModel.ToModel<BankMemberModel>());
//        BankMemberModel bankMemberModel = response?.BankMemberModel;
//        return IsNotNull(bankMemberModel) ? bankMemberModel.ToViewModel<BankMemberViewModel>() : new BankMemberViewModel();
//    }
//    catch (CoditechException ex)
//    {
//        _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Warning);
//        switch (ex.ErrorCode)
//        {
//            case ErrorCodes.AlreadyExist:
//                return (BankMemberViewModel)GetViewModelWithErrorMessage(bankMemberViewModel, ex.ErrorMessage);
//            default:
//                return (BankMemberViewModel)GetViewModelWithErrorMessage(bankMemberViewModel, GeneralResources.ErrorFailedToCreate);
//        }
//    }
//    catch (Exception ex)
//    {
//        _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
//        return (BankMemberViewModel)GetViewModelWithErrorMessage(bankMemberViewModel, GeneralResources.ErrorFailedToCreate);
//    }
//}