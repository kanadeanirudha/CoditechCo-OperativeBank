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

namespace Coditech.API.Controllers
{
    public class BankSetupMortagePropertyTypeController : BaseController
    {
        private readonly IBankSetupMortagePropertyTypeService _bankSetupMortagePropertyTypeService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSetupMortagePropertyTypeController(ICoditechLogging coditechLogging, IBankSetupMortagePropertyTypeService bankSetupMortagePropertyTypeService)
        {
            _bankSetupMortagePropertyTypeService = bankSetupMortagePropertyTypeService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSetupMortagePropertyType/GetPropertyTypeList")]
        [Produces(typeof(BankSetupMortagePropertyTypeListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetPropertyTypeList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSetupMortagePropertyTypeListModel list = _bankSetupMortagePropertyTypeService.GetPropertyTypeList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSetupMortagePropertyTypeListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupMortagePropertyType/CreatePropertyType")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSetupMortagePropertyTypeResponse))]
        public virtual IActionResult CreatePropertyType([FromBody] BankSetupMortagePropertyTypeModel model)
        {
            try
            {
                BankSetupMortagePropertyTypeModel BankSetupMortagePropertyType = _bankSetupMortagePropertyTypeService.CreatePropertyType(model);
                return IsNotNull(BankSetupMortagePropertyType) ? CreateCreatedResponse(new BankSetupMortagePropertyTypeResponse { BankSetupMortagePropertyTypeModel = BankSetupMortagePropertyType }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupMortagePropertyType/GetPropertyType")]
        [HttpGet]
        [Produces(typeof(BankSetupMortagePropertyTypeResponse))]
        public virtual IActionResult GetPropertyType(short bankSetupMortagePropertyTypeId)
        {
            try
            {
                BankSetupMortagePropertyTypeModel bankSetupMortagePropertyTypeModel = _bankSetupMortagePropertyTypeService.GetPropertyType(bankSetupMortagePropertyTypeId);
                return IsNotNull(bankSetupMortagePropertyTypeModel) ? CreateOKResponse(new BankSetupMortagePropertyTypeResponse { BankSetupMortagePropertyTypeModel = bankSetupMortagePropertyTypeModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupMortagePropertyType/UpdatePropertyType")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSetupMortagePropertyTypeResponse))]
        public virtual IActionResult UpdatePropertyType([FromBody] BankSetupMortagePropertyTypeModel model)
        {
            try
            {
                bool isUpdated = _bankSetupMortagePropertyTypeService.UpdatePropertyType(model);
                return isUpdated ? CreateOKResponse(new BankSetupMortagePropertyTypeResponse { BankSetupMortagePropertyTypeModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex,"BankSetupMortagePropertyType", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupMortagePropertyTypeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupMortagePropertyType/DeletePropertyType")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeletePropertyType([FromBody] ParameterModel BankSetupMortagePropertyTypeIds)
        {
            try
            {
                bool deleted = _bankSetupMortagePropertyTypeService.DeletePropertyType(BankSetupMortagePropertyTypeIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupMortagePropertyType", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}