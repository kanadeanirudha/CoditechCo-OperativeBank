using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Resources;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Service
{
    public class BankLoanScheduleService : IBankLoanScheduleService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankLoanSchedule> _bankLoanScheduleRepository;
        private readonly ICoditechRepository<BankPostingLoanAccount> _bankPostingLoanAccountRepository;
        public BankLoanScheduleService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankLoanScheduleRepository = new CoditechRepository<BankLoanSchedule>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankPostingLoanAccountRepository = new CoditechRepository<BankPostingLoanAccount>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        #region BankLoanSchedule

        //Create BankLoanSchedule.
        public virtual BankLoanScheduleModel CreateBankLoanSchedule(BankLoanScheduleModel bankLoanScheduleModel)
        {
            if (IsNull(bankLoanScheduleModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankLoanSchedule bankLoanSchedule = bankLoanScheduleModel.FromModelToEntity<BankLoanSchedule>();

            //Create new BankLoanSchedule and return it.
            BankLoanSchedule bankLoanScheduleData = _bankLoanScheduleRepository.Insert(bankLoanSchedule);
            if (bankLoanScheduleData?.BankLoanScheduleId > 0)
            {
                bankLoanScheduleModel.BankLoanScheduleId = bankLoanScheduleData.BankLoanScheduleId;
            }
            else
            {
                bankLoanScheduleModel.HasError = true;
                bankLoanScheduleModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankLoanScheduleModel;
        }

        // Get BankLoanSchedule by bankPostingLoanAccountId.
        public virtual BankLoanScheduleModel GetBankLoanSchedule(int bankPostingLoanAccountId)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankPostingLoanAccountId"));

            // Check if BankLoanSchedule already exists for this bankPostingLoanAccountId
            BankLoanSchedule existingBankLoanSchedule = _bankLoanScheduleRepository.Table.FirstOrDefault(x => x.BankPostingLoanAccountId == bankPostingLoanAccountId);

            if (existingBankLoanSchedule != null)
            {
                return new BankLoanScheduleModel
                {
                    BankLoanScheduleId = existingBankLoanSchedule.BankLoanScheduleId,
                    BankPostingLoanAccountId = existingBankLoanSchedule.BankPostingLoanAccountId,
                    Duedate = existingBankLoanSchedule.Duedate,
                    EMIAmount = existingBankLoanSchedule.EMIAmount,
                    PrincipalDue = existingBankLoanSchedule.PrincipalDue,
                    InterestDue = existingBankLoanSchedule.InterestDue,
                    LoanScheduleStatusEnumId = existingBankLoanSchedule.LoanScheduleStatusEnumId,
                };
            }

           // If no BankLoanSchedule → fetch BankPostingLoanAccount
            var bankPostingLoanAccount = _bankPostingLoanAccountRepository.Table.FirstOrDefault(x => x.BankPostingLoanAccountId == bankPostingLoanAccountId);

            if (bankPostingLoanAccount == null)
                throw new CoditechException(ErrorCodes.NotFound, "Bank Posting Loan Account not found.");

            // Calculate DueDate → SanctionedDate + 1 month
            var dueDate = bankPostingLoanAccount.SanctionedDate.AddMonths(1);

            // Return new model with filleds
            return new BankLoanScheduleModel
            {
                BankPostingLoanAccountId = bankPostingLoanAccount.BankPostingLoanAccountId,
                Duedate = dueDate,
            };
        }

        //Update BankLoanSchedule.
        public virtual bool UpdateBankLoanSchedule(BankLoanScheduleModel bankLoanScheduleModel)
        {
            if (IsNull(bankLoanScheduleModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankLoanScheduleModel.BankLoanScheduleId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankLoanScheduleId"));

            BankLoanSchedule bankLoanSchedule = bankLoanScheduleModel.FromModelToEntity<BankLoanSchedule>();

            //Update BankFixedDepositClosure
            bool isBankLoanScheduleUpdated = _bankLoanScheduleRepository.Update(bankLoanSchedule);
            if (!isBankLoanScheduleUpdated)
            {
                bankLoanScheduleModel.HasError = true;
                bankLoanScheduleModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankLoanScheduleUpdated;
        }
        #endregion
    }
}
