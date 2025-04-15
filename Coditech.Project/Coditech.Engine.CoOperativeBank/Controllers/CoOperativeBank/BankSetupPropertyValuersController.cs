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
    public class BankSetupPropertyValuersController : BaseController
    {
        private readonly IBankSetupPropertyValuersService _bankSetupPropertyValuersService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSetupPropertyValuersController(ICoditechLogging coditechLogging, IBankSetupPropertyValuersService bankSetupPropertyValuersService)
        {
            _bankSetupPropertyValuersService = bankSetupPropertyValuersService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSetupPropertyValuers/GetPropertyValuersList")]
        [Produces(typeof(BankSetupPropertyValuersListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetPropertyValuersList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSetupPropertyValuersListModel list = _bankSetupPropertyValuersService.GetPropertyValuersList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSetupPropertyValuersListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuers/CreatePropertyValuers")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSetupPropertyValuersResponse))]
        public virtual IActionResult CreatePropertyValuers([FromBody] BankSetupPropertyValuersModel model)
        {
            try
            {
                BankSetupPropertyValuersModel BankSetupPropertyValuers = _bankSetupPropertyValuersService.CreatePropertyValuers(model);
                return IsNotNull(BankSetupPropertyValuers) ? CreateCreatedResponse(new BankSetupPropertyValuersResponse { BankSetupPropertyValuersModel = BankSetupPropertyValuers }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuers/GetPropertyValuers")]
        [HttpGet]
        [Produces(typeof(BankSetupPropertyValuersResponse))]
        public virtual IActionResult GetPropertyValuers(short bankSetupPropertyValuersId)
        {
            try
            {
                BankSetupPropertyValuersModel bankSetupPropertyValuersModel = _bankSetupPropertyValuersService.GetPropertyValuers(bankSetupPropertyValuersId);
                return IsNotNull(bankSetupPropertyValuersModel) ? CreateOKResponse(new BankSetupPropertyValuersResponse { BankSetupPropertyValuersModel = bankSetupPropertyValuersModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuers/UpdatePropertyValuers")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSetupPropertyValuersResponse))]
        public virtual IActionResult UpdatePropertyValuers([FromBody] BankSetupPropertyValuersModel model)
        {
            try
            {
                bool isUpdated = _bankSetupPropertyValuersService.UpdatePropertyValuers(model);
                return isUpdated ? CreateOKResponse(new BankSetupPropertyValuersResponse { BankSetupPropertyValuersModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSetupPropertyValuersResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupPropertyValuers/DeletePropertyValuers")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeletePropertyValuers([FromBody] ParameterModel BankSetupPropertyValuersIds)
        {
            try
            {
                bool deleted = _bankSetupPropertyValuersService.DeletePropertyValuers(BankSetupPropertyValuersIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankSetupPropertyValuers", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}