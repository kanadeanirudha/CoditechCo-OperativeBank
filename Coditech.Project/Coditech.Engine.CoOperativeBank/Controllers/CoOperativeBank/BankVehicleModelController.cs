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
    public class BankVehicleModelController : BaseController
    {
        private readonly IBankVehicleModelService _bankVehicleModelService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankVehicleModelController(ICoditechLogging coditechLogging, IBankVehicleModelService bankVehicleModelService)
        {
            _bankVehicleModelService = bankVehicleModelService;
            _coditechLogging = coditechLogging;
        }

        [HttpGet]
        [Route("/BankVehicleModel/GetVehicleModelList")]
        [Produces(typeof(BankVehicleModelListResponse))]
        [TypeFilter(typeof(BindQueryFilter))]
        public virtual IActionResult GetVehicleModelList(FilterCollection filter, ExpandCollection expand, SortCollection sort, int pageIndex, int pageSize)
        {
            try
            {
                BankVehicleModelListModel list = _bankVehicleModelService.GetVehicleModelList(filter, sort.ToNameValueCollectionSort(), expand.ToNameValueCollectionExpands(), pageIndex, pageSize);
                string data = ApiHelper.ToJson(list);
                return !string.IsNullOrEmpty(data) ? CreateOKResponse<BankVehicleModelListResponse>(data) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankVehicleModelListResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankVehicleModelListResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankVehicleModel/CreateVehicleModel")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankVehicleModelResponse))]
        public virtual IActionResult CreateVehicleModel([FromBody] BankVehicleModelModel model)
        {
            try
            {
                BankVehicleModelModel BankVehicleModel = _bankVehicleModelService.CreateVehicleModel(model);
                return IsNotNull(BankVehicleModel) ? CreateCreatedResponse(new BankVehicleModelResponse { BankVehicleModelModel = BankVehicleModel }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankVehicleModelResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankVehicleModelResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankVehicleModel/GetVehicleModel")]
        [HttpGet]
        [Produces(typeof(BankVehicleModelResponse))]
        public virtual IActionResult GetVehicleModel(short bankVehicleModelId)
        {
            try
            {
                BankVehicleModelModel bankVehicleModelModel = _bankVehicleModelService.GetVehicleModel(bankVehicleModelId);
                return IsNotNull(bankVehicleModelModel) ? CreateOKResponse(new BankVehicleModelResponse { BankVehicleModelModel = bankVehicleModelModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankVehicleModelResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankVehicleModelResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankVehicleModel/UpdateVehicleModel")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankVehicleModelResponse))]
        public virtual IActionResult UpdateVehicleModel([FromBody] BankVehicleModelModel model)
        {
            try
            {
                bool isUpdated = _bankVehicleModelService.UpdateVehicleModel(model);
                return isUpdated ? CreateOKResponse(new BankVehicleModelResponse { BankVehicleModelModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankVehicleModelResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex,"BankVehicleModel", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new BankVehicleModelResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankVehicleModel/DeleteVehicleModel")]
        [HttpPost, ValidateModel]
        [Produces(typeof(TrueFalseResponse))]
        public virtual IActionResult DeleteVehicleModel([FromBody] ParameterModel BankVehicleModelIds)
        {
            try
            {
                bool deleted = _bankVehicleModelService.DeleteVehicleModel(BankVehicleModelIds);
                return CreateOKResponse(new TrueFalseResponse { IsSuccess = deleted });
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "BankVehicleModel", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new TrueFalseResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}