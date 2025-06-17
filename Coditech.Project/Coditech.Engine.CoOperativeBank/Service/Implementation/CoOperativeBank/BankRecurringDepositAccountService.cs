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
    public class BankRecurringDepositAccountService : IBankRecurringDepositAccountService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankRecurringDepositAccount> _bankRecurringDepositAccountRepository;
        private readonly ICoditechRepository<BankRecurringDepositClosure> _bankRecurringDepositClosureRepository;
        private readonly ICoditechRepository<BankMember> _bankMemberRepository;
        private readonly ICoditechRepository<BankRecurringDepositInterestPosting> _bankRecurringDepositInterestPostingRepository;

        public BankRecurringDepositAccountService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankRecurringDepositAccountRepository = new CoditechRepository<BankRecurringDepositAccount>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankMemberRepository = new CoditechRepository<BankMember>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankRecurringDepositClosureRepository = new CoditechRepository<BankRecurringDepositClosure>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankRecurringDepositInterestPostingRepository = new CoditechRepository<BankRecurringDepositInterestPosting>(_serviceProvider.GetService<CoditechCustom_Entities>());

        }
        public virtual BankRecurringDepositAccountListModel GetBankRecurringDepositAccountList( FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankRecurringDepositAccountModel> objStoredProc = new CoditechViewRepository<BankRecurringDepositAccountModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankRecurringDepositAccountModel> bankRecurringDepositAccountList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankRecurringDepositAccountList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankRecurringDepositAccountListModel listModel = new BankRecurringDepositAccountListModel();

            listModel.BankRecurringDepositAccountList = bankRecurringDepositAccountList?.Count > 0 ? bankRecurringDepositAccountList : new List<BankRecurringDepositAccountModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankRecurringDepositAccount.
        public virtual BankRecurringDepositAccountModel CreateBankRecurringDepositAccount(BankRecurringDepositAccountModel bankRecurringDepositAccountModel)
        {
            if (IsNull(bankRecurringDepositAccountModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankRecurringDepositAccount bankRecurringDepositAccount = bankRecurringDepositAccountModel.FromModelToEntity<BankRecurringDepositAccount>();

            //Create new BankRecurringDepositAccount and return it.
            BankRecurringDepositAccount bankRecurringDepositAccountData = _bankRecurringDepositAccountRepository.Insert(bankRecurringDepositAccount);
            if (bankRecurringDepositAccountData?.BankRecurringDepositAccountId > 0)
            {
                bankRecurringDepositAccountModel.BankRecurringDepositAccountId = bankRecurringDepositAccountData.BankRecurringDepositAccountId;
            }
            else
            {
                bankRecurringDepositAccountModel.HasError = true;
                bankRecurringDepositAccountModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankRecurringDepositAccountModel;
        }

        //Get BankRecurringDepositAccount by bankRecurringDepositAccountId.
        public virtual BankRecurringDepositAccountModel GetBankRecurringDepositAccount(int bankRecurringDepositAccountId)
        {
            if (bankRecurringDepositAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankRecurringDepositAccountId"));

            //Get the Country Details based on id.
            BankRecurringDepositAccount bankRecurringDepositAccount = _bankRecurringDepositAccountRepository.Table.FirstOrDefault(x => x.BankRecurringDepositAccountId == bankRecurringDepositAccountId);
            BankRecurringDepositAccountModel bankRecurringDepositAccountModel = bankRecurringDepositAccount?.FromEntityToModel<BankRecurringDepositAccountModel>();
            //string centreCode = _bankMemberRepository.Table.Where(x => x.BankMemberId == bankRecurringDepositAccount.BankMemberId).Select(x => x.CentreCode).FirstOrDefault();
            //bankRecurringDepositAccountModel.CentreCode = centreCode;
            return bankRecurringDepositAccountModel;
        }

        //Update BankRecurringDepositAccount.
        public virtual bool UpdateBankRecurringDepositAccount(BankRecurringDepositAccountModel bankRecurringDepositAccountModel)
        {
            if (IsNull(bankRecurringDepositAccountModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankRecurringDepositAccountModel.BankRecurringDepositAccountId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankRecurringDepositAccountId"));

            BankRecurringDepositAccount bankRecurringDepositAccount = bankRecurringDepositAccountModel.FromModelToEntity<BankRecurringDepositAccount>();

            //Update BankRecurringDepositAccount
            bool isBankRecurringDepositAccountUpdated = _bankRecurringDepositAccountRepository.Update(bankRecurringDepositAccount);
            if (!isBankRecurringDepositAccountUpdated)
            {
                bankRecurringDepositAccountModel.HasError = true;
                bankRecurringDepositAccountModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankRecurringDepositAccountUpdated;
        }

        //Delete BankRecurringDepositAccount.
        public virtual bool DeleteBankRecurringDepositAccount(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankRecurringDepositAccountId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankRecurringDepositAccountId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankRecurringDepositAccount @IBankRecurringDepositAccountServiceId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }
        #region BankRecurringDepositClosure
        //Create BankRecurringDepositClosure.
        public virtual BankRecurringDepositClosureModel CreateBankRecurringDepositClosure(BankRecurringDepositClosureModel bankRecurringDepositClosureModel)
        {
            if (IsNull(bankRecurringDepositClosureModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankRecurringDepositClosure bankRecurringDepositClosure = bankRecurringDepositClosureModel.FromModelToEntity<BankRecurringDepositClosure>();

            //Create new BankRecurringDepositAccount and return it.
            BankRecurringDepositClosure bankRecurringDepositClosureData = _bankRecurringDepositClosureRepository.Insert(bankRecurringDepositClosure);
            if (bankRecurringDepositClosureData?.BankRecurringDepositClosureId > 0)
            {
                bankRecurringDepositClosureModel.BankRecurringDepositClosureId = bankRecurringDepositClosureData.BankRecurringDepositClosureId;
            }
            else
            {
                bankRecurringDepositClosureModel.HasError = true;
                bankRecurringDepositClosureModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankRecurringDepositClosureModel;
        }

        //Get BankRecurringDepositClosure by bankRecurringDepositAccountId.
        public virtual BankRecurringDepositClosureModel GetBankRecurringDepositClosure(int bankRecurringDepositAccountId)
        {
            if (bankRecurringDepositAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankRecurringDepositAccountId"));

            // Step 1: Check if BankFixedDepositClosure already exists for this account
            BankRecurringDepositClosure existingBankRecurringDepositClosure = _bankRecurringDepositClosureRepository.Table.FirstOrDefault(x => x.BankRecurringDepositAccountId == bankRecurringDepositAccountId);

            if (existingBankRecurringDepositClosure != null)
            {
                return new BankRecurringDepositClosureModel
                {
                    BankRecurringDepositClosureId = existingBankRecurringDepositClosure.BankRecurringDepositClosureId,
                    BankRecurringDepositAccountId = existingBankRecurringDepositClosure.BankRecurringDepositAccountId,
                    ClosureDate = existingBankRecurringDepositClosure.ClosureDate,
                    ClosureTypeEnumId = existingBankRecurringDepositClosure.ClosureTypeEnumId,
                    AmountPaid = existingBankRecurringDepositClosure.AmountPaid,
                    Reason = existingBankRecurringDepositClosure.Reason,
                    ApprovedBy = existingBankRecurringDepositClosure.ApprovedBy,
                    PenaltyAmount = existingBankRecurringDepositClosure.PenaltyAmount,
                };
            }

            // If no BankRecurringDepositClosure , return a new model with default values
            return new BankRecurringDepositClosureModel
            {
                BankRecurringDepositAccountId = bankRecurringDepositAccountId,
            };
        }

        //Update BankRecurringDepositClosure.
        public virtual bool UpdateBankRecurringDepositClosure(BankRecurringDepositClosureModel bankRecurringDepositClosureModel)
        {
            if (IsNull(bankRecurringDepositClosureModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankRecurringDepositClosureModel.BankRecurringDepositClosureId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankRecurringDepositClosureId"));

            BankRecurringDepositClosure bankRecurringDepositClosure = bankRecurringDepositClosureModel.FromModelToEntity<BankRecurringDepositClosure>();

            //Update BankRecurringDepositClosure
            bool isBankRecurringDepositClosureUpdated = _bankRecurringDepositClosureRepository.Update(bankRecurringDepositClosure);
            if (!isBankRecurringDepositClosureUpdated)
            {
                bankRecurringDepositClosureModel.HasError = true;
                bankRecurringDepositClosureModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankRecurringDepositClosureUpdated;
        }
        #endregion

        #region BankRecurringDepositInterestPosting

        //Create BankRecurringDepositInterestPosting.
        public virtual BankRecurringDepositInterestPostingModel CreateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingModel bankRecurringDepositInterestPostingModel)
        {
            if (IsNull(bankRecurringDepositInterestPostingModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankRecurringDepositInterestPosting bankRecurringDepositInterestPosting = bankRecurringDepositInterestPostingModel.FromModelToEntity<BankRecurringDepositInterestPosting>();

            //Create new BankFixedDepositInterestPostings and return it.
            BankRecurringDepositInterestPosting bankRecurringDepositInterestPostingData = _bankRecurringDepositInterestPostingRepository.Insert(bankRecurringDepositInterestPosting);
            if (bankRecurringDepositInterestPostingData?.BankRecurringDepositInterestPostingId > 0)
            {
                bankRecurringDepositInterestPostingModel.BankRecurringDepositInterestPostingId = bankRecurringDepositInterestPostingData.BankRecurringDepositInterestPostingId;
            }
            else
            {
                bankRecurringDepositInterestPostingModel.HasError = true;
                bankRecurringDepositInterestPostingModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankRecurringDepositInterestPostingModel;
        }

        // Get BankRecurringDepositInterestPosting by bankRecurringDepositAccountId.
        public virtual BankRecurringDepositInterestPostingModel GetBankRecurringDepositInterestPosting(int bankRecurringDepositAccountId)
        {
            if (bankRecurringDepositAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankRecurringDepositAccountId"));

            // Step 1: Check if BankFixedDepositClosure already exists for this account
            BankRecurringDepositInterestPosting existingBankRecurringDepositInterestPosting = _bankRecurringDepositInterestPostingRepository.Table.FirstOrDefault(x => x.BankRecurringDepositAccountId == bankRecurringDepositAccountId);

            if (existingBankRecurringDepositInterestPosting != null)
            {
                return new BankRecurringDepositInterestPostingModel
                {
                    BankRecurringDepositInterestPostingId = existingBankRecurringDepositInterestPosting.BankRecurringDepositInterestPostingId,
                    BankRecurringDepositAccountId = existingBankRecurringDepositInterestPosting.BankRecurringDepositAccountId,
                    InterestAmount = existingBankRecurringDepositInterestPosting.InterestAmount,
                    PostingDate = existingBankRecurringDepositInterestPosting.PostingDate,
                    Remarks = existingBankRecurringDepositInterestPosting.Remarks,
                };
            }

            // If no existingBankFixedDepositClosure , return a new model with default values
            return new BankRecurringDepositInterestPostingModel
            {
                BankRecurringDepositAccountId = bankRecurringDepositAccountId,
            };
        }

        //Update BankRecurringDepositInterestPosting.
        public virtual bool UpdateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingModel bankRecurringDepositInterestPostingModel)
        {
            if (IsNull(bankRecurringDepositInterestPostingModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankRecurringDepositInterestPostingModel.BankRecurringDepositInterestPostingId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankRecurringDepositInterestPostingId"));

            BankRecurringDepositInterestPosting bankRecurringDepositInterestPosting = bankRecurringDepositInterestPostingModel.FromModelToEntity<BankRecurringDepositInterestPosting>();

           
            bool isBankRecurringDepositInterestPostingUpdated = _bankRecurringDepositInterestPostingRepository.Update(bankRecurringDepositInterestPosting);
            if (!isBankRecurringDepositInterestPostingUpdated)
            {
                bankRecurringDepositInterestPostingModel.HasError = true;
                bankRecurringDepositInterestPostingModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankRecurringDepositInterestPostingUpdated;
        }

        #endregion
    }
}
