using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Common.Service;
using Coditech.Model;
using Coditech.Resources;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto.Agreement.Kdf;
using System.Collections.Specialized;
using System.Data;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Service
{
    public class BankPostingLoanAccountService : BaseService, IBankPostingLoanAccountService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankPostingLoanAccount> _bankPostingLoanAccountRepository;
        private readonly ICoditechRepository<BankLoanForeClosures> _bankLoanForeClosuresRepository;
        private readonly ICoditechRepository<BankLoanRepayment> _bankLoanRepaymentRepository;
        public BankPostingLoanAccountService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankPostingLoanAccountRepository = new CoditechRepository<BankPostingLoanAccount>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankLoanForeClosuresRepository = new CoditechRepository<BankLoanForeClosures>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankLoanRepaymentRepository = new CoditechRepository<BankLoanRepayment>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankPostingLoanAccountListModel GetBankPostingLoanAccountList(string centreCode, int bankMemberId, FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankPostingLoanAccountModel> objStoredProc = new CoditechViewRepository<BankPostingLoanAccountModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@CentreCode", centreCode, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@BankMemberId", bankMemberId, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankPostingLoanAccountModel> BankPostingLoanAccountList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankPostingLoanAccountList @CentreCode,@BankMemberId,@WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 6, out pageListModel.TotalRowCount)?.ToList();
            BankPostingLoanAccountListModel listModel = new BankPostingLoanAccountListModel();
            listModel.BankPostingLoanAccountList = BankPostingLoanAccountList?.Count > 0 ? BankPostingLoanAccountList : new List<BankPostingLoanAccountModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }

        //Create Bank Posting Loan Account.
        public virtual BankPostingLoanAccountModel CreatePostingLoanAccount(BankPostingLoanAccountModel bankPostingLoanAccountModel)
        {
            if (IsNull(bankPostingLoanAccountModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankPostingLoanAccount bankPostingLoanAccount = bankPostingLoanAccountModel.FromModelToEntity<BankPostingLoanAccount>();
            bankPostingLoanAccount.TenureMonthsEnumId = bankPostingLoanAccountModel.TenureMonthsEnumId + (bankPostingLoanAccountModel.TenureYears * 12);
            bankPostingLoanAccount.MaturityDate = bankPostingLoanAccountModel.SanctionedDate.AddMonths(bankPostingLoanAccountModel.TenureMonthsEnumId + (bankPostingLoanAccountModel.TenureYears * 12));

            //Create new Policy and return it.
            BankPostingLoanAccount bankPostingLoanAccountData = _bankPostingLoanAccountRepository.Insert(bankPostingLoanAccount);
            if (bankPostingLoanAccountData?.BankPostingLoanAccountId > 0)
            {
                bankPostingLoanAccountModel.BankPostingLoanAccountId = bankPostingLoanAccountData.BankPostingLoanAccountId;
            }
            else
            {
                bankPostingLoanAccountModel.HasError = true;
                bankPostingLoanAccountModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankPostingLoanAccountModel;
        }

        //Get BankPostingLoanAccount by BankPostingLoanAccount id.
        public virtual BankPostingLoanAccountModel GetPostingLoanAccount(int bankPostingLoanAccountId)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankPostingLoanAccountId"));
            //Get the BankPostingLoanAccount Details based on id.
            BankPostingLoanAccount bankPostingLoanAccount = _bankPostingLoanAccountRepository.Table.Where(x => x.BankPostingLoanAccountId == bankPostingLoanAccountId).FirstOrDefault();
            BankPostingLoanAccountModel bankPostingLoanAccountModel = bankPostingLoanAccount?.FromEntityToModel<BankPostingLoanAccountModel>();
            if (bankPostingLoanAccount.TenureMonthsEnumId > 0)
            {
                bankPostingLoanAccountModel.TenureYears = bankPostingLoanAccount.TenureMonthsEnumId / 12;
                bankPostingLoanAccountModel.TenureMonthsEnumId = bankPostingLoanAccount.TenureMonthsEnumId % 12;
            }
            return bankPostingLoanAccountModel;
        }

        //Update BankPostingLoanAccount.
        public virtual bool UpdatePostingLoanAccount(BankPostingLoanAccountModel bankPostingLoanAccountModel)
        {
            if (IsNull(bankPostingLoanAccountModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankPostingLoanAccountModel.BankPostingLoanAccountId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankPostingLoanAccountId"));

            BankPostingLoanAccount bankPostingLoanAccount = bankPostingLoanAccountModel.FromEntityToModel<BankPostingLoanAccount>();
            //Update Bank Posting Loan Account
            bool isUpdated = _bankPostingLoanAccountRepository.Update(bankPostingLoanAccount);
            if (!isUpdated)
            {
                bankPostingLoanAccountModel.HasError = true;
                bankPostingLoanAccountModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isUpdated;
        }

        //Delete BankPostingLoanAccount.
        public virtual bool DeletePostingLoanAccount(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankPostingLoanAccountId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankPostingLoanAccountId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankPostingLoanAccount @BankPostingLoanAccountId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }
        #region BankLoanForeClosures

        //Create BankLoanForeClosures.
        public virtual BankLoanForeClosuresModel CreateBankLoanForeClosures(BankLoanForeClosuresModel bankLoanForeClosuresModel)
        {
            if (IsNull(bankLoanForeClosuresModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);
            bankLoanForeClosuresModel.MaturityDate = DateTime.UtcNow;
            BankLoanForeClosures bankLoanForeClosures = bankLoanForeClosuresModel.FromModelToEntity<BankLoanForeClosures>();

            //Create new BankLoanForeClosures and return it.
            BankLoanForeClosures bankLoanForeClosuresData = _bankLoanForeClosuresRepository.Insert(bankLoanForeClosures);
            if (bankLoanForeClosuresData?.BankLoanForeClosuresId > 0)
            {
                bankLoanForeClosuresModel.BankLoanForeClosuresId = bankLoanForeClosuresData.BankLoanForeClosuresId;
            }
            else
            {
                bankLoanForeClosuresModel.HasError = true;
                bankLoanForeClosuresModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankLoanForeClosuresModel;
        }
        // Get BankLoanForeClosures by bankPostingLoanAccountId.
        public virtual BankLoanForeClosuresModel GetBankLoanForeClosures(int bankPostingLoanAccountId)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankPostingLoanAccountId"));

            // Step 1: Check if BankSavingsAccountClosures already exists for this account
            BankLoanForeClosures existingBankLoanForeClosures = _bankLoanForeClosuresRepository.Table.FirstOrDefault(x => x.BankPostingLoanAccountId == bankPostingLoanAccountId);

            if (existingBankLoanForeClosures != null)
            {
                return new BankLoanForeClosuresModel
                {
                    BankPostingLoanAccountId = existingBankLoanForeClosures.BankPostingLoanAccountId,
                    BankLoanForeClosuresId = existingBankLoanForeClosures.BankLoanForeClosuresId,
                    RemainingEMI = existingBankLoanForeClosures.RemainingEMI,
                    RemainingEMIAmount = existingBankLoanForeClosures.RemainingEMIAmount,
                    MaturityDate = existingBankLoanForeClosures.MaturityDate,
                    LoanScheduleStatusEnumId = existingBankLoanForeClosures.LoanScheduleStatusEnumId,
                };
            }

            // If no existingBankSavingsAccountClosure , return a new model with default values
            return new BankLoanForeClosuresModel
            {
                BankPostingLoanAccountId = bankPostingLoanAccountId,
            };
        }

        //Update BankLoanForeClosures.
        public virtual bool UpdateBankLoanForeClosures(BankLoanForeClosuresModel bankLoanForeClosuresModel)
        {
            if (IsNull(bankLoanForeClosuresModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankLoanForeClosuresModel.BankPostingLoanAccountId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankLoanForeClosuresId"));

            BankLoanForeClosures bankLoanForeClosures = bankLoanForeClosuresModel.FromEntityToModel<BankLoanForeClosures>();
            //Update Bank Posting Loan Account
            bool isUpdated = _bankLoanForeClosuresRepository.Update(bankLoanForeClosures);
            if (!isUpdated)
            {
                bankLoanForeClosuresModel.HasError = true;
                bankLoanForeClosuresModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isUpdated;
        }
        #endregion

        //Get BankLoanRepayment by BankPostingLoanAccount id.
        public virtual BankLoanRepaymentModel GetLoanRepayment(int bankPostingLoanAccountId)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankPostingLoanAccountId"));
            //Get the BankLoanRepayment Details based on id.
            BankLoanRepayment bankLoanRepayment = _bankLoanRepaymentRepository.Table.FirstOrDefault(x => x.BankPostingLoanAccountId == bankPostingLoanAccountId);
            BankLoanRepaymentModel bankLoanRepaymentModel = IsNull(bankLoanRepayment) ? new BankLoanRepaymentModel() : bankLoanRepayment.FromEntityToModel<BankLoanRepaymentModel>();
            bankLoanRepaymentModel.BankPostingLoanAccountId = bankPostingLoanAccountId;
            return bankLoanRepaymentModel;
        }

        //Update BankLoanRepayment.
        public virtual bool UpdateLoanRepayment(BankLoanRepaymentModel bankLoanRepaymentModel)
        {
            if (IsNull(bankLoanRepaymentModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankLoanRepaymentModel.BankPostingLoanAccountId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankPostingLoanAccountId"));

            //Update Bank Posting Loan Account
            bool isUpdated = false;
            BankLoanRepayment bankLoanRepayment = bankLoanRepaymentModel.FromEntityToModel<BankLoanRepayment>();
            if(bankLoanRepaymentModel.BankLoanRepaymentId > 0)
                isUpdated = _bankLoanRepaymentRepository.Update(bankLoanRepayment);
            else
            {
                BankPostingLoanAccount model = new CoditechRepository<BankPostingLoanAccount>(_serviceProvider.GetService<CoditechCustom_Entities>()).Table.Where(x => x.BankPostingLoanAccountId == bankLoanRepaymentModel.BankPostingLoanAccountId)?.FirstOrDefault();
                bankLoanRepaymentModel.LoanAccountNumber = model.LoanAccountNumber;
                string loanAccountNumber = model.LoanAccountNumber.Length >= 4 ? model.LoanAccountNumber[^4..] : model.LoanAccountNumber;
                string paymentDate = bankLoanRepaymentModel.PaymentDate.ToString("yyyyMMdd");
                bankLoanRepaymentModel.ReceiptNumber = $"RCPT{loanAccountNumber}{paymentDate}{bankLoanRepaymentModel.BankPostingLoanAccountId:D4}";
                bankLoanRepayment = bankLoanRepaymentModel.FromEntityToModel<BankLoanRepayment>();
                bankLoanRepayment = _bankLoanRepaymentRepository.Insert(bankLoanRepayment);
                isUpdated = bankLoanRepayment.BankLoanRepaymentId > 0;
            }
            if (!isUpdated)
            {
                bankLoanRepaymentModel.HasError = true;
                bankLoanRepaymentModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isUpdated;
        }

        #region Protected Method

        #endregion

    }
}