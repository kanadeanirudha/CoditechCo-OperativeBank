using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankFixedDepositAccountController : BaseController
    {
        private readonly IBankFixedDepositAccountAgent _bankFixedDepositAccountAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankFixedDepositAccount/CreateEdit.cshtml";

        public BankFixedDepositAccountController(IBankFixedDepositAccountAgent bankFixedDepositAccountAgent)
        {
            _bankFixedDepositAccountAgent = bankFixedDepositAccountAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableViewModel)
        {
            BankFixedDepositAccountListViewModel list = new BankFixedDepositAccountListViewModel();
            GetListOnlyIfSingleCentre(dataTableViewModel);
            if (!string.IsNullOrEmpty(dataTableViewModel.SelectedCentreCode))
            {
                list = _bankFixedDepositAccountAgent.GetBankFixedDepositAccountList(dataTableViewModel);
            }
            list.SelectedCentreCode = dataTableViewModel.SelectedCentreCode;
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankFixedDepositAccount/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankFixedDepositAccount/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankFixedDepositAccountViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositAccountViewModel = _bankFixedDepositAccountAgent.CreateBankFixedDepositAccount(bankFixedDepositAccountViewModel);
                if (!bankFixedDepositAccountViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankFixedDepositAccountViewModel.ErrorMessage));
            return View(createEdit, bankFixedDepositAccountViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankFixedDepositAccountId)
        {
            BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel = _bankFixedDepositAccountAgent.GetBankFixedDepositAccount(bankFixedDepositAccountId);
            return ActionView(createEdit, bankFixedDepositAccountViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositAccountViewModel = _bankFixedDepositAccountAgent.UpdateBankFixedDepositAccount(bankFixedDepositAccountViewModel);
                SetNotificationMessage(bankFixedDepositAccountViewModel.HasError
                ? GetErrorNotificationMessage(bankFixedDepositAccountViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction<BankFixedDepositAccountController>(x => x.List(null));
            }
            return View(createEdit, bankFixedDepositAccountViewModel);
        }
        public virtual ActionResult Delete(string bankFixedDepositAccountIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankFixedDepositAccountIds))
            {
                status = _bankFixedDepositAccountAgent.DeleteBankFixedDepositAccount(bankFixedDepositAccountIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankFixedDepositAccountController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankFixedDepositAccountController>(x => x.List(null));
        }
    }
}
