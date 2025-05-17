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
    public class BankProductService : IBankProductService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankProduct> _bankProductRepository;
        private readonly ICoditechRepository<AccSetupGL> _accSetupGLRepository;
        public BankProductService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankProductRepository = new CoditechRepository<BankProduct>(_serviceProvider.GetService<CoditechCustom_Entities>());
            _accSetupGLRepository = new CoditechRepository<AccSetupGL>(_serviceProvider.GetService<Coditech_Entities>());
        }
        public virtual BankProductListModel GetBankProductList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength)
        {
            string selectedCentreCode = filters?.Find(x => string.Equals(x.FilterName, FilterKeys.SelectedCentreCode, StringComparison.CurrentCultureIgnoreCase))?.FilterValue;
            filters.RemoveAll(x => x.FilterName == FilterKeys.SelectedCentreCode);

            //Bind the Filter, sorts & Paging details.
            PageListModel pageListModel = new PageListModel(filters, sorts, pagingStart, pagingLength);
            CoditechViewRepository<BankProductModel> objStoredProc = new CoditechViewRepository<BankProductModel>(_serviceProvider.GetService<CoditechCustom_Entities>());
            objStoredProc.SetParameter("@CentreCode", selectedCentreCode, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@WhereClause", pageListModel?.SPWhereClause, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@PageNo", pageListModel.PagingStart, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Rows", pageListModel.PagingLength, ParameterDirection.Input, DbType.Int32);
            objStoredProc.SetParameter("@Order_BY", pageListModel.OrderBy, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("@RowsCount", pageListModel.TotalRowCount, ParameterDirection.Output, DbType.Int32);
            List<BankProductModel> BankProductList = objStoredProc.ExecuteStoredProcedureList("Coditech_GetBankProductList @CentreCode,@WhereClause,@Rows,@PageNo,@Order_BY,@RowsCount OUT", 5, out pageListModel.TotalRowCount)?.ToList();
            BankProductListModel listModel = new BankProductListModel();

            listModel.BankProductList = BankProductList?.Count > 0 ? BankProductList : new List<BankProductModel>();
            listModel.BindPageListModel(pageListModel);
            return listModel;
        }
        //Create BankProduct.
        public virtual BankProductModel CreateBankProduct(BankProductModel bankProductModel)
        {
            if (IsNull(bankProductModel))
                throw new CoditechException(ErrorCodes.NullModel, GeneralResources.ModelNotNull);

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankProduct bankProduct = bankProductModel.FromModelToEntity<BankProduct>();

            //Create new BankProduct and return it.
            BankProduct bankProductData = _bankProductRepository.Insert(bankProduct);
            if (bankProductData?.BankProductId > 0)
            {
                bankProductModel.BankProductId = bankProductData.BankProductId;
            }
            else
            {
                bankProductModel.HasError = true;
                bankProductModel.ErrorMessage = GeneralResources.ErrorFailedToCreate;
            }
            return bankProductModel;
        }

        //Get BankProduct by bankProductId.
        public virtual BankProductModel GetBankProduct(short bankProductId)
        {
            if (bankProductId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankProductID"));

            //Get the BankFixedDepositAccount based on bankFixedDepositAccountId.
            BankProduct bankProduct = _bankProductRepository.Table.FirstOrDefault(x => x.BankProductId == bankProductId);
            BankProductModel bankProductModel = bankProduct?.FromEntityToModel<BankProductModel>();
            return bankProductModel;
        }

        //Update BankProduct.
        public virtual bool UpdateBankProduct(BankProductModel bankProductModel)
        {
            if (IsNull(bankProductModel))
                throw new CoditechException(ErrorCodes.InvalidData, GeneralResources.ModelNotNull);

            if (bankProductModel.BankProductId < 1)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankProductID"));

            //if (IsBankInsurancePoliciesTypeAlreadyExist(bankInsurancePoliciesTypeModel.InsurancePoliciesTypeCode, bankInsurancePoliciesTypeModel.BankInsurancePoliciesTypeId))
            //    throw new CoditechException(ErrorCodes.AlreadyExist, string.Format(GeneralResources.ErrorCodeExists, "Insurance Policies Code"));

            BankProduct bankProduct = bankProductModel.FromModelToEntity<BankProduct>();

            //Update BankProduct
            bool isBankProductUpdated = _bankProductRepository.Update(bankProduct);
            if (!isBankProductUpdated)
            {
                bankProductModel.HasError = true;
                bankProductModel.ErrorMessage = GeneralResources.UpdateErrorMessage;
            }
            return isBankProductUpdated;
        }

        //Delete BankProduct.
        public virtual bool DeleteBankProduct(ParameterModel parameterModel)
        {
            if (IsNull(parameterModel) || string.IsNullOrEmpty(parameterModel.Ids))
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "BankProductID"));

            CoditechViewRepository<View_ReturnBoolean> objStoredProc = new CoditechViewRepository<View_ReturnBoolean>(_serviceProvider.GetService<Coditech_Entities>());
            objStoredProc.SetParameter("BankProductID", parameterModel.Ids, ParameterDirection.Input, DbType.String);
            objStoredProc.SetParameter("Status", null, ParameterDirection.Output, DbType.Int32);
            int status = 0;
            objStoredProc.ExecuteStoredProcedureList("Coditech_DeleteBankProduct @BankProductId,  @Status OUT", 1, out status);

            return status == 1 ? true : false;
        }

        //Get filtered GL list based on dropdownType, system-generated, and group status
        public virtual AccSetupGLListModel GetAccSetupGLList(string dropdownType)
        {
            AccSetupGLListModel list = new AccSetupGLListModel();

            List<int> categoryIds = dropdownType switch
            {
                "GetAccSetupGL" => new List<int> { 1, 2, 5 },
                "InteresetPayableGLAccount" => new List<int> { 1 },
                "InteresetReceivableGLAccount" => new List<int> { 2 },
                _ => new List<int>() // Empty list for unknown dropdowns
            };

            if (categoryIds.Any())
            {
                list.AccSetupGLList = _accSetupGLRepository.Table
                    .Where(gl =>
                        categoryIds.Contains(gl.AccSetupCategoryId) &&
                        gl.IsSystemGenerated == true &&
                        gl.IsGroup == false)
                    .Select(gl => new AccSetupGLModel
                    {
                        AccSetupGLId = gl.AccSetupGLId,
                        GLCode = gl.GLCode,
                        GLName = gl.GLName,
                        // Map other properties if needed
                    })
                    .ToList();
            }
            else
            {
                list.AccSetupGLList = new List<AccSetupGLModel>();
            }

            return list;
        }




    }
}
