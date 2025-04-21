using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Common.Service;
using Coditech.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Specialized;
using System.Data;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Service
{
    public class BankSetupPropertyValuersService : BaseService, IBankSetupPropertyValuersService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankSetupPropertyValuers> _bankSetupPropertyValuersRepository;
        private readonly ICoditechRepository<GeneralPersonAddress> _generalPersonAddressRepository;
        public BankSetupPropertyValuersService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankSetupPropertyValuersRepository = new CoditechRepository<BankSetupPropertyValuers>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _generalPersonAddressRepository = new CoditechRepository<GeneralPersonAddress>(_serviceProvider.GetService<Coditech_Entities>());
        }
        public virtual BankSetupPropertyValuersListModel GetPropertyValuersList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankSetupPropertyValuersModel> objStoredProc = new CoditechViewRepository<BankSetupPropertyValuersModel>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankSetupPropertyValuersModel> BankSetupPropertyValuersList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetPropertyValuersList @WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 4, out pageListModel.TotalRowCount)?.ToList();
            BankSetupPropertyValuersListModel listModel = new BankSetupPropertyValuersListModel();

            listModel.BankSetupPropertyValuersList = BankSetupPropertyValuersList?.Count > 0 ? BankSetupPropertyValuersList : new List<BankSetupPropertyValuersModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }

        //Create BankSetupPropertyValuers.
        public virtual BankSetupPropertyValuersModel CreatePropertyValuers(BankSetupPropertyValuersModel bankSetupPropertyValuersModel)
        {
            if (IsNull(bankSetupPropertyValuersModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            if (IsNull(bankSetupPropertyValuersModel.GeneralPersonAddressId) || bankSetupPropertyValuersModel.GeneralPersonAddressId == 0)
            {
                GeneralPersonAddress addressData = new GeneralPersonAddress
                {                  
                    AddressTypeEnum = AddressTypeEnum.PermanentAddress.ToString(),
                    FirstName = bankSetupPropertyValuersModel.FirstName,
                    MiddleName = bankSetupPropertyValuersModel.MiddleName, 
                    LastName = bankSetupPropertyValuersModel.LastName,
                    AddressLine1 = bankSetupPropertyValuersModel.AddressLine1,
                    AddressLine2 = bankSetupPropertyValuersModel.AddressLine2,
                    GeneralCountryMasterId = bankSetupPropertyValuersModel.GeneralCountryMasterId,
                    GeneralRegionMasterId = bankSetupPropertyValuersModel.GeneralRegionMasterId,
                    GeneralCityMasterId = bankSetupPropertyValuersModel.GeneralCityMasterId,
                    Postalcode = bankSetupPropertyValuersModel.Postalcode,
                    PhoneNumber = bankSetupPropertyValuersModel.PhoneNumber,
                    MobileNumber = bankSetupPropertyValuersModel.MobileNumber,
                    EmailAddress = bankSetupPropertyValuersModel.EmailAddress,
                };
                _generalPersonAddressRepository.Insert(addressData);
                bankSetupPropertyValuersModel.GeneralPersonAddressId = addressData.GeneralPersonAddressId;
            }
            BankSetupPropertyValuers BankSetupPropertyValuers = bankSetupPropertyValuersModel.FromModelToEntity<BankSetupPropertyValuers>();
            //Create new BankSetupPropertyValuers and return it.
            BankSetupPropertyValuers BankSetupPropertyValuersData = _bankSetupPropertyValuersRepository.Insert(BankSetupPropertyValuers);
             if (BankSetupPropertyValuers?.BankSetupPropertyValuersId > 0)
             {
                bankSetupPropertyValuersModel.BankSetupPropertyValuersId = BankSetupPropertyValuersData.BankSetupPropertyValuersId;
             }
             else
             {
                bankSetupPropertyValuersModel.HasError = true;
                bankSetupPropertyValuersModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
             }
             return bankSetupPropertyValuersModel;
        }

        //Get BankSetupPropertyValuers by BankSetupPropertyValuers id.
        public virtual BankSetupPropertyValuersModel GetPropertyValuers(long generalPersonAddressId)
        {
            if (generalPersonAddressId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "GeneralPersonAddressId"));

            //Get the BankSetupPropertyValuers Details based on id.
            BankSetupPropertyValuers bankSetupPropertyValuers = _bankSetupPropertyValuersRepository.Table.Where(x => x.GeneralPersonAddressId == generalPersonAddressId).FirstOrDefault();
            BankSetupPropertyValuersModel bankSetupPropertyValuersModel = bankSetupPropertyValuers?.FromEntityToModel<BankSetupPropertyValuersModel>();
            GeneralPersonAddress personAddresses = _generalPersonAddressRepository.Table.Where(x => x.GeneralPersonAddressId == generalPersonAddressId)?.FirstOrDefault();
            if (personAddresses?.GeneralPersonAddressId > 0)
            {
                bankSetupPropertyValuersModel.GeneralPersonAddressId = personAddresses.GeneralPersonAddressId;
                bankSetupPropertyValuersModel.AddressTypeEnum = personAddresses.AddressTypeEnum;
                bankSetupPropertyValuersModel.FirstName = personAddresses.FirstName;
                bankSetupPropertyValuersModel.MiddleName = personAddresses.MiddleName;
                bankSetupPropertyValuersModel.LastName = personAddresses.LastName;
                bankSetupPropertyValuersModel.AddressLine1 = personAddresses.AddressLine1;
                bankSetupPropertyValuersModel.AddressLine2 = personAddresses.AddressLine2;
                bankSetupPropertyValuersModel.GeneralCountryMasterId = personAddresses.GeneralCountryMasterId;
                bankSetupPropertyValuersModel.GeneralRegionMasterId = personAddresses.GeneralRegionMasterId;
                bankSetupPropertyValuersModel.GeneralCityMasterId = personAddresses.GeneralCityMasterId;
                bankSetupPropertyValuersModel.Postalcode = personAddresses.Postalcode;
                bankSetupPropertyValuersModel.PhoneNumber = personAddresses.PhoneNumber;
                bankSetupPropertyValuersModel.MobileNumber = personAddresses.MobileNumber;
                bankSetupPropertyValuersModel.EmailAddress = personAddresses.EmailAddress;
            }            
            return bankSetupPropertyValuersModel;
        }

        //Update BankSetupPropertyValuers.
        public virtual bool UpdatePropertyValuers(BankSetupPropertyValuersModel bankSetupPropertyValuersModel)
        {
            if (IsNull(bankSetupPropertyValuersModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankSetupPropertyValuersModel.BankSetupPropertyValuersId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupPropertyValuersId"));

            BankSetupPropertyValuers bankSetupPropertyValuers = bankSetupPropertyValuersModel.FromModelToEntity<BankSetupPropertyValuers>();
            //Update BankSetupPropertyValuers
            bool isPropertyValuersUpdated = _bankSetupPropertyValuersRepository.Update(bankSetupPropertyValuers);
            if (bankSetupPropertyValuersModel.GeneralPersonAddressId > 0)
            {
                GeneralPersonAddress personAddresses = new GeneralPersonAddress
                {
                    GeneralPersonAddressId = bankSetupPropertyValuersModel.GeneralPersonAddressId,
                    AddressTypeEnum = bankSetupPropertyValuersModel.AddressTypeEnum,
                    FirstName = bankSetupPropertyValuersModel.FirstName,
                    MiddleName = bankSetupPropertyValuersModel.MiddleName,
                    LastName = bankSetupPropertyValuersModel.LastName,
                    AddressLine1 = bankSetupPropertyValuersModel.AddressLine1,
                    AddressLine2 = bankSetupPropertyValuersModel.AddressLine2,
                    GeneralCountryMasterId = bankSetupPropertyValuersModel.GeneralCountryMasterId,
                    GeneralRegionMasterId = bankSetupPropertyValuersModel.GeneralRegionMasterId,
                    GeneralCityMasterId = bankSetupPropertyValuersModel.GeneralCityMasterId,
                    Postalcode = bankSetupPropertyValuersModel.Postalcode,
                    PhoneNumber = bankSetupPropertyValuersModel.PhoneNumber,
                    MobileNumber = bankSetupPropertyValuersModel.MobileNumber,
                    EmailAddress = bankSetupPropertyValuersModel.EmailAddress
                };
                _generalPersonAddressRepository.Update(personAddresses);
            }
            if (!isPropertyValuersUpdated)
            {
                bankSetupPropertyValuersModel.HasError = true;
                bankSetupPropertyValuersModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isPropertyValuersUpdated;
        }

        //Delete BankSetupPropertyValuers.
        public virtual bool DeletePropertyValuers(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankSetupPropertyValuersId"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankSetupPropertyValuersId", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeletePropertyValuers @BankSetupPropertyValuersId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }
    }
}