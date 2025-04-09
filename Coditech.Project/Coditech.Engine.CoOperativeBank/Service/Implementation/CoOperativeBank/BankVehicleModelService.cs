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
    public class BankVehicleModelService : IBankVehicleModelService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankVehicleModel> _bankVehicleModelRepository;
        public BankVehicleModelService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankVehicleModelRepository = new CoditechRepository<BankVehicleModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        public virtual BankVehicleModelListModel GetVehicleModelList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankVehicleModelModel> objStoredProc = new CoditechViewRepository<BankVehicleModelModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankVehicleModelModel> BankVehicleModelList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankVehicleModelList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankVehicleModelListModel listModel = new BankVehicleModelListModel();

            listModel.BankVehicleModelList = BankVehicleModelList?.Count > 0 ? BankVehicleModelList : new List<BankVehicleModelModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankVehicleModel.
        public virtual BankVehicleModelModel CreateVehicleModel(BankVehicleModelModel bankVehicleModelModel)
        {
            if (IsNull(bankVehicleModelModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankVehicleModel BankVehicleModel = bankVehicleModelModel.FromModelToEntity<BankVehicleModel>();

            //Create new BankVehicleModel and return it.
            BankVehicleModel BankVehicleModelData = _bankVehicleModelRepository.Insert(BankVehicleModel);
             if (BankVehicleModel?.BankVehicleModelId > 0)
             {
                bankVehicleModelModel.BankVehicleModelId = BankVehicleModelData.BankVehicleModelId;
             }
             else
             {
                bankVehicleModelModel.HasError = true;
                bankVehicleModelModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
             }
             return bankVehicleModelModel;
        }

        //Get BankVehicleModel by BankVehicleModel id.
        public virtual BankVehicleModelModel GetVehicleModel(short bankVehicleModelId)
        {
            if (bankVehicleModelId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankVehicleModel"));

            //Get the BankVehicleModel Details based on id.
            BankVehicleModel bankVehicleModel = _bankVehicleModelRepository.Table.FirstOrDefault(x => x.BankVehicleModelId == bankVehicleModelId);
            BankVehicleModelModel bankVehicleModelModel = bankVehicleModel?.FromEntityToModel<BankVehicleModelModel>();
            return bankVehicleModelModel;
        }

        //Update BankVehicleModel.
        public virtual bool UpdateVehicleModel(BankVehicleModelModel bankVehicleModelModel)
        {
            if (IsNull(bankVehicleModelModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (IsBankVehicleModelExist(bankVehicleModelModel.VehicleModel, bankVehicleModelModel.BankVehicleModelId))
               throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Property Code"));


            if (bankVehicleModelModel.BankVehicleModelId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupMortagePropertyTypeId"));


            BankVehicleModel bankVehicleModel = bankVehicleModelModel.FromModelToEntity<BankVehicleModel>();

            //Update BankVehicleModel
            bool isVehicleModelUpdated = _bankVehicleModelRepository.Update(bankVehicleModel);
            if (!isVehicleModelUpdated)
            {
                bankVehicleModelModel.HasError = true;
                bankVehicleModelModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isVehicleModelUpdated;
        }

        //Delete BankVehicleModel.
        public virtual bool DeleteVehicleModel(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankVehicleModelId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankVehicleModelId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteVehicleModel @BankVehicleModelId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }


        protected virtual bool IsBankVehicleModelExist(string VehicleModel, short bankVehicleModel = 0)
         => _bankVehicleModelRepository.Table.Any(x => x.VehicleModel == VehicleModel && (x.BankVehicleModelId != bankVehicleModel || bankVehicleModel == 0));


    }
}