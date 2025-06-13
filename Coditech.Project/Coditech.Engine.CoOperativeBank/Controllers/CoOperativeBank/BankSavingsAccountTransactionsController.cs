using Coditech.API.Service;
using Coditech.Common.API;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Coditech.Common.Helper.HelperUtility;
namespace Coditech.Engine.DBTM.Controllers
{
    public class BankSavingsAccountTransactionsController : BaseController
    {
        private readonly IBankSavingsAccountTransactionsService _bankSavingsAccountTransactionsService;
        protected readonly ICoditechLogging _coditechLogging;
        public BankSavingsAccountTransactionsController(ICoditechLogging coditechLogging, IBankSavingsAccountTransactionsService bankSavingsAccountTransactionsService)
        {
            _bankSavingsAccountTransactionsService = bankSavingsAccountTransactionsService;
            _coditechLogging = coditechLogging;
        }

        [Route("/BankSavingsAccountTransactions/CreateBankSavingsAccountTransactions")]
        [HttpPost, ValidateModel]
        [Produces(typeof(BankSavingsAccountTransactionsResponse))]
        public virtual IActionResult CreateBankSavingsAccountTransactions([FromBody] BankSavingsAccountTransactionsModel model)
        {
            try
            {
                BankSavingsAccountTransactionsModel bankSavingsAccountTransactions = _bankSavingsAccountTransactionsService.CreateBankSavingsAccountTransactions(model);
                return IsNotNull(bankSavingsAccountTransactions) ? CreateCreatedResponse(new BankSavingsAccountTransactionsResponse { BankSavingsAccountTransactionsModel = bankSavingsAccountTransactions }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountTransactionsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountTransactionsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }

        [Route("/BankSavingsAccountTransactions/GetBankSavingsAccountTransactions")]
        [HttpGet]
        [Produces(typeof(BankSavingsAccountTransactionsResponse))]
        public virtual IActionResult GetBankSavingsAccountTransactions(long bankSavingsAccountId)
        {
            try
            {
                BankSavingsAccountTransactionsModel bankSavingsAccountTransactionsModel = _bankSavingsAccountTransactionsService.GetBankSavingsAccountTransactions(bankSavingsAccountId);
                return IsNotNull(bankSavingsAccountTransactionsModel) ? CreateOKResponse(new BankSavingsAccountTransactionsResponse { BankSavingsAccountTransactionsModel = bankSavingsAccountTransactionsModel }) : CreateNoContentResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountTransactionsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountTransactionsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
        [Route("/BankSavingsAccountTransactions/UpdateBankSavingsAccountTransactions")]
        [HttpPut, ValidateModel]
        [Produces(typeof(BankSavingsAccountTransactionsResponse))]
        public virtual IActionResult UpdateBankSavingsAccountTransactions([FromBody] BankSavingsAccountTransactionsModel model)
        {
            try
            {
                bool isUpdated = _bankSavingsAccountTransactionsService.UpdateBankSavingsAccountTransactions(model);
                return isUpdated ? CreateOKResponse(new BankSavingsAccountTransactionsResponse { BankSavingsAccountTransactionsModel = model }) : CreateInternalServerErrorResponse();
            }
            catch (CoditechException ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountTransactionsResponse { HasError = true, ErrorMessage = ex.Message, ErrorCode = ex.ErrorCode });
            }
            catch (Exception ex)
            {
                _coditechLogging.LogMessage(ex, LogComponentCustomEnum.BankSavingsAccountTransactions.ToString(), TraceLevel.Warning);
                return CreateInternalServerErrorResponse(new BankSavingsAccountTransactionsResponse { HasError = true, ErrorMessage = ex.Message });
            }
        }
    }
}
