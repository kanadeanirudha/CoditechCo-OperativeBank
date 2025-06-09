using Coditech.API.Service;
using Coditech.Common.API;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.Engine.DBTM.Controllers
{
    public class BankLoanScheduleController : BaseController
    {
        private readonly IBankLoanScheduleService _bankLoanScheduleService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankLoanScheduleController(ICoditechLogging coditechLogging, IBankLoanScheduleService bankLoanScheduleService)
        {
            _bankLoanScheduleService = bankLoanScheduleService;
            _coditechLogging = coditechLogging;
        }

        [Route("/BankLoanSchedule/CreateBankLoanSchedule")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankLoanScheduleResponse))]
        public virtual IActionResult CreateBankLoanSchedule([FromBody] BankLoanScheduleModel model)
        {
            try
            {
                BankLoanScheduleModel bankLoanSchedule = _bankLoanScheduleService.CreateBankLoanSchedule(model);
                return IsNotNull(bankLoanSchedule) ? CreateCreatedResponse(new BankLoanScheduleResponse { BankLoanScheduleModel = bankLoanSchedule }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanScheduleResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanScheduleResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankLoanSchedule/GetBankLoanSchedule")]
        [HttpGet]
        [Produces(typeof(BankLoanScheduleResponse))]
        public virtual IActionResult GetBankLoanSchedule(int bankPostingLoanAccountId)
        {
            try
            {
                BankLoanScheduleModel bankLoanScheduleModel = _bankLoanScheduleService.GetBankLoanSchedule(bankPostingLoanAccountId);
                return IsNotNull(bankLoanScheduleModel) ? CreateOKResponse(new BankLoanScheduleResponse { BankLoanScheduleModel = bankLoanScheduleModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanScheduleResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanScheduleResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankLoanSchedule/UpdateBankLoanSchedule")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankLoanScheduleResponse))]
        public virtual IActionResult UpdateBankLoanSchedule([FromBody] BankLoanScheduleModel model)
        {
            try
            {
                bool isUpdated = _bankLoanScheduleService.UpdateBankLoanSchedule(model);
                return isUpdated ? CreateOKResponse(new BankLoanScheduleResponse { BankLoanScheduleModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanScheduleResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankLoanSchedule.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanScheduleResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
