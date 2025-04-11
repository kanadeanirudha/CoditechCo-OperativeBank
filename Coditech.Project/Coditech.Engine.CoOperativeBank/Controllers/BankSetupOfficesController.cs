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
    public class BankSetupOfficesController : BaseController
    {
        private readonly IBankSetupOfficesService _bankSetupOfficesService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSetupOfficesController(ICoditechLogging coditechLogging, IBankSetupOfficesService bankSetupOfficesService)
        {
            _bankSetupOfficesService = bankSetupOfficesService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankSetupOffices/GetBankSetupOfficesList")]
        [Produces(typeof(BankSetupOfficesListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetBankSetupOfficesList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankSetupOfficesListModel list = _bankSetupOfficesService.GetBankSetupOfficesList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankSetupOfficesListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupOffices/CreateBankSetupOffices")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSetupOfficesResponse))]
        public virtual IActionResult CreateBankSetupOffices([FromBody] BankSetupOfficesModel model)
        {
            try
            {
                BankSetupOfficesModel bankSetupOffices = _bankSetupOfficesService.CreateBankSetupOffices(model);
                return IsNotNull(bankSetupOffices) ? CreateCreatedResponse(new BankSetupOfficesResponse { BankSetupOfficesModel = bankSetupOffices }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSetupOffices/GetBankSetupOffices")]
        [HttpGet]
        [Produces(typeof(BankSetupOfficesResponse))]
        public virtual IActionResult GetBankSetupOffices(short bankSetupOfficeId)
        {
            try
            {
                BankSetupOfficesModel bankSetupOfficesModel = _bankSetupOfficesService.GetBankSetupOffices(bankSetupOfficeId);
                return IsNotNull(bankSetupOfficesModel) ? CreateOKResponse(new BankSetupOfficesResponse { BankSetupOfficesModel = bankSetupOfficesModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSetupOffices/UpdateBankSetupOffices")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSetupOfficesResponse))]
        public virtual IActionResult UpdateBankSetupOffices([FromBody] BankSetupOfficesModel model)
        {
            try
            {
                bool isUpdated = _bankSetupOfficesService.UpdateBankSetupOffices(model);
                return isUpdated ? CreateOKResponse(new BankSetupOfficesResponse { BankSetupOfficesModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSetupOfficesResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSetupOffices/DeleteBankSetupOffices")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteBankSetupOffices([FromBody] ParameterModel bankSetupOfficeId)
        {
            try
            {
                bool deleted = _bankSetupOfficesService.DeleteBankSetupOffices(bankSetupOfficeId);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSetupOffices.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
