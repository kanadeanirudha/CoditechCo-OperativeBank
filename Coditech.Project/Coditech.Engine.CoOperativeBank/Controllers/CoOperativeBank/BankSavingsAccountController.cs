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
    public class BankSavingsAccountController : BaseController
    {
        private readonly IBankSavingsAccountService _bankSavingsAccountService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSavingsAccountController(ICoditechLogging coditechLogging, IBankSavingsAccountService bankSavingsAccountService)
        {
            _bankSavingsAccountService = bankSavingsAccountService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSavingsAccount/GetBankSavingsAccountList")]
        [Produces(typeof(BankSavingsAccountListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankSavingsAccountList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSavingsAccountListModel list = _bankSavingsAccountService.GetBankSavingsAccountList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSavingsAccountListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingsAccount/CreateBankSavingsAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSavingsAccountResponse))]
        public virtual IActionResult CreateBankSavingsAccount([FromBody] BankSavingsAccountModel model)
        {
            try
            {
                BankSavingsAccountModel bankSavingsAccount = _bankSavingsAccountService.CreateBankSavingsAccount(model);
                return IsNotNull(bankSavingsAccount) ? CreateCreatedResponse(new BankSavingsAccountResponse { BankSavingsAccountModel = bankSavingsAccount }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingsAccount/GetBankSavingsAccount")]
        [HttpGet]
        [Produces(typeof(BankSavingsAccountResponse))]
        public virtual IActionResult GetBankSavingsAccount(long bankSavingsAccountId)
        {
            try
            {
                BankSavingsAccountModel bankSavingsAccountModel = _bankSavingsAccountService.GetBankSavingsAccount(bankSavingsAccountId);
                return IsNotNull(bankSavingsAccountModel) ? CreateOKResponse(new BankSavingsAccountResponse { BankSavingsAccountModel = bankSavingsAccountModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingsAccount/UpdateBankSavingsAccount")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSavingsAccountResponse))]
        public virtual IActionResult UpdateBankSavingsAccount([FromBody] BankSavingsAccountModel model)
        {
            try
            {
                bool isUpdated = _bankSavingsAccountService.UpdateBankSavingsAccount(model);
                return isUpdated ? CreateOKResponse(new BankSavingsAccountResponse { BankSavingsAccountModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingsAccount/DeleteBankSavingsAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankSavingsAccount([FromBody] ParameterModel bankSavingsAccountId)
        {
            try
            {
                bool deleted = _bankSavingsAccountService.DeleteBankSavingsAccount(bankSavingsAccountId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingsAccount/CreateBankSavingsAccountClosures")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSavingsAccountClosuresResponse))]
        public virtual IActionResult CreateBankSavingsAccountClosures([FromBody] BankSavingsAccountClosuresModel model)
        {
            try
            {
                BankSavingsAccountClosuresModel bankSavingsAccountClosures = _bankSavingsAccountService.CreateBankSavingsAccountClosures(model);
                return IsNotNull(bankSavingsAccountClosures) ? CreateCreatedResponse(new BankSavingsAccountClosuresResponse { BankSavingsAccountClosuresModel = bankSavingsAccountClosures }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountClosuresResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountClosuresResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingsAccount/GetBankSavingsAccountClosures")]
        [HttpGet]
        [Produces(typeof(BankSavingsAccountClosuresResponse))]
        public virtual IActionResult GetBankSavingsAccountClosures(long bankSavingsAccountId)
        {
            try
            {
                BankSavingsAccountClosuresModel bankSavingsAccountClosuresModel = _bankSavingsAccountService.GetBankSavingsAccountClosures(bankSavingsAccountId);
                return IsNotNull(bankSavingsAccountClosuresModel) ? CreateOKResponse(new BankSavingsAccountClosuresResponse() { BankSavingsAccountClosuresModel = bankSavingsAccountClosuresModel }) : NotFound();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountClosuresResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankSavingsAccountClosuresResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingsAccount/UpdateBankSavingsAccountClosures")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSavingsAccountClosuresResponse))]
        public virtual IActionResult UpdateBankSavingsAccountClosures([FromBody] BankSavingsAccountClosuresModel model)
        {
            try
            {
                bool isUpdated = _bankSavingsAccountService.UpdateBankSavingsAccountClosures(model);
                return isUpdated ? CreateOKResponse(new BankSavingsAccountClosuresResponse { BankSavingsAccountClosuresModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Warning); ;
                return CreateInternalServerErrorResponse(new BankSavingsAccountClosuresResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountClosures.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountClosuresResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

    }
}
