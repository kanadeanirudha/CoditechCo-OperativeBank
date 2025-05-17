using Coditech.API.Data;
using Coditech.API.Service;
using Coditech.Common.API;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.Engine.DBTM.Controllers
{
    public class BankProductController : BaseController
    {
        private readonly IBankProductService _bankProductService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankProductController(ICoditechLogging coditechLogging, IBankProductService bankProductService)
        {
            _bankProductService = bankProductService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankProduct/GetBankProductList")]
        [Produces(typeof(BankProductListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankProductList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankProductListModel list = _bankProductService.GetBankProductList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankProductListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankProduct/CreateBankProduct")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankProductResponse))]
        public virtual IActionResult CreateBankProduct([FromBody] BankProductModel model)
        {
            try
            {
                BankProductModel bankProduct = _bankProductService.CreateBankProduct(model);
                return IsNotNull(bankProduct) ? CreateCreatedResponse(new BankProductResponse { BankProductModel = bankProduct }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankProduct/GetBankProduct")]
        [HttpGet]
        [Produces(typeof(BankProductResponse))]
        public virtual IActionResult GetBankProduct(short bankProductId)
        {
            try
            {
                BankProductModel bankProductModel = _bankProductService.GetBankProduct(bankProductId);
                return IsNotNull(bankProductModel) ? CreateOKResponse(new BankProductResponse { BankProductModel = bankProductModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankProduct/UpdateBankProduct")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankProductResponse))]
        public virtual IActionResult UpdateBankProduct([FromBody] BankProductModel model)
        {
            try
            {
                bool isUpdated = _bankProductService.UpdateBankProduct(model);
                return isUpdated ? CreateOKResponse(new BankProductResponse { BankProductModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankProductResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankProduct/DeleteBankProduct")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankProduct([FromBody] ParameterModel bankProductId)
        {
            try
            {
                bool deleted = _bankProductService.DeleteBankProduct(bankProductId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankProduct.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankProduct/GetAccSetupGLList")]
        [HttpGet]
        [Produces(typeof(AccSetupGLResponse))]
        public virtual IActionResult GetAccSetupGLList(string DropdownType)
        {
            try
            {
                AccSetupGLListModel list = _bankProductService.GetAccSetupGLList(DropdownType);
                return IsNotNull(list) ? CreateOKResponse(new AccSetupGLListResponse { AccSetupGLList = list.AccSetupGLList }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.AccSetupGL.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new AccSetupGLListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.AccSetupGL.ToString(), TraceLevel.Error);
                return CreateInternalServerErrorResponse(new AccSetupGLListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
