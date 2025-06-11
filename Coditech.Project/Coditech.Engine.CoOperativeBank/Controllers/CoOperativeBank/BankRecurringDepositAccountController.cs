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
    public class BankRecurringDepositAccountController : BaseController
    {
        private readonly IBankRecurringDepositAccountService _bankRecurringDepositAccountService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankRecurringDepositAccountController(ICoditechLogging coditechLogging, IBankRecurringDepositAccountService bankRecurringDepositAccountService)
        {
            _bankRecurringDepositAccountService = bankRecurringDepositAccountService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankRecurringDepositAccount/GetBankRecurringDepositAccountList")]
        [Produces(typeof(BankRecurringDepositAccountListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankRecurringDepositAccountList(string centreCode,FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankRecurringDepositAccountListModel list = _bankRecurringDepositAccountService.GetBankRecurringDepositAccountList(centreCode,filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankRecurringDepositAccountListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankRecurringDepositAccount/CreateBankRecurringDepositAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankRecurringDepositAccountResponse))]
        public virtual IActionResult CreateBankRecurringDepositAccount([FromBody] BankRecurringDepositAccountModel model)
        {
            try
            {
                BankRecurringDepositAccountModel bankRecurringDepositAccount = _bankRecurringDepositAccountService.CreateBankRecurringDepositAccount(model);
                return IsNotNull(bankRecurringDepositAccount) ? CreateCreatedResponse(new BankRecurringDepositAccountResponse { BankRecurringDepositAccountModel = bankRecurringDepositAccount }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankRecurringDepositAccount/GetBankRecurringDepositAccount")]
        [HttpGet]
        [Produces(typeof(BankRecurringDepositAccountResponse))]
        public virtual IActionResult GetBankRecurringDepositAccount(int bankRecurringDepositAccountId)
        {
            try
            {
                BankRecurringDepositAccountModel bankRecurringDepositAccountModel = _bankRecurringDepositAccountService.GetBankRecurringDepositAccount(bankRecurringDepositAccountId);
                return IsNotNull(bankRecurringDepositAccountModel) ? CreateOKResponse(new BankRecurringDepositAccountResponse { BankRecurringDepositAccountModel = bankRecurringDepositAccountModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankRecurringDepositAccount/UpdateBankRecurringDepositAccount")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankRecurringDepositAccountResponse))]
        public virtual IActionResult UpdateBankRecurringDepositAccount([FromBody] BankRecurringDepositAccountModel model)
        {
            try
            {
                bool isUpdated = _bankRecurringDepositAccountService.UpdateBankRecurringDepositAccount(model);
                return isUpdated ? CreateOKResponse(new BankRecurringDepositAccountResponse { BankRecurringDepositAccountModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankRecurringDepositAccount/DeleteBankRecurringDepositAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankRecurringDepositAccount([FromBody] ParameterModel bankRecurringDepositAccountId)
        {
            try
            {
                bool deleted = _bankRecurringDepositAccountService.DeleteBankRecurringDepositAccount(bankRecurringDepositAccountId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        #region  BankRecurringDepositInterestPosting

        [Route("/BankRecurringDepositAccount/CreateBankRecurringDepositInterestPosting")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankRecurringDepositInterestPostingResponse))]
        public virtual IActionResult CreateBankRecurringDepositInterestPosting([FromBody] BankRecurringDepositInterestPostingModel model)
        {
            try
            {
                BankRecurringDepositInterestPostingModel bankRecurringDepositInterestPosting = _bankRecurringDepositAccountService.CreateBankRecurringDepositInterestPosting(model);
                return IsNotNull(bankRecurringDepositInterestPosting) ? CreateCreatedResponse(new BankRecurringDepositInterestPostingResponse { BankRecurringDepositInterestPostingModel = bankRecurringDepositInterestPosting }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositInterestPosting.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositInterestPostingResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositInterestPosting.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositInterestPostingResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankRecurringDepositAccount/GetBankRecurringDepositInterestPosting")]
        [HttpGet]
        [Produces(typeof(BankRecurringDepositInterestPostingResponse))]
        public virtual IActionResult GetBankRecurringDepositInterestPosting(int bankRecurringDepositAccountId)
        {
            try
            {
                BankRecurringDepositInterestPostingModel bankRecurringDepositInterestPostingModel = _bankRecurringDepositAccountService.GetBankRecurringDepositInterestPosting(bankRecurringDepositAccountId);
                return IsNotNull(bankRecurringDepositInterestPostingModel) ? CreateOKResponse(new BankRecurringDepositInterestPostingResponse { BankRecurringDepositInterestPostingModel = bankRecurringDepositInterestPostingModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositInterestPosting.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositInterestPostingResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositInterestPosting.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositInterestPostingResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankRecurringDepositAccount/UpdateBankRecurringDepositInterestPosting")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankRecurringDepositInterestPostingResponse))]
        public virtual IActionResult UpdateBankRecurringDepositInterestPosting([FromBody] BankRecurringDepositInterestPostingModel model)
        {
            try
            {
                bool isUpdated = _bankRecurringDepositAccountService.UpdateBankRecurringDepositInterestPosting(model);
                return isUpdated ? CreateOKResponse(new BankRecurringDepositInterestPostingResponse { BankRecurringDepositInterestPostingModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositInterestPosting.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositInterestPostingResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositInterestPosting.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositInterestPostingResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        #endregion
    }
}
