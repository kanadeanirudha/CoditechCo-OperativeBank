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
        public virtual IActionResult GetBankRecurringDepositAccountList(string centreCode, FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankRecurringDepositAccountListModel list = _bankRecurringDepositAccountService.GetBankRecurringDepositAccountList(centreCode, filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
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
        #region BankRecurringDepositClosure
        [Route("/BankRecurringDepositAccount/CreateBankRecurringDepositClosure")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankRecurringDepositClosureResponse))]
        public virtual IActionResult CreateBankRecurringDepositClosure([FromBody] BankRecurringDepositClosureModel model)
        {
            try
            {
                BankRecurringDepositClosureModel bankRecurringDepositClosure = _bankRecurringDepositAccountService.CreateBankRecurringDepositClosure(model);
                return IsNotNull(bankRecurringDepositClosure) ? CreateCreatedResponse(new BankRecurringDepositClosureResponse { BankRecurringDepositClosureModel = bankRecurringDepositClosure }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositClosureResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositClosureResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankRecurringDepositAccount/GetBankRecurringDepositClosure")]
        [HttpGet]
        [Produces(typeof(BankRecurringDepositClosureResponse))]
        public virtual IActionResult GetBankRecurringDepositClosure(int bankRecurringDepositAccountId)
        {
            try
            {
                BankRecurringDepositClosureModel bankRecurringDepositClosureModel = _bankRecurringDepositAccountService.GetBankRecurringDepositClosure(bankRecurringDepositAccountId);
                return IsNotNull(bankRecurringDepositClosureModel) ? CreateOKResponse(new BankRecurringDepositClosureResponse { BankRecurringDepositClosureModel = bankRecurringDepositClosureModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositClosureResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositClosureResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankRecurringDepositAccount/UpdateBankRecurringDepositClosure")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankRecurringDepositClosureResponse))]
        public virtual IActionResult UpdateBankRecurringDepositClosure([FromBody] BankRecurringDepositClosureModel model)
        {
            try
            {
                bool isUpdated = _bankRecurringDepositAccountService.UpdateBankRecurringDepositClosure(model);
                return isUpdated ? CreateOKResponse(new BankRecurringDepositClosureResponse { BankRecurringDepositClosureModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositClosureResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankRecurringDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankRecurringDepositClosureResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        #endregion
    }
}
