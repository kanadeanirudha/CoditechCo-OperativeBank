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
    public class BankSetupDivisionController : BaseController
    {
        private readonly IBankSetupDivisionService _bankSetupDivisionService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSetupDivisionController(ICoditechLogging coditechLogging, IBankSetupDivisionService bankSetupDivisionService)
        {
            _bankSetupDivisionService = bankSetupDivisionService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSetupDivision/GetBankSetupDivisionList")]
        [Produces(typeof(BankSetupDivisionListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankSetupDivisionList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSetupDivisionListModel list = _bankSetupDivisionService.GetBankSetupDivisionList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSetupDivisionListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupDivision/CreateBankSetupDivision")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSetupDivisionResponse))]
        public virtual IActionResult CreateBankSetupDivision([FromBody] BankSetupDivisionModel model)
        {
            try
            {
                BankSetupDivisionModel bankSetupDivision = _bankSetupDivisionService.CreateBankSetupDivision(model);
                return IsNotNull(bankSetupDivision) ? CreateCreatedResponse(new BankSetupDivisionResponse { BankSetupDivisionModel = bankSetupDivision }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupDivision/GetBankSetupDivision")]
        [HttpGet]
        [Produces(typeof(BankSetupDivisionResponse))]
        public virtual IActionResult GetBankSetupDivision(short bankSetupDivisionId)
        {
            try
            {
                BankSetupDivisionModel bankSetupDivisionModel = _bankSetupDivisionService.GetBankSetupDivision(bankSetupDivisionId);
                return IsNotNull(bankSetupDivisionModel) ? CreateOKResponse(new BankSetupDivisionResponse { BankSetupDivisionModel = bankSetupDivisionModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSetupDivision/UpdateBankSetupDivision")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSetupDivisionResponse))]
        public virtual IActionResult UpdateBankSetupDivision([FromBody] BankSetupDivisionModel model)
        {
            try
            {
                bool isUpdated = _bankSetupDivisionService.UpdateBankSetupDivision(model);
                return isUpdated ? CreateOKResponse(new BankSetupDivisionResponse { BankSetupDivisionModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupDivisionResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSetupDivision/DeleteBankSetupDivision")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankSetupDivision([FromBody] ParameterModel bankSetupDivisionId)
        {
            try
            {
                bool deleted = _bankSetupDivisionService.DeleteBankSetupDivision(bankSetupDivisionId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupDivision.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
