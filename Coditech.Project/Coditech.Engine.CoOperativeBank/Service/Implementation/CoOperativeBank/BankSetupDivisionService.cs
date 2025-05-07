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
    public class BankSetupDivisionService : IBankSetupDivisionService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSetupDivision> _bankSetupDivisionRepository;
        public BankSetupDivisionService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSetupDivisionRepository = new CoditechRepository<BankSetupDivision>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankSetupDivisionListModel GetBankSetupDivisionList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSetupDivisionModel> objStoredProc = new CoditechViewRepository<BankSetupDivisionModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSetupDivisionModel> BankSetupDivisionList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankSetupDivisionList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSetupDivisionListModel listModel = new BankSetupDivisionListModel();

            listModel.BankSetupDivisionList = BankSetupDivisionList?.Count > 0 ? BankSetupDivisionList : new List<BankSetupDivisionModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankInsurancePoliciesType.
        public virtual BankSetupDivisionModel CreateBankSetupDivision(BankSetupDivisionModel bankSetupDivisionModel)
        {
            if (IsNull(bankSetupDivisionModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankSetupDivisionModel.InsurancePoliciesTypeCode, bankSetupDivisionModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSetupDivision bankSetupDivision = bankSetupDivisionModel.FromModelToEntity<BankSetupDivision>();

            //Create new BankInsurancePoliciesType and return it.
            BankSetupDivision bankSetupDivisionData = _bankSetupDivisionRepository.Insert(bankSetupDivision);
            if (bankSetupDivisionData?.BankSetupDivisionId > 0)
            {
                bankSetupDivisionModel.BankSetupDivisionId = bankSetupDivisionData.BankSetupDivisionId;
            }
            else
            {
                bankSetupDivisionModel.HasError = true;
                bankSetupDivisionModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankSetupDivisionModel;
        }

        //Get Country by Country id.
        public virtual BankSetupDivisionModel GetBankSetupDivision(short bankSetupDivisionId)
        {
            if (bankSetupDivisionId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupDivisionIdID"));

            //Get the BankSetupDivision id.
            BankSetupDivision bankSetupDivision = _bankSetupDivisionRepository.Table.FirstOrDefault(x => x.BankSetupDivisionId == bankSetupDivisionId);
            BankSetupDivisionModel bankSetupDivisionModel = bankSetupDivision?.FromEntityToModel<BankSetupDivisionModel>();
            return bankSetupDivisionModel;
        }

        //Update BankSetupDivision.
        public virtual bool UpdateBankSetupDivision(BankSetupDivisionModel bankSetupDivisionModel)
        {
            if (IsNull(bankSetupDivisionModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSetupDivisionModel.BankSetupDivisionId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupDivisionID"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSetupDivision bankSetupDivision = bankSetupDivisionModel.FromModelToEntity<BankSetupDivision>();

            //Update BankSetupDivision
            bool isBankSetupDivisionUpdated = _bankSetupDivisionRepository.Update(bankSetupDivision);
            if (!isBankSetupDivisionUpdated)
            {
                bankSetupDivisionModel.HasError = true;
                bankSetupDivisionModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankSetupDivisionUpdated;
        }

        //Delete BankSetupDivision.
        public virtual bool DeleteBankSetupDivision(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupDivisionID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSetupDivisionID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankSetupDivision @BankSetupDivisionId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        //#region Protected Method
        ////Check if Bank Setup Division is already present or not.
        //protected virtual bool IsBankInsurancePoliciesTypeAlreadyExist(string insurancePoliciesTypeCode, short bankInsurancePoliciesTypeId = 0)
        // => _bankInsurancePoliciesTypeRepository.Table.Any(x => x.InsurancePoliciesTypeCode == insurancePoliciesTypeCode && (x.BankInsurancePoliciesTypeId != bankInsurancePoliciesTypeId || bankInsurancePoliciesTypeId == 0));
        //#endregion
    }
}
