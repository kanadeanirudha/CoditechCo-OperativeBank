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
    public class BankSetupPropertyValuersAuthorityService : IBankSetupPropertyValuersAuthorityService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSetupPropertyValuersAuthority> _bankSetupPropertyValuersAuthorityRepository;
        public BankSetupPropertyValuersAuthorityService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSetupPropertyValuersAuthorityRepository = new CoditechRepository<BankSetupPropertyValuersAuthority>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        public virtual BankSetupPropertyValuersAuthorityListModel GetPropertyValuersAuthorityList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSetupPropertyValuersAuthorityModel> objStoredProc = new CoditechViewRepository<BankSetupPropertyValuersAuthorityModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSetupPropertyValuersAuthorityModel> BankSetupPropertyValuersAuthorityList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankSetupPropertyValuersAuthorityList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSetupPropertyValuersAuthorityListModel listModel = new BankSetupPropertyValuersAuthorityListModel();

            listModel.BankSetupPropertyValuersAuthorityList = BankSetupPropertyValuersAuthorityList?.Count > 0 ? BankSetupPropertyValuersAuthorityList : new List<BankSetupPropertyValuersAuthorityModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankSetupPropertyValuersAuthority.
        public virtual BankSetupPropertyValuersAuthorityModel CreatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel bankSetupPropertyValuersAuthorityModel)
        {
            if (IsNull(bankSetupPropertyValuersAuthorityModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankSetupPropertyValuersAuthority BankSetupPropertyValuersAuthority = bankSetupPropertyValuersAuthorityModel.FromModelToEntity<BankSetupPropertyValuersAuthority>();

            //Create new BankSetupPropertyValuersAuthority and return it.
            BankSetupPropertyValuersAuthority BankSetupPropertyValuersAuthorityData = _bankSetupPropertyValuersAuthorityRepository.Insert(BankSetupPropertyValuersAuthority);
             if (BankSetupPropertyValuersAuthority?.BankSetupPropertyValuersAuthorityId > 0)
             {
                bankSetupPropertyValuersAuthorityModel.BankSetupPropertyValuersAuthorityId = BankSetupPropertyValuersAuthorityData.BankSetupPropertyValuersAuthorityId;
             }
             else
             {
                bankSetupPropertyValuersAuthorityModel.HasError = true;
                bankSetupPropertyValuersAuthorityModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
             }
             return bankSetupPropertyValuersAuthorityModel;
        }

        //Get BankSetupPropertyValuersAuthority by BankSetupPropertyValuersAuthority id.
        public virtual BankSetupPropertyValuersAuthorityModel GetPropertyValuersAuthority(short bankSetupPropertyValuersAuthorityId)
        {
            if (bankSetupPropertyValuersAuthorityId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupPropertyValuersAuthority"));

            //Get the BankSetupPropertyValuers Details based on id.
            BankSetupPropertyValuersAuthority bankSetupPropertyValuersAuthority = _bankSetupPropertyValuersAuthorityRepository.Table.FirstOrDefault(x => x.BankSetupPropertyValuersAuthorityId == bankSetupPropertyValuersAuthorityId);
            BankSetupPropertyValuersAuthorityModel bankSetupPropertyValuersAuthorityModel = bankSetupPropertyValuersAuthority?.FromEntityToModel<BankSetupPropertyValuersAuthorityModel>();
            return bankSetupPropertyValuersAuthorityModel;
        }

        //Update BankSetupPropertyValuersAuthority.
        public virtual bool UpdatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel bankSetupPropertyValuersAuthorityModel)
        {
            if (IsNull(bankSetupPropertyValuersAuthorityModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSetupPropertyValuersAuthorityModel.BankSetupPropertyValuersAuthorityId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupPropertyValuersAuthorityId"));

            BankSetupPropertyValuersAuthority bankSetupPropertyValuersAuthority = bankSetupPropertyValuersAuthorityModel.FromModelToEntity<BankSetupPropertyValuersAuthority>();

            //Update BankSetupPropertyValuersAuthority
            bool isPropertyValuersAuthorityUpdated = _bankSetupPropertyValuersAuthorityRepository.Update(bankSetupPropertyValuersAuthority);
            if (!isPropertyValuersAuthorityUpdated)
            {
                bankSetupPropertyValuersAuthorityModel.HasError = true;
                bankSetupPropertyValuersAuthorityModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isPropertyValuersAuthorityUpdated;
        }

        //Delete BankSetupPropertyValuersAuthority.
        public virtual bool DeletePropertyValuersAuthority(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupPropertyValuersAuthorityId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSetupPropertyValuersAuthorityId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankSetupPropertyValuersAuthority @BankSetupPropertyValuersAuthorityId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

    }
}