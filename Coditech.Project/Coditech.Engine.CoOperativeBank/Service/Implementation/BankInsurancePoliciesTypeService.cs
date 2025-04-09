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
    public class BankInsurancePoliciesTypeService : IBankInsurancePoliciesTypeService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankInsurancePoliciesType> _bankInsurancePoliciesTypeRepository;
        public BankInsurancePoliciesTypeService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankInsurancePoliciesTypeRepository = new CoditechRepository<BankInsurancePoliciesType>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }
        public virtual BankInsurancePoliciesTypeListModel GetBankInsurancePoliciesTypeList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankInsurancePoliciesTypeModel> objStoredProc = new CoditechViewRepository<BankInsurancePoliciesTypeModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankInsurancePoliciesTypeModel> BankInsurancePoliciesTypeList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankInsurancePoliciesTypeList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankInsurancePoliciesTypeListModel listModel = new BankInsurancePoliciesTypeListModel();

            listModel.BankInsurancePoliciesTypeList = BankInsurancePoliciesTypeList?.Count > 0 ? BankInsurancePoliciesTypeList : new List<BankInsurancePoliciesTypeModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankInsurancePoliciesType.
        public virtual BankInsurancePoliciesTypeModel CreateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel bankInsurancePoliciesTypeModel)
        {
            if (IsNull(bankInsurancePoliciesTypeModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
                throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankInsurancePoliciesType bankInsurancePoliciesType = bankInsurancePoliciesTypeModel.FromModelToEntity<BankInsurancePoliciesType>();

            //Create new BankInsurancePoliciesType and return it.
            BankInsurancePoliciesType bankInsurancePoliciesTypeData = _bankInsurancePoliciesTypeRepository.Insert(bankInsurancePoliciesType);
            if (bankInsurancePoliciesTypeData?.BankInsurancePoliciesTypeId > 0)
            {
                bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId = bankInsurancePoliciesTypeData.BankInsurancePoliciesTypeId;
            }
            else
            {
                bankInsurancePoliciesTypeModel.HasError = true;
                bankInsurancePoliciesTypeModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankInsurancePoliciesTypeModel;
        }

        //Get Country by Country id.
        public virtual BankInsurancePoliciesTypeModel GetBankInsurancePoliciesType(short bankInsurancePoliciesTypeId)
        {
            if (bankInsurancePoliciesTypeId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankInsurancePoliciesTypeID"));

            //Get the Country Details based on id.
            BankInsurancePoliciesType bankInsurancePoliciesType = _bankInsurancePoliciesTypeRepository.Table.FirstOrDefault(x => x.BankInsurancePoliciesTypeId == bankInsurancePoliciesTypeId);
            BankInsurancePoliciesTypeModel bankInsurancePoliciesTypeModel = bankInsurancePoliciesType?.FromEntityToModel<BankInsurancePoliciesTypeModel>();
            return bankInsurancePoliciesTypeModel;
        }

        //Update BankInsurancePoliciesType.
        public virtual bool UpdateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel bankInsurancePoliciesTypeModel)
        {
            if (IsNull(bankInsurancePoliciesTypeModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankInsurancePoliciesTypeID"));

            if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
                throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankInsurancePoliciesType bankInsurancePoliciesType = bankInsurancePoliciesTypeModel.FromModelToEntity<BankInsurancePoliciesType>();

            //Update Country
            bool isBankInsurancePoliciesTypeUpdated = _bankInsurancePoliciesTypeRepository.Update(bankInsurancePoliciesType);
            if (!isBankInsurancePoliciesTypeUpdated)
            {
                bankInsurancePoliciesTypeModel.HasError = true;
                bankInsurancePoliciesTypeModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankInsurancePoliciesTypeUpdated;
        }

        //Delete BankInsurancePoliciesType.
        public virtual bool DeleteBankInsurancePoliciesType(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankInsurancePoliciesTypeID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankInsurancePoliciesTypeID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankInsurancePoliciesType @BankInsurancePoliciesTypeId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        #region Protected Method
        //Check if Insurance Policies Type code is already present or not.
        protected virtual bool IsBankInsurancePoliciesTypeAlreadyExist(string insurancePoliciesTypeCode, short bankInsurancePoliciesTypeId = 0)
         => _bankInsurancePoliciesTypeRepository.Table.Any(x => x.InsurancePoliciesTypeCode == insurancePoliciesTypeCode && (x.BankInsurancePoliciesTypeId != bankInsurancePoliciesTypeId || bankInsurancePoliciesTypeId == 0));
        #endregion
    }
}
