using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankProductController : BaseController
    {
        private readonly IBankProductAgent _bankProductAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankProduct/CreateEdit.cshtml";

        public BankProductController(IBankProductAgent bankProductAgent)
        {
            _bankProductAgent = bankProductAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableViewModel)
        {
            BankProductListViewModel list = new BankProductListViewModel();
            GetListOnlyIfSingleCentre(dataTableViewModel);
            if (!string.IsNullOrEmpty(dataTableViewModel.SelectedCentreCode))
            {
                list = _bankProductAgent.GetBankProductList(dataTableViewModel);
            }
            list.SelectedCentreCode = dataTableViewModel.SelectedCentreCode;
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankProduct/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankProduct/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankProductViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankProductViewModel bankProductViewModel)
        {
            if (ModelState.IsValid)
            {
                bankProductViewModel = _bankProductAgent.CreateBankProduct(bankProductViewModel);
                if (!bankProductViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("Edit", new { bankProductId = bankProductViewModel.BankProductId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankProductViewModel.ErrorMessage));
            return View(createEdit, bankProductViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankProductId)
        {
            BankProductViewModel bankProductViewModel = _bankProductAgent.GetBankProduct(bankProductId);
            return ActionView(createEdit, bankProductViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankProductViewModel bankProductViewModel)
        {
            if (ModelState.IsValid)
            {
                bankProductViewModel = _bankProductAgent.UpdateBankProduct(bankProductViewModel);
                SetNotificationMessage(bankProductViewModel.HasError
                ? GetErrorNotificationMessage(bankProductViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankProductId = bankProductViewModel.BankProductId });
            }
            return View(createEdit, bankProductViewModel);
        }
        public virtual ActionResult Delete(string bankProductIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankProductIds))
            {
                status = _bankProductAgent.DeleteBankProduct(bankProductIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction("List", CreateActionDataTable());
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction("List", CreateActionDataTable());
        }
        public virtual ActionResult Cancel(string centreCode)
        {
            DataTableViewModel dataTableViewModel = new DataTableViewModel() { SelectedCentreCode = centreCode};
            return RedirectToAction("List", dataTableViewModel);
        }
    }
}
