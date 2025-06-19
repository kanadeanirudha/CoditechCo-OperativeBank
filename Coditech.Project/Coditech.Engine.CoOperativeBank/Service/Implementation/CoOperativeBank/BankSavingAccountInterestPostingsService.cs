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
    public class BankSavingAccountInterestPostingsService : IBankSavingAccountInterestPostingsService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSavingAccountInterestPostings> _bankSavingAccountInterestPostingsRepository;
        private readonly ICoditechRepository<BankSavingsAccount> _bankSavingsAccountRepository;
        public BankSavingAccountInterestPostingsService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSavingAccountInterestPostingsRepository = new CoditechRepository<BankSavingAccountInterestPostings>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankSavingsAccountRepository = new CoditechRepository<BankSavingsAccount>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankSavingAccountInterestPostingsListModel GetBankSavingAccountInterestPostingsList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSavingAccountInterestPostingsModel> objStoredProc = new CoditechViewRepository<BankSavingAccountInterestPostingsModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSavingAccountInterestPostingsModel> bankSavingAccountInterestPostingsList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankSavingAccountInterestPostingsList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSavingAccountInterestPostingsListModel listModel = new BankSavingAccountInterestPostingsListModel();

            listModel.BankSavingAccountInterestPostingsList = bankSavingAccountInterestPostingsList?.Count > 0 ? bankSavingAccountInterestPostingsList : new List<BankSavingAccountInterestPostingsModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankSavingAccountIntrestPostings.
        public virtual BankSavingAccountInterestPostingsModel CreateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsModel bankSavingAccountInterestPostingsModel)
        {
            if (IsNull(bankSavingAccountInterestPostingsModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSavingAccountInterestPostings bankSavingAccountInterestPostings = bankSavingAccountInterestPostingsModel.FromModelToEntity<BankSavingAccountInterestPostings>();

            //Create new BankSavingAccountIntrestPostings and return it.
            BankSavingAccountInterestPostings bankSavingAccountInterestPostingsData = _bankSavingAccountInterestPostingsRepository.Insert(bankSavingAccountInterestPostings);
            if (bankSavingAccountInterestPostingsData?.BankSavingAccountInterestPostingsId > 0)
            {
                bankSavingAccountInterestPostingsModel.BankSavingAccountInterestPostingsId = bankSavingAccountInterestPostingsData.BankSavingAccountInterestPostingsId;
            }
            else
            {
                bankSavingAccountInterestPostingsModel.HasError = true;
                bankSavingAccountInterestPostingsModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankSavingAccountInterestPostingsModel;
        }

        //Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        public virtual BankSavingAccountInterestPostingsModel GetBankSavingAccountInterestPostings(int bankSavingsAccountId)
        {
            if (bankSavingsAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingsAccountId"));

            // Step 1: Check if BankFixedDepositClosure already exists for this account
            BankSavingAccountInterestPostings existingBankSavingAccountInterestPostings = _bankSavingAccountInterestPostingsRepository.Table.FirstOrDefault(x => x.BankSavingsAccountId == bankSavingsAccountId);

            if (existingBankSavingAccountInterestPostings != null)
            {
                return new BankSavingAccountInterestPostingsModel
                {
                    BankSavingAccountInterestPostingsId = existingBankSavingAccountInterestPostings.BankSavingAccountInterestPostingsId,
                    BankSavingsAccountId = existingBankSavingAccountInterestPostings.BankSavingsAccountId,
                    PeriodStartDate = existingBankSavingAccountInterestPostings.PeriodStartDate,
                    PeriodEndDate = existingBankSavingAccountInterestPostings.PeriodEndDate,
                    InterestAmount = existingBankSavingAccountInterestPostings.InterestAmount,
                    PostedOn = existingBankSavingAccountInterestPostings.PostedOn,
                };
            }

            // If no existingBankFixedDepositClosure , return a new model with default values
            return new BankSavingAccountInterestPostingsModel
            {
                BankSavingsAccountId = bankSavingsAccountId,
            };
        }

        //Update BankSavingAccountIntrestPostings.
        public virtual bool UpdateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsModel bankSavingAccountInterestPostingsModel)
        {
            if (IsNull(bankSavingAccountInterestPostingsModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSavingAccountInterestPostingsModel.BankSavingAccountInterestPostingsId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingAccountIntrestPostingsID"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSavingAccountInterestPostings bankSavingAccountInterestPostings = bankSavingAccountInterestPostingsModel.FromModelToEntity<BankSavingAccountInterestPostings>();

            //Update BankSavingAccountIntrestPostings
            bool isBankSavingAccountInterestPostingsUpdated = _bankSavingAccountInterestPostingsRepository.Update(bankSavingAccountInterestPostings);
            if (!isBankSavingAccountInterestPostingsUpdated)
            {
                bankSavingAccountInterestPostingsModel.HasError = true;
                bankSavingAccountInterestPostingsModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankSavingAccountInterestPostingsUpdated;
        }

        //Delete BankSavingAccountIntrestPostings.
        public virtual bool DeleteBankSavingAccountInterestPostings(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingAccountInterestPostingsID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSavingAccountInterestPostingsID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankSavingAccountInterestPostings @BankSavingAccountInterestPostingsId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        //#region Protected Method
        ////Check if Insurance Policies Type code is already present or not.
        //protected virtual bool IsBankInsurancePoliciesTypeAlreadyExist(string insurancePoliciesTypeCode, short bankInsurancePoliciesTypeId = 0)
        // => _bankInsurancePoliciesTypeRepository.Table.Any(x => x.InsurancePoliciesTypeCode == insurancePoliciesTypeCode && (x.BankInsurancePoliciesTypeId != bankInsurancePoliciesTypeId || bankInsurancePoliciesTypeId == 0));
        //#endregion
    }
}
