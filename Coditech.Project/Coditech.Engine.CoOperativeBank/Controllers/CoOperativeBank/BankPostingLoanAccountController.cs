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
    public class BankPostingLoanAccountController : BaseController
    {
        private readonly IBankPostingLoanAccountService _bankPostingLoanAccountService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankPostingLoanAccountController(ICoditechLogging coditechLogging, IBankPostingLoanAccountService bankPostingLoanAccountService)
        {
            _bankPostingLoanAccountService = bankPostingLoanAccountService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankPostingLoanAccount/GetBankPostingLoanAccountList")]
        [Produces(typeof(BankPostingLoanAccountListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankPostingLoanAccountList(string centreCode,int bankMemberId,FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankPostingLoanAccountListModel list = _bankPostingLoanAccountService.GetBankPostingLoanAccountList(centreCode, bankMemberId, filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankPostingLoanAccountListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankPostingLoanAccount/CreatePostingLoanAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankPostingLoanAccountResponse))]
        public virtual IActionResult CreatePostingLoanAccount([FromBody] BankPostingLoanAccountModel model)
        {
            try
            {
                BankPostingLoanAccountModel bankPostingLoanAccountModel = _bankPostingLoanAccountService.CreatePostingLoanAccount(model);
                return IsNotNull(bankPostingLoanAccountModel) ? CreateCreatedResponse(new BankPostingLoanAccountResponse { BankPostingLoanAccountModel = bankPostingLoanAccountModel }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankPostingLoanAccount/GetPostingLoanAccount")]
        [HttpGet]
        [Produces(typeof(BankPostingLoanAccountResponse))]
        public virtual IActionResult GetPostingLoanAccount(int bankPostingLoanAccountId)
        {
            try
            {
                BankPostingLoanAccountModel bankPostingLoanAccountModel = _bankPostingLoanAccountService.GetPostingLoanAccount(bankPostingLoanAccountId);
                return IsNotNull(bankPostingLoanAccountModel) ? CreateOKResponse(new BankPostingLoanAccountResponse { BankPostingLoanAccountModel = bankPostingLoanAccountModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankPostingLoanAccount/UpdatePostingLoanAccount")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankPostingLoanAccountResponse))]
        public virtual IActionResult UpdatePostingLoanAccount([FromBody] BankPostingLoanAccountModel model)
        {
            try
            {
                bool isUpdated = _bankPostingLoanAccountService.UpdatePostingLoanAccount(model);
                return isUpdated ? CreateOKResponse(new BankPostingLoanAccountResponse { BankPostingLoanAccountModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankPostingLoanAccount/DeletePostingLoanAccount")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeletePostingLoanAccount([FromBody] ParameterModel BankPostingLoanAccountIds)
        {
            try
            {
                bool deleted = _bankPostingLoanAccountService.DeletePostingLoanAccount(BankPostingLoanAccountIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankPostingLoanAccount", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        #region BankLoanForeClosures

        [Route("/BankPostingLoanAccount/CreateBankLoanForeClosures")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankLoanForeClosuresResponse))]
        public virtual IActionResult CreateBankLoanForeClosures([FromBody] BankLoanForeClosuresModel model)
        {
            try
            {
                BankLoanForeClosuresModel bankLoanForeClosuresModel = _bankPostingLoanAccountService.CreateBankLoanForeClosures(model);
                return IsNotNull(bankLoanForeClosuresModel) ? CreateCreatedResponse(new BankLoanForeClosuresResponse { BankLoanForeClosuresModel = bankLoanForeClosuresModel }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanForeClosuresResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankLoanForeClosuresResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankPostingLoanAccount/GetBankLoanForeClosures")]
        [HttpGet]
        [Produces(typeof(BankLoanForeClosuresResponse))]
        public virtual IActionResult GetBankLoanForeClosures(int bankPostingLoanAccountId)
        {
            try
            {
                BankLoanForeClosuresModel bankLoanForeClosuresModel = _bankPostingLoanAccountService.GetBankLoanForeClosures(bankPostingLoanAccountId);
                return IsNotNull(bankLoanForeClosuresModel) ? CreateOKResponse(new BankLoanForeClosuresResponse { BankLoanForeClosuresModel = bankLoanForeClosuresModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanForeClosuresResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankLoanForeClosuresResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankPostingLoanAccount/UpdateBankLoanForeClosures")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankLoanForeClosuresResponse))]
        public virtual IActionResult UpdateBankLoanForeClosures([FromBody] BankLoanForeClosuresModel model)
        {
            try
            {
                bool isUpdated = _bankPostingLoanAccountService.UpdateBankLoanForeClosures(model);
                return isUpdated ? CreateOKResponse(new BankLoanForeClosuresResponse { BankLoanForeClosuresModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankLoanForeClosuresResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanForeClosures", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankLoanForeClosuresResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        #endregion

        [Route("/BankPostingLoanAccount/GetLoanRepayment")]
        [HttpGet]
        [Produces(typeof(BankLoanRepaymentResponse))]
        public virtual IActionResult GetLoanRepayment(int bankPostingLoanAccountId)
        {
            try
            {
                BankLoanRepaymentModel bankLoanRepaymentModel = _bankPostingLoanAccountService.GetLoanRepayment(bankPostingLoanAccountId);
                return IsNotNull(bankLoanRepaymentModel) ? CreateOKResponse(new BankLoanRepaymentResponse { BankLoanRepaymentModel = bankLoanRepaymentModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanRepayment", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanRepayment", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankPostingLoanAccount/UpdateLoanRepayment")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankLoanRepaymentResponse))]
        public virtual IActionResult UpdateLoanRepayment([FromBody] BankLoanRepaymentModel model)
        {
            try
            {
                bool isUpdated = _bankPostingLoanAccountService.UpdateLoanRepayment(model);
                return isUpdated ? CreateOKResponse(new BankLoanRepaymentResponse { BankLoanRepaymentModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanRepayment", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankLoanRepayment", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankPostingLoanAccountResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}