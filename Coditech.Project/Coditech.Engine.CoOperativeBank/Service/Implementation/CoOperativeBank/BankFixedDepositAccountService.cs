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
    public class BankFixedDepositAccountService : IBankFixedDepositAccountService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankFixedDepositAccount> _bankFixedDepositAccountRepository;
        private readonly ICoditechRepository<BankMember> _bankMemberRepository;
        private readonly ICoditechRepository<BankFixedDepositClosure> _bankFixedDepositClosureRepository;
        public BankFixedDepositAccountService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankFixedDepositAccountRepository = new CoditechRepository<BankFixedDepositAccount>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankMemberRepository = new CoditechRepository<BankMember>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankFixedDepositClosureRepository = new CoditechRepository<BankFixedDepositClosure>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankFixedDepositAccountListModel GetBankFixedDepositAccountList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            string selectedCentreCode = filters?.Find(x => string.Equals(x.FilterName, FilterKeys.SelectedCentreCode, StringComparison.CurrentCultureIgnoreCase))?.FilterValue;
            filters.RemoveAll(x => x.FilterName == FilterKeys.SelectedCentreCode);

            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankFixedDepositAccountModel> objStoredProc = new CoditechViewRepository<BankFixedDepositAccountModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@CentreCode", selectedCentreCode, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankFixedDepositAccountModel> BankFixedDepositAccountList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankFixedDepositAccountList @CentreCode,@WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 5, out pageListModel.TotalRowCount)?.ToList();
            BankFixedDepositAccountListModel listModel = new BankFixedDepositAccountListModel();

            listModel.BankFixedDepositAccountList = BankFixedDepositAccountList?.Count > 0 ? BankFixedDepositAccountList : new List<BankFixedDepositAccountModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankFixedDepositAccount.
        public virtual BankFixedDepositAccountModel CreateBankFixedDepositAccount(BankFixedDepositAccountModel bankFixedDepositAccountModel)
        {
            if (IsNull(bankFixedDepositAccountModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankFixedDepositAccount bankFixedDepositAccount = bankFixedDepositAccountModel.FromModelToEntity<BankFixedDepositAccount>();

            //Create new BankFixedDepositAccount and return it.
            BankFixedDepositAccount bankFixedDepositAccountData = _bankFixedDepositAccountRepository.Insert(bankFixedDepositAccount);
            if (bankFixedDepositAccountData?.BankFixedDepositAccountId > 0)
            {
                bankFixedDepositAccountModel.BankFixedDepositAccountId = bankFixedDepositAccountData.BankFixedDepositAccountId;
            }
            else
            {
                bankFixedDepositAccountModel.HasError = true;
                bankFixedDepositAccountModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankFixedDepositAccountModel;
        }

        //Get BankFixedDepositAccount by bankFixedDepositAccountId.
        public virtual BankFixedDepositAccountModel GetBankFixedDepositAccount(short bankFixedDepositAccountId)
        {
            if (bankFixedDepositAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankFixedDepositAccountID"));

            //Get the BankFixedDepositAccount based on bankFixedDepositAccountId.
            BankFixedDepositAccount bankFixedDepositAccount = _bankFixedDepositAccountRepository.Table.FirstOrDefault(x => x.BankFixedDepositAccountId == bankFixedDepositAccountId);
            string selectedCentreCode = _bankMemberRepository.Table.Where(x => x.BankMemberId == bankFixedDepositAccount.BankMemberId).Select(x => x.CentreCode).FirstOrDefault();
            BankFixedDepositAccountModel bankFixedDepositAccountModel = bankFixedDepositAccount?.FromEntityToModel<BankFixedDepositAccountModel>();
            bankFixedDepositAccountModel.CentreCode = selectedCentreCode;
            return bankFixedDepositAccountModel;
        }

        //Update BankFixedDepositAccount.
        public virtual bool UpdateBankFixedDepositAccount(BankFixedDepositAccountModel bankFixedDepositAccountModel)
        {
            if (IsNull(bankFixedDepositAccountModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankFixedDepositAccountModel.BankFixedDepositAccountId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankFixedDepositAccountID"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankFixedDepositAccount bankFixedDepositAccount = bankFixedDepositAccountModel.FromModelToEntity<BankFixedDepositAccount>();

            //Update BankFixedDepositAccount
            bool isBankFixedDepositAccountUpdated = _bankFixedDepositAccountRepository.Update(bankFixedDepositAccount);
            if (!isBankFixedDepositAccountUpdated)
            {
                bankFixedDepositAccountModel.HasError = true;
                bankFixedDepositAccountModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankFixedDepositAccountUpdated;
        }

        //Delete BankFixedDepositAccount.
        public virtual bool DeleteBankFixedDepositAccount(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankFixedDepositAccountID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankFixedDepositAccountID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankFixedDepositAccount @BankFixedDepositAccountId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        //#region Protected Method
        ////Check if Insurance Policies Type code is already present or not.
        //protected virtual bool IsBankInsurancePoliciesTypeAlreadyExist(string insurancePoliciesTypeCode, short bankInsurancePoliciesTypeId = 0)
        // => _bankInsurancePoliciesTypeRepository.Table.Any(x => x.InsurancePoliciesTypeCode == insurancePoliciesTypeCode && (x.BankInsurancePoliciesTypeId != bankInsurancePoliciesTypeId || bankInsurancePoliciesTypeId == 0));
        //#endregion

        #region BankFixedDepositClosure

        //Create BankFixedDepositClosure.
        public virtual BankFixedDepositClosureModel CreateBankFixedDepositClosure(BankFixedDepositClosureModel bankFixedDepositClosureModel)
        {
            if (IsNull(bankFixedDepositClosureModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankFixedDepositClosure bankFixedDepositClosure = bankFixedDepositClosureModel.FromModelToEntity<BankFixedDepositClosure>();

            //Create new BankFixedDepositAccount and return it.
            BankFixedDepositClosure bankFixedDepositClosureData = _bankFixedDepositClosureRepository.Insert(bankFixedDepositClosure);
            if (bankFixedDepositClosureData?.BankFixedDepositClosureId > 0)
            {
                bankFixedDepositClosureModel.BankFixedDepositClosureId = bankFixedDepositClosureData.BankFixedDepositClosureId;
            }
            else
            {
                bankFixedDepositClosureModel.HasError = true;
                bankFixedDepositClosureModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankFixedDepositClosureModel;
        }

        // Get BankFixedDepositClosure by bankFixedDepositAccountId.
        public virtual BankFixedDepositClosureModel GetBankFixedDepositClosure(short bankFixedDepositAccountId)
        {
            if (bankFixedDepositAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankFixedDepositAccountId"));

            // Step 1: Check if BankFixedDepositClosure already exists for this account
            BankFixedDepositClosure existingBankFixedDepositClosure = _bankFixedDepositClosureRepository.Table.FirstOrDefault(x => x.BankFixedDepositAccountId == bankFixedDepositAccountId);

            if (existingBankFixedDepositClosure != null)
            {
                return new BankFixedDepositClosureModel
                {
                    BankFixedDepositClosureId = existingBankFixedDepositClosure.BankFixedDepositClosureId,
                    BankFixedDepositAccountId = existingBankFixedDepositClosure.BankFixedDepositAccountId,
                    ClosureDate = existingBankFixedDepositClosure.ClosureDate,
                    ClosureTypeEnumId = existingBankFixedDepositClosure.ClosureTypeEnumId,
                    AmountPaid = existingBankFixedDepositClosure.AmountPaid,
                    PenaltyApplied = existingBankFixedDepositClosure.PenaltyApplied,
                    ApprovedBy = existingBankFixedDepositClosure.ApprovedBy,
                    Remarks = existingBankFixedDepositClosure.Remarks,
                };
            }

            // If no existingBankFixedDepositClosure , return a new model with default values
            return new BankFixedDepositClosureModel
            {
                BankFixedDepositAccountId = bankFixedDepositAccountId,
            };
        }

        //Update BankFixedDepositClosure.
        public virtual bool UpdateBankFixedDepositClosure(BankFixedDepositClosureModel bankFixedDepositClosureModel)
        {
            if (IsNull(bankFixedDepositClosureModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankFixedDepositClosureModel.BankFixedDepositClosureId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankFixedDepositClosureId"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankFixedDepositClosure bankFixedDepositClosure = bankFixedDepositClosureModel.FromModelToEntity<BankFixedDepositClosure>();

            //Update BankFixedDepositClosure
            bool isBankFixedDepositClosureUpdated = _bankFixedDepositClosureRepository.Update(bankFixedDepositClosure);
            if (!isBankFixedDepositClosureUpdated)
            {
                bankFixedDepositClosureModel.HasError = true;
                bankFixedDepositClosureModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankFixedDepositClosureUpdated;
        }

        #endregion
    }
}
