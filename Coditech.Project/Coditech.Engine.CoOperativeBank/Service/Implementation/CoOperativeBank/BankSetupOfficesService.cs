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
    public class BankSetupOfficesService : IBankSetupOfficesService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSetupOffices> _bankSetupOfficesRepository;
        public BankSetupOfficesService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSetupOfficesRepository = new CoditechRepository<BankSetupOffices>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankSetupOfficesListModel GetBankSetupOfficesList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSetupOfficesModel> objStoredProc = new CoditechViewRepository<BankSetupOfficesModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSetupOfficesModel> BankSetupOfficesList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankSetupOfficesList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSetupOfficesListModel listModel = new BankSetupOfficesListModel();

            listModel.BankSetupOfficesList = BankSetupOfficesList?.Count > 0 ? BankSetupOfficesList : new List<BankSetupOfficesModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankSetupOffices.
        public virtual BankSetupOfficesModel CreateBankSetupOffices(BankSetupOfficesModel bankSetupOfficesModel)
        {
            if (IsNull(bankSetupOfficesModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankSetupDivisionModel.InsurancePoliciesTypeCode, bankSetupDivisionModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSetupOffices bankSetupOffices = bankSetupOfficesModel.FromModelToEntity<BankSetupOffices>();

            //Create new BankSetupOffices and return it.
            BankSetupOffices bankSetupOfficesData = _bankSetupOfficesRepository.Insert(bankSetupOffices);
            if (bankSetupOfficesData?.BankSetupOfficeId > 0)
            {
                bankSetupOfficesModel.BankSetupDivisionId = bankSetupOfficesData.BankSetupDivisionId;
            }
            else
            {
                bankSetupOfficesModel.HasError = true;
                bankSetupOfficesModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankSetupOfficesModel;
        }

        //Get BankSetupOffices by bankSetupOfficeId.
        public virtual BankSetupOfficesModel GetBankSetupOffices(short bankSetupOfficeId)
        {
            if (bankSetupOfficeId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupOfficeID"));

            //Get the BankSetupOffices id.
            BankSetupOffices bankSetupOffices = _bankSetupOfficesRepository.Table.FirstOrDefault(x => x.BankSetupOfficeId == bankSetupOfficeId);
            BankSetupOfficesModel bankSetupOfficesModel = bankSetupOffices?.FromEntityToModel<BankSetupOfficesModel>();
            return bankSetupOfficesModel;
        }

        //Update BankSetupOffices.
        public virtual bool UpdateBankSetupOffices(BankSetupOfficesModel bankSetupOfficesModel)
        {
            if (IsNull(bankSetupOfficesModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSetupOfficesModel.BankSetupOfficeId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupOfficeID"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankSetupOffices bankSetupOffices = bankSetupOfficesModel.FromModelToEntity<BankSetupOffices>();

            //Update BankSetupDivision
            bool isBankSetupOfficesUpdated = _bankSetupOfficesRepository.Update(bankSetupOffices);
            if (!isBankSetupOfficesUpdated)
            {
                bankSetupOfficesModel.HasError = true;
                bankSetupOfficesModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankSetupOfficesUpdated;
        }

        //Delete BankSetupOffices.
        public virtual bool DeleteBankSetupOffices(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupOfficeID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSetupOfficeID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankSetupOffices @BankSetupOfficeId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        //#region Protected Method
        ////Check if Bank Setup Division is already present or not.
        //protected virtual bool IsBankInsurancePoliciesTypeAlreadyExist(string insurancePoliciesTypeCode, short bankInsurancePoliciesTypeId = 0)
        // => _bankInsurancePoliciesTypeRepository.Table.Any(x => x.InsurancePoliciesTypeCode == insurancePoliciesTypeCode && (x.BankInsurancePoliciesTypeId != bankInsurancePoliciesTypeId || bankInsurancePoliciesTypeId == 0));
        //#endregion
    }
}
