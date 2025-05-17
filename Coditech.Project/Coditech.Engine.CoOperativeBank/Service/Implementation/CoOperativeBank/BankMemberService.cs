using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Common.Service;
using Coditech.Resources;
using System.Collections.Specialized;
using System.Data;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Service
{
    public class BankMemberService : BaseService, IBankMemberService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankMember> _bankMemberRepository;
        public BankMemberService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankMemberRepository = new CoditechRepository<BankMember>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankMemberListModel GetBankMemberList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            string selectedCentreCode = filters?.Find(x => string.Equals(x.FilterName, FilterKeys.SelectedCentreCode, StringComparison.CurrentCultureIgnoreCase))?.FilterValue;

            filters.RemoveAll(x => x.FilterName == FilterKeys.SelectedDepartmentId || x.FilterName == FilterKeys.SelectedCentreCode);

            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankMemberModel> objStoredProc = new CoditechViewRepository<BankMemberModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@CentreCode", selectedCentreCode, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankMemberModel> BankMemberList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankMemberList @CentreCode,@WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 5, out pageListModel.TotalRowCount)?.ToList();
            BankMemberListModel listModel = new BankMemberListModel();
            listModel.BankMemberList = BankMemberList?.Count > 0 ? BankMemberList : new List<BankMemberModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }

        //Get BankMember by BankMember id.
        public virtual BankMemberModel GetMemberOtherDetail(int bankMemberId)
        {
            if (bankMemberId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberId"));

            //Get the BankMember Details based on id.
            BankMember bankMember = _bankMemberRepository.Table.Where(x => x.BankMemberId == bankMemberId).FirstOrDefault();
            BankMemberModel bankMemberModel = bankMember?.FromEntityToModel<BankMemberModel>();
            if (IsNotNull(bankMemberModel))
            {
                GeneralPersonModel generalPersonModel = GetGeneralPersonDetails(bankMemberModel.PersonId);
                if (IsNotNull(bankMemberModel))
                {
                    bankMemberModel.FirstName = generalPersonModel.FirstName;
                    bankMemberModel.LastName = generalPersonModel.LastName;
                }
            }
            return bankMemberModel;
        }

        //Update BankMember.
        public virtual bool UpdateMemberOtherDetail(BankMemberModel bankMemberModel)
        {
            if (IsNull(bankMemberModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankMemberModel.BankMemberId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberId"));

            BankMember bankMember = _bankMemberRepository.Table.FirstOrDefault(x => x.BankMemberId == bankMemberModel.BankMemberId);
            //Update Bank Member
            bool isUpdated = false;
            if (IsNull(bankMember))
            {
                return isUpdated;
            }
            bankMember.AadharCardNumber = bankMemberModel.AadharCardNumber;
            bankMember.PANCardNumber = bankMemberModel.PANCardNumber;
            bankMember.AccountStatusEnumId = bankMemberModel.AccountStatusEnumId;
            bankMember.IsActive = bankMemberModel.IsActive;

            isUpdated = _bankMemberRepository.Update(bankMember);
            if (isUpdated)
            {
                ActiveInActiveUserLogin(bankMember.IsActive, Convert.ToInt64(bankMember.BankMemberId), UserTypeCustomEnum.BankMember.ToString());
            }
            else
            {
                bankMemberModel.HasError = true;
                bankMemberModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isUpdated;
        }

        //Delete BankMember.
        public virtual bool DeleteBankMember(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankMemberId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankMember @BankMemberId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }
    }
}