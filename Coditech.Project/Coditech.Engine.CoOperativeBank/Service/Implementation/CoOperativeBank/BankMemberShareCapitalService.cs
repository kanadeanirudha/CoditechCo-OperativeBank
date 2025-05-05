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
             else
             {
                bankMemberShareCapitalModel.HasError = true;
                bankMemberShareCapitalModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
             }
             return bankMemberShareCapitalModel;
        }

        //Get BankMemberShareCapital by BankMemberShareCapital id.
        public virtual BankMemberShareCapitalModel GetMemberShareCapital(int bankMemberShareCapitalId)
        {
            if (bankMemberShareCapitalId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberShareCapital"));

            //Get the BankMemberShareCapital Details based on id.
            BankMemberShareCapital bankMemberShareCapital = _bankMemberShareCapitalRepository.Table.FirstOrDefault(x => x.BankMemberShareCapitalId == bankMemberShareCapitalId);
            BankMemberShareCapitalModel bankMemberShareCapitalModel = bankMemberShareCapital?.FromEntityToModel<BankMemberShareCapitalModel>();
            return bankMemberShareCapitalModel;
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