using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankSetupDivisionController : BaseController
    {
        private readonly IBankSetupDivisionAgent _bankSetupDivisionAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSetupDivision/CreateEdit.cshtml";

        public BankSetupDivisionController(IBankSetupDivisionAgent bankSetupDivisionAgent)
        {
            _bankSetupDivisionAgent = bankSetupDivisionAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankSetupDivisionListViewModel list = _bankSetupDivisionAgent.GetBankSetupDivisionList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankSetupDivision/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankSetupDivision/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankSetupDivisionViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankSetupDivisionViewModel bankSetupDivisionViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSetupDivisionViewModel = _bankSetupDivisionAgent.CreateBankSetupDivision(bankSetupDivisionViewModel);
                if (!bankSetupDivisionViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSetupDivisionViewModel.ErrorMessage));
            return View(createEdit, bankSetupDivisionViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankSetupDivisionId)
        {
            BankSetupDivisionViewModel bankSetupDivisionViewModel = _bankSetupDivisionAgent.GetBankSetupDivision(bankSetupDivisionId);
            return ActionView(createEdit, bankSetupDivisionViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankSetupDivisionViewModel bankSetupDivisionViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSetupDivisionViewModel = _bankSetupDivisionAgent.UpdateBankSetupDivision(bankSetupDivisionViewModel);
                SetNotificationMessage(bankSetupDivisionViewModel.HasError
                ? GetErrorNotificationMessage(bankSetupDivisionViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction<BankSetupDivisionController>(x => x.List(null));
            }
            return View(createEdit, bankSetupDivisionViewModel);
        }
        public virtual ActionResult Delete(string bankSetupDivisionIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankSetupDivisionIds))
            {
                status = _bankSetupDivisionAgent.DeleteBankSetupDivision(bankSetupDivisionIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankSetupDivisionController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankSetupDivisionController>(x => x.List(null));
        }
    }
}
