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
    public class BankSavingAccountInterestPostingsController : BaseController
    {
        private readonly IBankSavingAccountInterestPostingsService _bankSavingAccountInterestPostingsService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSavingAccountInterestPostingsController(ICoditechLogging coditechLogging, IBankSavingAccountInterestPostingsService bankSavingAccountInterestPostingsService)
        {
            _bankSavingAccountInterestPostingsService = bankSavingAccountInterestPostingsService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSavingAccountInterestPostings/GetBankSavingAccountInterestPostingsList")]
        [Produces(typeof(BankSavingAccountInterestPostingsListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankSavingAccountInterestPostingsList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSavingAccountInterestPostingsListModel list = _bankSavingAccountInterestPostingsService.GetBankSavingAccountInterestPostingsList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSavingAccountInterestPostingsListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingAccountInterestPostings/CreateBankSavingAccountInterestPostings")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSavingAccountInterestPostingsResponse))]
        public virtual IActionResult CreateBankSavingAccountInterestPostings([FromBody] BankSavingAccountInterestPostingsModel model)
        {
            try
            {
                BankSavingAccountInterestPostingsModel bankSavingAccountInterestPostings = _bankSavingAccountInterestPostingsService.CreateBankSavingAccountInterestPostings(model);
                return IsNotNull(bankSavingAccountInterestPostings) ? CreateCreatedResponse(new BankSavingAccountInterestPostingsResponse { BankSavingAccountInterestPostingsModel = bankSavingAccountInterestPostings }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingAccountInterestPostings/GetBankSavingAccountInterestPostings")]
        [HttpGet]
        [Produces(typeof(BankSavingAccountInterestPostingsResponse))]
        public virtual IActionResult GetBankSavingAccountInterestPostings(int bankSavingsAccountId)
        {
            try
            {
                BankSavingAccountInterestPostingsModel bankSavingAccountInterestPostingsModel = _bankSavingAccountInterestPostingsService.GetBankSavingAccountInterestPostings(bankSavingsAccountId);
                return IsNotNull(bankSavingAccountInterestPostingsModel) ? CreateOKResponse(new BankSavingAccountInterestPostingsResponse { BankSavingAccountInterestPostingsModel = bankSavingAccountInterestPostingsModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingAccountInterestPostings/UpdateBankSavingAccountInterestPostings")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSavingAccountInterestPostingsResponse))]
        public virtual IActionResult UpdateBankSavingAccountInterestPostings([FromBody] BankSavingAccountInterestPostingsModel model)
        {
            try
            {
                bool isUpdated = _bankSavingAccountInterestPostingsService.UpdateBankSavingAccountInterestPostings(model);
                return isUpdated ? CreateOKResponse(new BankSavingAccountInterestPostingsResponse { BankSavingAccountInterestPostingsModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountInterestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingAccountInterestPostings/DeleteBankSavingAccountInterestPostings")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankSavingAccountInterestPostings([FromBody] ParameterModel bankSavingAccountInterestPostingsId)
        {
            try
            {
                bool deleted = _bankSavingAccountInterestPostingsService.DeleteBankSavingAccountInterestPostings(bankSavingAccountInterestPostingsId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountInterestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
