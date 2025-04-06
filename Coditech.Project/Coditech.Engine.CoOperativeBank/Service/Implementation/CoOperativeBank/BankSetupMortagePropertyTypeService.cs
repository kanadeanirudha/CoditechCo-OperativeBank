using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Resources;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Specialized;
using System.Data;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Service
{
    public class BankSetupMortagePropertyTypeService : IBankSetupMortagePropertyTypeService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSetupMortagePropertyType> _bankSetupMortagePropertyTypeRepository;
        public BankSetupMortagePropertyTypeService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSetupMortagePropertyTypeRepository = new CoditechRepository<BankSetupMortagePropertyType>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        public virtual BankSetupMortagePropertyTypeListModel GetPropertyTypeList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSetupMortagePropertyTypeModel> objStoredProc = new CoditechViewRepository<BankSetupMortagePropertyTypeModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSetupMortagePropertyTypeModel> BankSetupMortagePropertyTypeList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetPropertyTypeList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSetupMortagePropertyTypeListModel listModel = new BankSetupMortagePropertyTypeListModel();

            listModel.BankSetupMortagePropertyTypeList = BankSetupMortagePropertyTypeList?.Count > 0 ? BankSetupMortagePropertyTypeList : new List<BankSetupMortagePropertyTypeModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankSetupMortagePropertyType.
        public virtual BankSetupMortagePropertyTypeModel CreatePropertyType(BankSetupMortagePropertyTypeModel bankSetupMortagePropertyTypeModel)
        {
            if (IsNull(bankSetupMortagePropertyTypeModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

             BankSetupMortagePropertyType BankSetupMortagePropertyType = bankSetupMortagePropertyTypeModel.FromModelToEntity<BankSetupMortagePropertyType>();

            //Create new BankSetupMortagePropertyType and return it.
             BankSetupMortagePropertyType BankSetupMortagePropertyTypeData = _bankSetupMortagePropertyTypeRepository.Insert(BankSetupMortagePropertyType);
             if (BankSetupMortagePropertyType?.BankSetupMortagePropertyTypeId > 0)
             {
                bankSetupMortagePropertyTypeModel.BankSetupMortagePropertyTypeId = BankSetupMortagePropertyTypeData.BankSetupMortagePropertyTypeId;
             }
             else
             {
                bankSetupMortagePropertyTypeModel.HasError = true;
                bankSetupMortagePropertyTypeModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
             }
             return bankSetupMortagePropertyTypeModel;
        }

        //Get BankSetupMortagePropertyType by BankSetupMortagePropertyType id.
        public virtual BankSetupMortagePropertyTypeModel GetPropertyType(short bankSetupMortagePropertyTypeId)
        {
            if (bankSetupMortagePropertyTypeId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupMortagePropertyType"));

            //Get the FinancialYear Details based on id.
            BankSetupMortagePropertyType bankSetupMortagePropertyType = _bankSetupMortagePropertyTypeRepository.Table.FirstOrDefault(x => x.BankSetupMortagePropertyTypeId == bankSetupMortagePropertyTypeId);
            BankSetupMortagePropertyTypeModel bankSetupMortagePropertyTypeModel = bankSetupMortagePropertyType?.FromEntityToModel<BankSetupMortagePropertyTypeModel>();
            return bankSetupMortagePropertyTypeModel;
        }

        //Update BankSetupMortagePropertyType.
        public virtual bool UpdatePropertyType(BankSetupMortagePropertyTypeModel bankSetupMortagePropertyTypeModel)
        {
            if (IsNull(bankSetupMortagePropertyTypeModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (IsBankSetupMortagePropertyTypeExist(bankSetupMortagePropertyTypeModel.PropertyCode, bankSetupMortagePropertyTypeModel.BankSetupMortagePropertyTypeId))
               throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Property Code"));


            if (bankSetupMortagePropertyTypeModel.BankSetupMortagePropertyTypeId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupMortagePropertyTypeId"));


            BankSetupMortagePropertyType bankSetupMortagePropertyType = bankSetupMortagePropertyTypeModel.FromModelToEntity<BankSetupMortagePropertyType>();

            //Update BankSetupMortagePropertyType
            bool isPropertyTypeUpdated = _bankSetupMortagePropertyTypeRepository.Update(bankSetupMortagePropertyType);
            if (!isPropertyTypeUpdated)
            {
                bankSetupMortagePropertyTypeModel.HasError = true;
                bankSetupMortagePropertyTypeModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isPropertyTypeUpdated;
        }

        //Delete BankSetupMortagePropertyType.
        public virtual bool DeletePropertyType(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupMortagePropertyTypeId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSetupMortagePropertyTypeId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeletePropertyType @BankSetupMortagePropertyTypeId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }


        protected virtual bool IsBankSetupMortagePropertyTypeExist(string PropertyCode, short bankSetupMortagePropertyType = 0)
         => _bankSetupMortagePropertyTypeRepository.Table.Any(x => x.PropertyCode == PropertyCode && (x.BankSetupMortagePropertyTypeId != bankSetupMortagePropertyType || bankSetupMortagePropertyType == 0));


    }
}