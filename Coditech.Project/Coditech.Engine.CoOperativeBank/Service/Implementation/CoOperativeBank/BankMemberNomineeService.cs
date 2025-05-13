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
    public class BankMemberNomineeService : IBankMemberNomineeService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankMemberNominee> _bankMemberNomineeRepository;
        public BankMemberNomineeService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankMemberNomineeRepository = new CoditechRepository<BankMemberNominee>(_serviceProvider.GetService<CoditechCustom_Entities>());
        }

        public virtual BankMemberNomineeListModel GetMemberNomineeList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankMemberNomineeModel> objStoredProc = new CoditechViewRepository<BankMemberNomineeModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankMemberNomineeModel> BankMemberNomineeList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankMemberNomineeList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankMemberNomineeListModel listModel = new BankMemberNomineeListModel();
            listModel.BankMemberNomineeList = BankMemberNomineeList?.Count > 0 ? BankMemberNomineeList : new List<BankMemberNomineeModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }

        //Create BankMemberNominee.
        public virtual BankMemberNomineeModel CreateMemberNominee(BankMemberNomineeModel bankMemberNomineeModel)
        {
            if (IsNull(bankMemberNomineeModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            BankMemberNominee BankMemberNominee = bankMemberNomineeModel.FromModelToEntity<BankMemberNominee>();
            //Create new BankMemberNominee and return it.
            BankMemberNominee BankMemberNomineeData = _bankMemberNomineeRepository.Insert(BankMemberNominee);
             if (BankMemberNominee?.BankMemberNomineeId > 0)
             {
                bankMemberNomineeModel.BankMemberNomineeId = BankMemberNomineeData.BankMemberNomineeId;
             }
             else
             {
                bankMemberNomineeModel.HasError = true;
                bankMemberNomineeModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
             }
             return bankMemberNomineeModel;
        }

        //Get BankMemberNominee by BankMemberNominee id.
        public virtual BankMemberNomineeModel GetMemberNominee(int bankMemberNomineeId)
        {
            if (bankMemberNomineeId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberNominee"));

            //Get the BankMemberNominee Details based on id.
            BankMemberNominee bankMemberNominee = _bankMemberNomineeRepository.Table.FirstOrDefault(x => x.BankMemberNomineeId == bankMemberNomineeId);
            BankMemberNomineeModel bankMemberNomineeModel = bankMemberNominee?.FromEntityToModel<BankMemberNomineeModel>();
            return bankMemberNomineeModel;
        }

        //Update BankMemberNominee.
        public virtual bool UpdateMemberNominee(BankMemberNomineeModel bankMemberNomineeModel)
        {
            if (IsNull(bankMemberNomineeModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankMemberNomineeModel.BankMemberNomineeId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberNominee"));

            BankMemberNominee bankMemberNominee = bankMemberNomineeModel.FromModelToEntity<BankMemberNominee>();
            //Update BankMemberNominee
            bool isBankMemberNomineeUpdated = _bankMemberNomineeRepository.Update(bankMemberNominee);
            if (!isBankMemberNomineeUpdated)
            {
                bankMemberNomineeModel.HasError = true;
                bankMemberNomineeModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankMemberNomineeUpdated;
        }

        //Delete BankMemberNominee.
        public virtual bool DeleteMemberNominee(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankMemberNomineeId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankMemberNomineeId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankMemberNominee @BankMemberNomineeId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }
    }
}