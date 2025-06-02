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
    public class BankSavingAccountIntrestPostingsController : BaseController
    {
        private readonly IBankSavingAccountIntrestPostingsService _bankSavingAccountIntrestPostingsService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSavingAccountIntrestPostingsController(ICoditechLogging coditechLogging, IBankSavingAccountIntrestPostingsService bankSavingAccountIntrestPostingsService)
        {
            _bankSavingAccountIntrestPostingsService = bankSavingAccountIntrestPostingsService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSavingAccountIntrestPostings/GetBankSavingAccountIntrestPostingsList")]
        [Produces(typeof(BankSavingAccountIntrestPostingsListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankSavingAccountIntrestPostingsList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSavingAccountIntrestPostingsListModel list = _bankSavingAccountIntrestPostingsService.GetBankSavingAccountIntrestPostingsList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSavingAccountIntrestPostingsListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingAccountIntrestPostings/CreateBankSavingAccountIntrestPostings")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSavingAccountIntrestPostingsResponse))]
        public virtual IActionResult CreateBankSavingAccountIntrestPostings([FromBody] BankSavingAccountIntrestPostingsModel model)
        {
            try
            {
                BankSavingAccountIntrestPostingsModel bankSavingAccountIntrestPostings = _bankSavingAccountIntrestPostingsService.CreateBankSavingAccountIntrestPostings(model);
                return IsNotNull(bankSavingAccountIntrestPostings) ? CreateCreatedResponse(new BankSavingAccountIntrestPostingsResponse { BankSavingAccountIntrestPostingsModel = bankSavingAccountIntrestPostings }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingAccountIntrestPostings/GetBankSavingAccountIntrestPostings")]
        [HttpGet]
        [Produces(typeof(BankSavingAccountIntrestPostingsResponse))]
        public virtual IActionResult GetBankSavingAccountIntrestPostings(int bankSavingsAccountId)
        {
            try
            {
                BankSavingAccountIntrestPostingsModel bankSavingAccountIntrestPostingsModel = _bankSavingAccountIntrestPostingsService.GetBankSavingAccountIntrestPostings(bankSavingsAccountId);
                return IsNotNull(bankSavingAccountIntrestPostingsModel) ? CreateOKResponse(new BankSavingAccountIntrestPostingsResponse { BankSavingAccountIntrestPostingsModel = bankSavingAccountIntrestPostingsModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingAccountIntrestPostings/UpdateBankSavingAccountIntrestPostings")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSavingAccountIntrestPostingsResponse))]
        public virtual IActionResult UpdateBankSavingAccountIntrestPostings([FromBody] BankSavingAccountIntrestPostingsModel model)
        {
            try
            {
                bool isUpdated = _bankSavingAccountIntrestPostingsService.UpdateBankSavingAccountIntrestPostings(model);
                return isUpdated ? CreateOKResponse(new BankSavingAccountIntrestPostingsResponse { BankSavingAccountIntrestPostingsModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingAccountIntrestPostingsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingAccountIntrestPostings/DeleteBankSavingAccountIntrestPostings")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankSavingAccountIntrestPostings([FromBody] ParameterModel bankSavingAccountIntrestPostingsId)
        {
            try
            {
                bool deleted = _bankSavingAccountIntrestPostingsService.DeleteBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingAccountIntrestPostings.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
