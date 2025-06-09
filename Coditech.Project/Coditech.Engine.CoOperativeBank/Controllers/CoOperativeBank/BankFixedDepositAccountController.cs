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
    public class BankFixedDepositAccountController : BaseController
    {
        private readonly IBankFixedDepositAccountService _bankFixedDepositAccountService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankFixedDepositAccountController(ICoditechLogging coditechLogging, IBankFixedDepositAccountService bankFixedDepositAccountService)
        {
            _bankFixedDepositAccountService = bankFixedDepositAccountService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankFixedDepositAccount/GetBankFixedDepositAccountList")]
        [Produces(typeof(BankFixedDepositAccountListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankFixedDepositAccountList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankFixedDepositAccountListModel list = _bankFixedDepositAccountService.GetBankFixedDepositAccountList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankFixedDepositAccountListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankFixedDepositAccount/CreateBankFixedDepositAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankFixedDepositAccountResponse))]
        public virtual IActionResult CreateBankFixedDepositAccount([FromBody] BankFixedDepositAccountModel model)
        {
            try
            {
                BankFixedDepositAccountModel bankFixedDepositAccount = _bankFixedDepositAccountService.CreateBankFixedDepositAccount(model);
                return IsNotNull(bankFixedDepositAccount) ? CreateCreatedResponse(new BankFixedDepositAccountResponse { BankFixedDepositAccountModel = bankFixedDepositAccount }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankFixedDepositAccount/GetBankFixedDepositAccount")]
        [HttpGet]
        [Produces(typeof(BankFixedDepositAccountResponse))]
        public virtual IActionResult GetBankFixedDepositAccount(short bankFixedDepositAccountId)
        {
            try
            {
                BankFixedDepositAccountModel bankFixedDepositAccountModel = _bankFixedDepositAccountService.GetBankFixedDepositAccount(bankFixedDepositAccountId);
                return IsNotNull(bankFixedDepositAccountModel) ? CreateOKResponse(new BankFixedDepositAccountResponse { BankFixedDepositAccountModel = bankFixedDepositAccountModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankFixedDepositAccount/UpdateBankFixedDepositAccount")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankFixedDepositAccountResponse))]
        public virtual IActionResult UpdateBankFixedDepositAccount([FromBody] BankFixedDepositAccountModel model)
        {
            try
            {
                bool isUpdated = _bankFixedDepositAccountService.UpdateBankFixedDepositAccount(model);
                return isUpdated ? CreateOKResponse(new BankFixedDepositAccountResponse { BankFixedDepositAccountModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankFixedDepositAccount/DeleteBankFixedDepositAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankFixedDepositAccount([FromBody] ParameterModel bankFixedDepositAccountId)
        {
            try
            {
                bool deleted = _bankFixedDepositAccountService.DeleteBankFixedDepositAccount(bankFixedDepositAccountId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositAccount.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        #region BankFixedDepositClosure

        [Route("/BankFixedDepositAccount/CreateBankFixedDepositClosure")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankFixedDepositClosureResponse))]
        public virtual IActionResult CreateBankFixedDepositClosure([FromBody] BankFixedDepositClosureModel model)
        {
            try
            {
                BankFixedDepositClosureModel bankFixedDepositClosure = _bankFixedDepositAccountService.CreateBankFixedDepositClosure(model);
                return IsNotNull(bankFixedDepositClosure) ? CreateCreatedResponse(new BankFixedDepositClosureResponse { BankFixedDepositClosureModel = bankFixedDepositClosure }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositClosureResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositClosureResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankFixedDepositAccount/GetBankFixedDepositClosure")]
        [HttpGet]
        [Produces(typeof(BankFixedDepositClosureResponse))]
        public virtual IActionResult GetBankFixedDepositClosure(short bankFixedDepositAccountId)
        {
            try
            {
                BankFixedDepositClosureModel bankFixedDepositClosureModel = _bankFixedDepositAccountService.GetBankFixedDepositClosure(bankFixedDepositAccountId);
                return IsNotNull(bankFixedDepositClosureModel) ? CreateOKResponse(new BankFixedDepositClosureResponse { BankFixedDepositClosureModel = bankFixedDepositClosureModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositClosureResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositClosureResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankFixedDepositAccount/UpdateBankFixedDepositClosure")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankFixedDepositClosureResponse))]
        public virtual IActionResult UpdateBankFixedDepositClosure([FromBody] BankFixedDepositClosureModel model)
        {
            try
            {
                bool isUpdated = _bankFixedDepositAccountService.UpdateBankFixedDepositClosure(model);
                return isUpdated ? CreateOKResponse(new BankFixedDepositClosureResponse { BankFixedDepositClosureModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositClosureResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositClosure.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositClosureResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        #endregion

        #region BankFixedDepositInterestPostings

        [Route("/BankFixedDepositAccount/CreateBankFixedDepositInterestPostings")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankFixedDepositInterestPostingsResponse))]
        public virtual IActionResult CreateBankFixedDepositInterestPostings([FromBody] BankFixedDepositInterestPostingsModel model)
        {
            try
            {
                BankFixedDepositInterestPostingsModel bankFixedDepositInterestPostings = _bankFixedDepositAccountService.CreateBankFixedDepositInterestPostings(model);
                return IsNotNull(bankFixedDepositInterestPostings) ? CreateCreatedResponse(new BankFixedDepositInterestPostingsResponse { BankFixedDepositInterestPostingsModel = bankFixedDepositInterestPostings }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankFixedDepositAccount/GetBankFixedDepositInterestPostings")]
        [HttpGet]
        [Produces(typeof(BankFixedDepositInterestPostingsResponse))]
        public virtual IActionResult GetBankFixedDepositInterestPostings(short bankFixedDepositAccountId)
        {
            try
            {
                BankFixedDepositInterestPostingsModel bankFixedDepositInterestPostingsModel = _bankFixedDepositAccountService.GetBankFixedDepositInterestPostings(bankFixedDepositAccountId);
                return IsNotNull(bankFixedDepositInterestPostingsModel) ? CreateOKResponse(new BankFixedDepositInterestPostingsResponse { BankFixedDepositInterestPostingsModel = bankFixedDepositInterestPostingsModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankFixedDepositAccount/UpdateBankFixedDepositInterestPostings")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankFixedDepositInterestPostingsResponse))]
        public virtual IActionResult UpdateBankFixedDepositInterestPostings([FromBody] BankFixedDepositInterestPostingsModel model)
        {
            try
            {
                bool isUpdated = _bankFixedDepositAccountService.UpdateBankFixedDepositInterestPostings(model);
                return isUpdated ? CreateOKResponse(new BankFixedDepositInterestPostingsResponse { BankFixedDepositInterestPostingsModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankFixedDepositInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankFixedDepositInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        #endregion
    }
}
