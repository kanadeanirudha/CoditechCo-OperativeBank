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
    public class BankMemberController : BaseController
    {
        private readonly IBankMemberService _bankMemberService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankMemberController(ICoditechLogging coditechLogging, IBankMemberService bankMemberService)
        {
            _bankMemberService = bankMemberService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankMember/GetBankMemberList")]
        [Produces(typeof(BankMemberListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankMemberList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankMemberListModel list = _bankMemberService.GetBankMemberList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankMemberListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        
        [Route("/BankMember/GetMemberOtherDetail")]
        [HttpGet]
        [Produces(typeof(BankMemberResponse))]
        public virtual IActionResult GetMemberOtherDetail(int bankMemberId)
        {
            try
            {
                BankMemberModel bankMemberModel = _bankMemberService.GetMemberOtherDetail(bankMemberId);
                return IsNotNull(bankMemberModel) ? CreateOKResponse(new BankMemberResponse { BankMemberModel = bankMemberModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMember/UpdateMemberOtherDetail")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankMemberResponse))]
        public virtual IActionResult UpdateMemberOtherDetail([FromBody] BankMemberModel model)
        {
            try
            {
                bool isUpdated = _bankMemberService.UpdateMemberOtherDetail(model);
                return isUpdated ? CreateOKResponse(new BankMemberResponse { BankMemberModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMember/DeleteBankMember")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankMember([FromBody] ParameterModel BankMemberIds)
        {
            try
            {
                bool deleted = _bankMemberService.DeleteBankMember(BankMemberIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMember", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}