using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Resources;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Service
{
    public class BankSavingsAccountTransactionsService : IBankSavingsAccountTransactionsService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSavingsAccountTransactions> _bankSavingsAccountTransactionsRepository;
        public BankSavingsAccountTransactionsService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSavingsAccountTransactionsRepository = new CoditechRepository<BankSavingsAccountTransactions>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        #region BankSavingsAccountTransactions

        //Create BankSavingsAccountTransactions.
        public virtual BankSavingsAccountTransactionsModel CreateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel bankSavingsAccountTransactionsModel)
        {
            if (IsNull(bankSavingsAccountTransactionsModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankSavingsAccountTransactions bankSavingsAccountTransactions = bankSavingsAccountTransactionsModel.FromModelToEntity<BankSavingsAccountTransactions>();

            //Create new BankSavingsAccountTransactions and return it.
            BankSavingsAccountTransactions bankSavingsAccountTransactionsData = _bankSavingsAccountTransactionsRepository.Insert(bankSavingsAccountTransactions);
            if (bankSavingsAccountTransactionsData?.BankSavingsTransactionsId > 0)
            {
                bankSavingsAccountTransactionsModel.BankSavingsTransactionsId = bankSavingsAccountTransactionsData.BankSavingsTransactionsId;
            }
            else
            {
                bankSavingsAccountTransactionsModel.HasError = true;
                bankSavingsAccountTransactionsModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankSavingsAccountTransactionsModel;
        }

        // Get BankSavingsAccountTransactions by bankFixedDepositAccountId.
        public virtual BankSavingsAccountTransactionsModel GetBankSavingsAccountTransactions(long bankSavingsAccountId)
        {
            if (bankSavingsAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingsAccountId"));

            // Step 1: Check if BankSavingsAccountTransactions already exists for this account
            BankSavingsAccountTransactions existingBankSavingsAccountTransactions = _bankSavingsAccountTransactionsRepository.Table.FirstOrDefault(x => x.BankSavingsAccountId == bankSavingsAccountId);

            if (existingBankSavingsAccountTransactions != null)
            {
                return new BankSavingsAccountTransactionsModel
                {
                    BankSavingsTransactionsId = existingBankSavingsAccountTransactions.BankSavingsTransactionsId,
                    BankSavingsAccountId = existingBankSavingsAccountTransactions.BankSavingsAccountId,
                    TranscationDate = existingBankSavingsAccountTransactions.TranscationDate,
                    BankSavingsTranscationTypeEnumId = existingBankSavingsAccountTransactions.BankSavingsTranscationTypeEnumId,
                    Amount = existingBankSavingsAccountTransactions.Amount,
                    PaymentModeEnumId = existingBankSavingsAccountTransactions.PaymentModeEnumId,
                    BalanceAfter = existingBankSavingsAccountTransactions.BalanceAfter,
                    CheckingApprovalEnumId = existingBankSavingsAccountTransactions.CheckingApprovalEnumId,
                    TransactionStatusEnumId = existingBankSavingsAccountTransactions.TransactionStatusEnumId,
                    TransactionalRemark = existingBankSavingsAccountTransactions.TransactionalRemark,
                    IsEndOfDate = existingBankSavingsAccountTransactions.IsEndOfDate,
                    EODDate = existingBankSavingsAccountTransactions.EODDate,
                    EODTimeStamp = existingBankSavingsAccountTransactions.EODTimeStamp,
                    TranscationPosting = existingBankSavingsAccountTransactions.TranscationPosting,
                    VoucherNumber = existingBankSavingsAccountTransactions.VoucherNumber,
                };
            }

            // If no BankSavingsAccountTransactions , return a new model with default values
            return new BankSavingsAccountTransactionsModel
            {
                BankSavingsAccountId = bankSavingsAccountId,
            };
        }

        //Update BankSavingsAccountTransactions.
        public virtual bool UpdateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel bankSavingsAccountTransactionsModel)
        {
            if (IsNull(bankSavingsAccountTransactionsModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSavingsAccountTransactionsModel.BankSavingsTransactionsId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingsTransactionsId"));

            BankSavingsAccountTransactions bankSavingsAccountTransactions = bankSavingsAccountTransactionsModel.FromModelToEntity<BankSavingsAccountTransactions>();

            //Update BankFixedDepositClosure
            bool isBankSavingsAccountTransactionsUpdated = _bankSavingsAccountTransactionsRepository.Update(bankSavingsAccountTransactions);
            if (!isBankSavingsAccountTransactionsUpdated)
            {
                bankSavingsAccountTransactionsModel.HasError = true;
                bankSavingsAccountTransactionsModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankSavingsAccountTransactionsUpdated;
        }
        #endregion
    }
}
