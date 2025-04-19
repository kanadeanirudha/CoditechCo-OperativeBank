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
    public class BankSetupPropertyValuersAuthorityController : BaseController
    {
        private readonly IBankSetupPropertyValuersAuthorityService _bankSetupPropertyValuersAuthorityService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSetupPropertyValuersAuthorityController(ICoditechLogging coditechLogging, IBankSetupPropertyValuersAuthorityService bankSetupPropertyValuersAuthorityService)
        {
            _bankSetupPropertyValuersAuthorityService = bankSetupPropertyValuersAuthorityService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSetupPropertyValuersAuthority/GetPropertyValuersAuthorityList")]
        [Produces(typeof(BankSetupPropertyValuersAuthorityListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetPropertyValuersAuthorityList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSetupPropertyValuersAuthorityListModel list = _bankSetupPropertyValuersAuthorityService.GetPropertyValuersAuthorityList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSetupPropertyValuersAuthorityListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuersAuthority/CreatePropertyValuersAuthority")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSetupPropertyValuersAuthorityResponse))]
        public virtual IActionResult CreatePropertyValuersAuthority([FromBody] BankSetupPropertyValuersAuthorityModel model)
        {
            try
            {
                BankSetupPropertyValuersAuthorityModel BankSetupPropertyValuersAuthority = _bankSetupPropertyValuersAuthorityService.CreatePropertyValuersAuthority(model);
                return IsNotNull(BankSetupPropertyValuersAuthority) ? CreateCreatedResponse(new BankSetupPropertyValuersAuthorityResponse { BankSetupPropertyValuersAuthorityModel = BankSetupPropertyValuersAuthority }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuersAuthority/GetPropertyValuersAuthority")]
        [HttpGet]
        [Produces(typeof(BankSetupPropertyValuersAuthorityResponse))]
        public virtual IActionResult GetPropertyValuersAuthority(short bankSetupPropertyValuersAuthorityId)
        {
            try
            {
                BankSetupPropertyValuersAuthorityModel bankSetupPropertyValuersAuthorityModel = _bankSetupPropertyValuersAuthorityService.GetPropertyValuersAuthority(bankSetupPropertyValuersAuthorityId);
                return IsNotNull(bankSetupPropertyValuersAuthorityModel) ? CreateOKResponse(new BankSetupPropertyValuersAuthorityResponse { BankSetupPropertyValuersAuthorityModel = bankSetupPropertyValuersAuthorityModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuersAuthority/UpdatePropertyValuersAuthority")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSetupPropertyValuersAuthorityResponse))]
        public virtual IActionResult UpdatePropertyValuersAuthority([FromBody] BankSetupPropertyValuersAuthorityModel model)
        {
            try
            {
                bool isUpdated = _bankSetupPropertyValuersAuthorityService.UpdatePropertyValuersAuthority(model);
                return isUpdated ? CreateOKResponse(new BankSetupPropertyValuersAuthorityResponse { BankSetupPropertyValuersAuthorityModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersAuthorityResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuers/DeletePropertyValuersAuthority")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeletePropertyValuersAuthority([FromBody] ParameterModel BankSetupPropertyValuersAuthorityIds)
        {
            try
            {
                bool deleted = _bankSetupPropertyValuersAuthorityService.DeletePropertyValuersAuthority(BankSetupPropertyValuersAuthorityIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuersAuthority", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}