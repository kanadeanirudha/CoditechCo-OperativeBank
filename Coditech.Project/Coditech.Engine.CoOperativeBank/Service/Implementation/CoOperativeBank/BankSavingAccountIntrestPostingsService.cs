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
    public class BankSavingAccountIntrestPostingsService : IBankSavingAccountIntrestPostingsService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSavingAccountIntrestPostings> _bankSavingAccountIntrestPostingsRepository;
        private readonly ICoditechRepository<BankSavingsAccount> _bankSavingsAccountRepository;
        public BankSavingAccountIntrestPostingsService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSavingAccountIntrestPostingsRepository = new CoditechRepository<BankSavingAccountIntrestPostings>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _bankSavingsAccountRepository = new CoditechRepository<BankSavingsAccount>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankSavingAccountIntrestPostingsListModel GetBankSavingAccountIntrestPostingsList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSavingAccountIntrestPostingsModel> objStoredProc = new CoditechViewRepository<BankSavingAccountIntrestPostingsModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSavingAccountIntrestPostingsModel> bankSavingAccountIntrestPostingsList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankSavingAccountIntrestPostingsList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSavingAccountIntrestPostingsListModel listModel = new BankSavingAccountIntrestPostingsListModel();

            listModel.BankSavingAccountIntrestPostingsList = bankSavingAccountIntrestPostingsList?.Count > 0 ? bankSavingAccountIntrestPostingsList : new List<BankSavingAccountIntrestPostingsModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankSavingAccountIntrestPostings.
        public virtual BankSavingAccountIntrestPostingsModel CreateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel bankSavingAccountIntrestPostingsModel)
        {
            if (IsNull(bankSavingAccountIntrestPostingsModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSavingAccountIntrestPostings bankSavingAccountIntrestPostings = bankSavingAccountIntrestPostingsModel.FromModelToEntity<BankSavingAccountIntrestPostings>();

            //Create new BankSavingAccountIntrestPostings and return it.
            BankSavingAccountIntrestPostings bankSavingAccountIntrestPostingsData = _bankSavingAccountIntrestPostingsRepository.Insert(bankSavingAccountIntrestPostings);
            if (bankSavingAccountIntrestPostingsData?.BankSavingAccountIntrestPostingsId > 0)
            {
                bankSavingAccountIntrestPostingsModel.BankSavingAccountIntrestPostingsId = bankSavingAccountIntrestPostingsData.BankSavingAccountIntrestPostingsId;
            }
            else
            {
                bankSavingAccountIntrestPostingsModel.HasError = true;
                bankSavingAccountIntrestPostingsModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankSavingAccountIntrestPostingsModel;
        }

        //Get BankSavingAccountIntrestPostings by bankSavingAccountIntrestPostingsId.
        public virtual BankSavingAccountIntrestPostingsModel GetBankSavingAccountIntrestPostings(int bankSavingsAccountId)
        {
            if (bankSavingsAccountId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingsAccountId"));

            // Step 1: Check if BankFixedDepositClosure already exists for this account
            BankSavingAccountIntrestPostings existingBankSavingAccountIntrestPostings = _bankSavingAccountIntrestPostingsRepository.Table.FirstOrDefault(x => x.BankSavingsAccountId == bankSavingsAccountId);

            if (existingBankSavingAccountIntrestPostings != null)
            {
                return new BankSavingAccountIntrestPostingsModel
                {
                    BankSavingAccountIntrestPostingsId = existingBankSavingAccountIntrestPostings.BankSavingAccountIntrestPostingsId,
                    BankSavingsAccountId = existingBankSavingAccountIntrestPostings.BankSavingsAccountId,
                    PeriodStartDate = existingBankSavingAccountIntrestPostings.PeriodStartDate,
                    PeriodEndDate = existingBankSavingAccountIntrestPostings.PeriodEndDate,
                    InterestAmount = existingBankSavingAccountIntrestPostings.InterestAmount,
                    PostedOn = existingBankSavingAccountIntrestPostings.PostedOn,
                };
            }

            // If no existingBankFixedDepositClosure , return a new model with default values
            return new BankSavingAccountIntrestPostingsModel
            {
                BankSavingsAccountId = bankSavingsAccountId,
            };
        }

        //Update BankSavingAccountIntrestPostings.
        public virtual bool UpdateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel bankSavingAccountIntrestPostingsModel)
        {
            if (IsNull(bankSavingAccountIntrestPostingsModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSavingAccountIntrestPostingsModel.BankSavingAccountIntrestPostingsId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingAccountIntrestPostingsID"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSavingAccountIntrestPostings bankSavingAccountIntrestPostings = bankSavingAccountIntrestPostingsModel.FromModelToEntity<BankSavingAccountIntrestPostings>();

            //Update BankSavingAccountIntrestPostings
            bool isBankSavingAccountIntrestPostingsUpdated = _bankSavingAccountIntrestPostingsRepository.Update(bankSavingAccountIntrestPostings);
            if (!isBankSavingAccountIntrestPostingsUpdated)
            {
                bankSavingAccountIntrestPostingsModel.HasError = true;
                bankSavingAccountIntrestPostingsModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankSavingAccountIntrestPostingsUpdated;
        }

        //Delete BankSavingAccountIntrestPostings.
        public virtual bool DeleteBankSavingAccountIntrestPostings(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSavingAccountIntrestPostingsID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSavingAccountIntrestPostingsID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankSavingAccountIntrestPostings @BankSavingAccountIntrestPostingsId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        //#region Protected Method
        ////Check if Insurance Policies Type code is already present or not.
        //protected virtual bool IsBankInsurancePoliciesTypeAlreadyExist(string insurancePoliciesTypeCode, short bankInsurancePoliciesTypeId = 0)
        // => _bankInsurancePoliciesTypeRepository.Table.Any(x => x.InsurancePoliciesTypeCode == insurancePoliciesTypeCode && (x.BankInsurancePoliciesTypeId != bankInsurancePoliciesTypeId || bankInsurancePoliciesTypeId == 0));
        //#endregion
    }
}
