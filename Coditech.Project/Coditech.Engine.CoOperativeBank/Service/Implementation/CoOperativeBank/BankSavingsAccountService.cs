using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Resources;
using System.Collections.Specialized;
using System.Data;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Service
{
    public class BankSavingsAccountService : IBankSavingsAccountService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSavingsAccount> _bankSavingsAccountRepository;
        private readonly ICoditechRepository<BankMember> _bankMemberRepository;
        public BankSavingsAccountService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSavingsAccountRepository = new CoditechRepository<BankSavingsAccount>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankMemberRepository = new CoditechRepository<BankMember>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankSavingsAccountListModel GetBankSavingsAccountList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSavingsAccountModel> objStoredProc = new CoditechViewRepository<BankSavingsAccountModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSavingsAccountModel> bankSavingsAccountList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankSavingsAccountList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSavingsAccountListModel listModel = new BankSavingsAccountListModel();

            listModel.BankSavingsAccountList = bankSavingsAccountList?.Count > 0 ? bankSavingsAccountList : new List<BankSavingsAccountModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankSavingsAccount.
        public virtual BankSavingsAccountModel CreateBankSavingsAccount(BankSavingsAccountModel bankSavingsAccountModel)
        {
            if (IsNull(bankSavingsAccountModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSavingsAccount bankSavingsAccount = bankSavingsAccountModel.FromModelToEntity<BankSavingsAccount>();

            //Create new BankSavingsAccount and return it.
            BankSavingsAccount bankSavingsAccountData = _bankSavingsAccountRepository.Insert(bankSavingsAccount);
            if (bankSavingsAccountData?.BankSavingsAccountId > 0)
            {
                bankSavingsAccountModel.BankSavingsAccountId = bankSavingsAccountData.BankSavingsAccountId;
            }
            else
            {
                bankSavingsAccountModel.HasError = true;
                bankSavingsAccountModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankSavingsAccountModel;
        }

        //Get BankSavingsAccount by bankSavingsAccountId.
        public virtual BankSavingsAccountModel GetBankSavingsAccount(long bankSavingsAccountId)
        {
            if (bankSavingsAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingsAccountIdID"));

            //Get the Country Details based on id.
            BankSavingsAccount bankSavingsAccount = _bankSavingsAccountRepository.Table.FirstOrDefault(x => x.BankSavingsAccountId == bankSavingsAccountId);
            BankSavingsAccountModel bankSavingsAccountModel = bankSavingsAccount?.FromEntityToModel<BankSavingsAccountModel>();
            string centreCode = _bankMemberRepository.Table.Where(x => x.BankMemberId == bankSavingsAccount.BankMemberId).Select(x => x.CentreCode).FirstOrDefault();
            bankSavingsAccountModel.CentreCode = centreCode;
            return bankSavingsAccountModel;
        }

        //Update BankSavingsAccount.
        public virtual bool UpdateBankSavingsAccount(BankSavingsAccountModel bankSavingsAccountModel)
        {
            if (IsNull(bankSavingsAccountModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSavingsAccountModel.BankSavingsAccountId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingsAccountID"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSavingsAccount bankSavingsAccount = bankSavingsAccountModel.FromModelToEntity<BankSavingsAccount>();

            //Update BankSavingsAccount
            bool isBankSavingsAccountUpdated = _bankSavingsAccountRepository.Update(bankSavingsAccount);
            if (!isBankSavingsAccountUpdated)
            {
                bankSavingsAccountModel.HasError = true;
                bankSavingsAccountModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankSavingsAccountUpdated;
        }

        //Delete BankSavingsAccount.
        public virtual bool DeleteBankSavingsAccount(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingsAccountID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSavingsAccountID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankSavingsAccount @BankSavingsAccountId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        //#region Protected Method
        ////Check if Insurance Policies Type code is already present or not.
        //protected virtual bool IsBankInsurancePoliciesTypeAlreadyExist(string insurancePoliciesTypeCode, short bankInsurancePoliciesTypeId = 0)
        // => _bankInsurancePoliciesTypeRepository.Table.Any(x => x.InsurancePoliciesTypeCode == insurancePoliciesTypeCode && (x.BankInsurancePoliciesTypeId != bankInsurancePoliciesTypeId || bankInsurancePoliciesTypeId == 0));
        //#endregion
    }
}
