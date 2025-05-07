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
    public class BankInsurancePoliciesTypeController : BaseController
    {
        private readonly IBankInsurancePoliciesTypeService _bankInsurancePoliciesTypeService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankInsurancePoliciesTypeController(ICoditechLogging coditechLogging, IBankInsurancePoliciesTypeService bankInsurancePoliciesTypeService)
        {
            _bankInsurancePoliciesTypeService = bankInsurancePoliciesTypeService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankInsurancePoliciesType/GetBankInsurancePoliciesTypeList")]
        [Produces(typeof(BankInsurancePoliciesTypeListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankInsurancePoliciesTypeList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankInsurancePoliciesTypeListModel list = _bankInsurancePoliciesTypeService.GetBankInsurancePoliciesTypeList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankInsurancePoliciesTypeListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankInsurancePoliciesType/CreateBankInsurancePoliciesType")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankInsurancePoliciesTypeResponse))]
        public virtual IActionResult CreateBankInsurancePoliciesType([FromBody] BankInsurancePoliciesTypeModel model)
        {
            try
            {
                BankInsurancePoliciesTypeModel bankInsurancePoliciesType = _bankInsurancePoliciesTypeService.CreateBankInsurancePoliciesType(model);
                return IsNotNull(bankInsurancePoliciesType) ? CreateCreatedResponse(new BankInsurancePoliciesTypeResponse { BankInsurancePoliciesTypeModel = bankInsurancePoliciesType }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankInsurancePoliciesType/GetBankInsurancePoliciesType")]
        [HttpGet]
        [Produces(typeof(BankInsurancePoliciesTypeResponse))]
        public virtual IActionResult GetBankInsurancePoliciesType(short bankInsurancePoliciesTypeId)
        {
            try
            {
                BankInsurancePoliciesTypeModel bankInsurancePoliciesTypeModel = _bankInsurancePoliciesTypeService.GetBankInsurancePoliciesType(bankInsurancePoliciesTypeId);
                return IsNotNull(bankInsurancePoliciesTypeModel) ? CreateOKResponse(new BankInsurancePoliciesTypeResponse { BankInsurancePoliciesTypeModel = bankInsurancePoliciesTypeModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankInsurancePoliciesType/UpdateBankInsurancePoliciesType")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankInsurancePoliciesTypeResponse))]
        public virtual IActionResult UpdateBankInsurancePoliciesType([FromBody] BankInsurancePoliciesTypeModel model)
        {
            try
            {
                bool isUpdated = _bankInsurancePoliciesTypeService.UpdateBankInsurancePoliciesType(model);
                return isUpdated ? CreateOKResponse(new BankInsurancePoliciesTypeResponse { BankInsurancePoliciesTypeModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankInsurancePoliciesTypeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankInsurancePoliciesType/DeleteBankInsurancePoliciesType")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankInsurancePoliciesType([FromBody] ParameterModel bankInsurancePoliciesTypeId)
        {
            try
            {
                bool deleted = _bankInsurancePoliciesTypeService.DeleteBankInsurancePoliciesType(bankInsurancePoliciesTypeId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankInsurancePolicies.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
