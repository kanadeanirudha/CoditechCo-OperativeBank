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
    public class BankMemberShareCapitalService : IBankMemberShareCapitalService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankMemberShareCapital> _bankMemberShareCapitalRepository;
        public BankMemberShareCapitalService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankMemberShareCapitalRepository = new CoditechRepository<BankMemberShareCapital>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        public virtual BankMemberShareCapitalListModel GetMemberShareCapitalList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankMemberShareCapitalModel> objStoredProc = new CoditechViewRepository<BankMemberShareCapitalModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankMemberShareCapitalModel> BankMemberShareCapitalList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankMemberShareCapitalList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankMemberShareCapitalListModel listModel = new BankMemberShareCapitalListModel();
            listModel.BankMemberShareCapitalList = BankMemberShareCapitalList?.Count > 0 ? BankMemberShareCapitalList : new List<BankMemberShareCapitalModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }

        //Create BankMemberShareCapital.
        public virtual BankMemberShareCapitalModel CreateMemberShareCapital(BankMemberShareCapitalModel bankMemberShareCapitalModel)
        {
            if (IsNull(bankMemberShareCapitalModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankMemberShareCapital BankMemberShareCapital = bankMemberShareCapitalModel.FromModelToEntity<BankMemberShareCapital>();
            //Create new BankMemberShareCapital and return it.
            BankMemberShareCapital BankMemberShareCapitalData = _bankMemberShareCapitalRepository.Insert(BankMemberShareCapital);
            if (BankMemberShareCapital?.BankMemberShareCapitalId > 0)
            {
                bankMemberShareCapitalModel.BankMemberShareCapitalId = BankMemberShareCapitalData.BankMemberShareCapitalId;
            }
            if (bankMemberShareCapitalModel.BankMemberShareCapitalId > 0)
            {
                CoditechViewRepository<BankMemberShareCapitalModel> objStoredProc = new CoditechViewRepository<BankMemberShareCapitalModel>(_serviceProvider.GetService<Coditech_Entities>());
                objStoredProc.SetParameter("@BankMemberShareCapitalTransactionsId", 0, ParameterDirection.Input, DbType.Int64);
                objStoredProc.SetParameter("@BankMemberId", bankMemberShareCapitalModel.BankMemberId, ParameterDirection.Input, DbType.Int32);
                objStoredProc.SetParameter("@NumberOfShares", bankMemberShareCapitalModel.NumberOfShares, ParameterDirection.Input, DbType.Int32);
                objStoredProc.SetParameter("@AmountInvested", bankMemberShareCapitalModel.AmountInvested, ParameterDirection.Input, DbType.Decimal);
                objStoredProc.SetParameter("@PurchaseDate", bankMemberShareCapitalModel.PurchaseDate, ParameterDirection.Input, DbType.DateTime);
                objStoredProc.SetParameter("@SharePrice", bankMemberShareCapitalModel.SharePrice, ParameterDirection.Input, DbType.Decimal);
                objStoredProc.SetParameter("@PaymentModeEnumId", bankMemberShareCapitalModel.PaymentModeEnumId, ParameterDirection.Input, DbType.Int32);
                objStoredProc.SetParameter("@TranscationReference", bankMemberShareCapitalModel.TranscationReference, ParameterDirection.Input, DbType.String);
                objStoredProc.SetParameter("@Remarks", bankMemberShareCapitalModel.Remarks, ParameterDirection.Input, DbType.String);
                objStoredProc.SetParameter("@IsActive", bankMemberShareCapitalModel.IsActive, ParameterDirection.Input, DbType.Boolean);
                objStoredProc.SetParameter("@Status", bankMemberShareCapitalModel.Status, ParameterDirection.Output, DbType.Int32);
                int statusOutput = 0;
                // Execute the stored procedure
                objStoredProc.ExecuteStoredProcedureList(
                    "Coditech_BankMemberShareCapitalInsert @BankMemberShareCapitalTransactionsId,@BankMemberId,@NumberOfShares,@AmountInvested,@PurchaseDate,@SharePrice,@PaymentModeEnumId,@TranscationReference,@Remarks,@IsActive,@Status OUT",
                    10,
                    out statusOutput // Use the local variable to capture the output value
                );
                if (statusOutput == 0)
                {
                    bankMemberShareCapitalModel.HasError = true;
                    bankMemberShareCapitalModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
                    return bankMemberShareCapitalModel;
                }
                return bankMemberShareCapitalModel;
            }
            else
            {
                bankMemberShareCapitalModel.HasError = true;
                bankMemberShareCapitalModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankMemberShareCapitalModel;
        }

        //Get BankMemberShareCapital by BankMemberShareCapital id.
        public virtual BankMemberShareCapitalModel GetMemberShareCapital(int bankMemberId)
        {
            if (bankMemberId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberId"));

            // Step 1: Check if BankMemberShareCapital already exists for this account
            BankMemberShareCapital existingBankMemberShareCapital = _bankMemberShareCapitalRepository.Table.FirstOrDefault(x => x.BankMemberId == bankMemberId);

            if (existingBankMemberShareCapital != null)
            {
                return new BankMemberShareCapitalModel
                {
                    BankMemberShareCapitalId = existingBankMemberShareCapital.BankMemberShareCapitalId,
                    BankMemberId = existingBankMemberShareCapital.BankMemberId,
                    NumberOfShares = existingBankMemberShareCapital.NumberOfShares,
                    AmountInvested = existingBankMemberShareCapital.AmountInvested,
                    PurchaseDate = existingBankMemberShareCapital.PurchaseDate,
                    SharePrice = existingBankMemberShareCapital.SharePrice,
                    PaymentModeEnumId = existingBankMemberShareCapital.PaymentModeEnumId,
                    Remarks = existingBankMemberShareCapital.Remarks,
                    TranscationReference = existingBankMemberShareCapital.TranscationReference,
                    IsActive = existingBankMemberShareCapital.IsActive,
                };
            }
            // If no existingBankFixedDepositClosure , return a new model with default values
            return new BankMemberShareCapitalModel
            {
                BankMemberId = bankMemberId,
            };
        }

        //Update BankMemberShareCapital.
        public virtual bool UpdateMemberShareCapital(BankMemberShareCapitalModel bankMemberShareCapitalModel)
        {
            if (IsNull(bankMemberShareCapitalModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankMemberShareCapitalModel.BankMemberShareCapitalId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberShareCapital"));

            BankMemberShareCapital bankMemberShareCapital = bankMemberShareCapitalModel.FromModelToEntity<BankMemberShareCapital>();
            //Update BankMemberShareCapital
            bool isBankMemberShareCapitalUpdated = _bankMemberShareCapitalRepository.Update(bankMemberShareCapital);
            if (!isBankMemberShareCapitalUpdated)
            {
                bankMemberShareCapitalModel.HasError = true;
                bankMemberShareCapitalModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankMemberShareCapitalUpdated;
        }

        //Delete BankMemberShareCapital.
        public virtual bool DeleteMemberShareCapital(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberShareCapitalId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankMemberShareCapitalId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankMemberShareCapital @BankMemberShareCapitalId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }
    }
}