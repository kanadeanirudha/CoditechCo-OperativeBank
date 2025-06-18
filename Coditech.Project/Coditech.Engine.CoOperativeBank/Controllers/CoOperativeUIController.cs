using Coditech.API.Service;
using Coditech.Common.API;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Logger;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.API.Controllers
{

    public class CoOperativeUIController : BaseController
    {

        private readonly ICoOperativeUIService _coOperativeUIService;
        protected readonly ICoditechLogging _coditechLogging;
        public CoOperativeUIController(ICoditechLogging coditechLogging, ICoOperativeUIService coOperativeUIService)
        {
            _coOperativeUIService = coOperativeUIService;
            _coditechLogging = coditechLogging;
        }

        [Route("/CoOperativeUIController/GetCoOperativeUIDetails")]
        [HttpGet]
        [Produces(typeof(CoOperativeUIResponse))]
        public virtual IActionResult GetCoOperativeUIDetails(int selectedBalanceSheeetId)
        {
            try
            {
                CoOperativeUIModel coOperativeUIModel = _coOperativeUIService.GetCoOperativeUIDetails(selectedBalanceSheeetId);
                return IsNotNull(coOperativeUIModel) ? CreateOKResponse(new CoOperativeUIResponse { CoOperativeUIModel = coOperativeUIModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "CoOperativeUI", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new CoOperativeUIResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "CoOperativeUI", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new CoOperativeUIResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/CoOperativeUIController/GetCoOperativeUI")]
        [HttpGet]
        [Produces(typeof(CoOperativeUIResponse))]
        public virtual IActionResult GetCoOperativeUI(int bankMemberId, int navbarEnumId)
        {
            try
            {
                CoOperativeUIModel coOperativeUIModel = _coOperativeUIService.GetCoOperativeUI(bankMemberId, navbarEnumId);
                return IsNotNull(coOperativeUIModel) ? CreateOKResponse(new CoOperativeUIResponse { CoOperativeUIModel = coOperativeUIModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, "CoOperativeUI", TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new CoOperativeUIResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, "CoOperativeUI", TraceLevel.Error);
                return CreateInternalServerErrorResponse(new CoOperativeUIResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}