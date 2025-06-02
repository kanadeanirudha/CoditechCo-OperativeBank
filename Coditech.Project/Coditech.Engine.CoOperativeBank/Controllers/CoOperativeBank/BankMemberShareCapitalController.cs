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

namespace Coditech.API.Controllers
{
    public class BankMemberShareCapitalController : BaseController
    {
        private readonly IBankMemberShareCapitalService _bankMemberShareCapitalService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankMemberShareCapitalController(ICoditechLogging coditechLogging, IBankMemberShareCapitalService bankMemberShareCapitalService)
        {
            _bankMemberShareCapitalService = bankMemberShareCapitalService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankMemberShareCapital/GetMemberShareCapitalList")]
        [Produces(typeof(BankMemberShareCapitalListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetMemberShareCapitalList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankMemberShareCapitalListModel list = _bankMemberShareCapitalService.GetMemberShareCapitalList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankMemberShareCapitalListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMemberShareCapital/CreateMemberShareCapital")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankMemberShareCapitalResponse))]
        public virtual IActionResult CreateMemberShareCapital([FromBody] BankMemberShareCapitalModel model)
        {
            try
            {
                BankMemberShareCapitalModel BankMemberShareCapital = _bankMemberShareCapitalService.CreateMemberShareCapital(model);
                return IsNotNull(BankMemberShareCapital) ? CreateCreatedResponse(new BankMemberShareCapitalResponse { BankMemberShareCapitalModel = BankMemberShareCapital }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMemberShareCapital/GetMemberShareCapital")]
        [HttpGet]
        [Produces(typeof(BankMemberShareCapitalResponse))]
        public virtual IActionResult GetMemberShareCapital(int bankMemberId)
        {
            try
            {
                BankMemberShareCapitalModel bankMemberShareCapitalModel = _bankMemberShareCapitalService.GetMemberShareCapital(bankMemberId);
                return IsNotNull(bankMemberShareCapitalModel) ? CreateOKResponse(new BankMemberShareCapitalResponse { BankMemberShareCapitalModel = bankMemberShareCapitalModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMemberShareCapital/UpdateMemberShareCapital")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankMemberShareCapitalResponse))]
        public virtual IActionResult UpdateMemberShareCapital([FromBody] BankMemberShareCapitalModel model)
        {
            try
            {
                bool isUpdated = _bankMemberShareCapitalService.UpdateMemberShareCapital(model);
                return isUpdated ? CreateOKResponse(new BankMemberShareCapitalResponse { BankMemberShareCapitalModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberShareCapitalResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMemberShareCapital/DeleteMemberShareCapital")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteMemberShareCapital([FromBody] ParameterModel BankMemberShareCapitalIds)
        {
            try
            {
                bool deleted = _bankMemberShareCapitalService.DeleteMemberShareCapital(BankMemberShareCapitalIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberShareCapital", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}