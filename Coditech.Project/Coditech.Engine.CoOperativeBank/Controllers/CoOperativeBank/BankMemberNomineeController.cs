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
    public class BankMemberNomineeController : BaseController
    {
        private readonly IBankMemberNomineeService _bankMemberNomineeService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankMemberNomineeController(ICoditechLogging coditechLogging, IBankMemberNomineeService bankMemberNomineeService)
        {
            _bankMemberNomineeService = bankMemberNomineeService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankMemberNominee/GetMemberNomineeList")]
        [Produces(typeof(BankMemberNomineeListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetMemberNomineeList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankMemberNomineeListModel list = _bankMemberNomineeService.GetMemberNomineeList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankMemberNomineeListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberNomineeListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberNomineeListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMemberNominee/CreateMemberNominee")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankMemberNomineeResponse))]
        public virtual IActionResult CreateMemberNominee([FromBody] BankMemberNomineeModel model)
        {
            try
            {
                BankMemberNomineeModel BankMemberNominee = _bankMemberNomineeService.CreateMemberNominee(model);
                return IsNotNull(BankMemberNominee) ? CreateCreatedResponse(new BankMemberNomineeResponse { BankMemberNomineeModel = BankMemberNominee }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        //[Route("/BankMemberNominee/GetMemberNominee")]
        //[HttpGet]
        //[Produces(typeof(BankMemberNomineeResponse))]
        //public virtual IActionResult GetBankMemberNominee(int bankMemberNomineeId)
        //{
        //    try
        //    {
        //        BankMemberNomineeModel bankMemberNomineeModel = _bankMemberNomineeService.GetMemberNominee(bankMemberNomineeId);
        //        return IsNotNull(bankMemberNomineeModel) ? CreateOKResponse(new BankMemberNomineeResponse { BankMemberNomineeModel = bankMemberNomineeModel }) : CreateNoContentResponse();
        //    }
        //    catch (CoditechException ex)
        //    {
        //        _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Warning);
        //        return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
        //    }
        //    catch (Exception ex)
        //    {
        //        _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Error);
        //        return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message });
        //    }
        //}

        [Route("/BankMemberNominee/UpdateMemberNominee")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankMemberNomineeResponse))]
        public virtual IActionResult UpdateMemberNominee([FromBody] BankMemberNomineeModel model)
        {
            try
            {
                bool isUpdated = _bankMemberNomineeService.UpdateMemberNominee(model);
                return isUpdated ? CreateOKResponse(new BankMemberNomineeResponse { BankMemberNomineeModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankMemberNominee/DeleteMemberNominee")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteMemberNominee([FromBody] ParameterModel BankMemberNomineeIds)
        {
            try
            {
                bool deleted = _bankMemberNomineeService.DeleteMemberNominee(BankMemberNomineeIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankMemberNominee.ToString(), TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankMemberNominee/GetMemberNominee")]
        [HttpGet]
        [Produces(typeof(BankMemberNomineeResponse))]
        public virtual IActionResult GetMemberNominee(int bankMemberId)
        {
            try
            {
                BankMemberNomineeModel bankMemberNomineeModel = _bankMemberNomineeService.GetMemberNominee(bankMemberId);
                return IsNotNull(bankMemberNomineeModel) ? CreateOKResponse(new BankMemberNomineeResponse { BankMemberNomineeModel = bankMemberNomineeModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNomineeModel", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankMemberNomineeModel", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankMemberNomineeResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}