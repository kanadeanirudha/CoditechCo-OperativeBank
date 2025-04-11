using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankSetupOfficesController : BaseController
    {
        private readonly IBankSetupOfficesAgent _bankSetupOfficesAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSetupOffices/CreateEdit.cshtml";

        public BankSetupOfficesController(IBankSetupOfficesAgent bankSetupOfficesAgent)
        {
            _bankSetupOfficesAgent = bankSetupOfficesAgent;
        }
        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankSetupOfficesListViewModel list = _bankSetupOfficesAgent.GetBankSetupOfficesList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankSetupOffices/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankSetupOffices/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankSetupOfficesViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankSetupOfficesViewModel bankSetupOfficesViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSetupOfficesViewModel = _bankSetupOfficesAgent.CreateBankSetupOffices(bankSetupOfficesViewModel);
                if (!bankSetupOfficesViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSetupOfficesViewModel.ErrorMessage));
            return View(createEdit, bankSetupOfficesViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankSetupOfficeId)
        {
            BankSetupOfficesViewModel bankSetupOfficesViewModel = _bankSetupOfficesAgent.GetBankSetupOffices(bankSetupOfficeId);
            return ActionView(createEdit, bankSetupOfficesViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankSetupOfficesViewModel bankSetupOfficesViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSetupOfficesViewModel = _bankSetupOfficesAgent.UpdateBankSetupOffices(bankSetupOfficesViewModel);
                SetNotificationMessage(bankSetupOfficesViewModel.HasError
                ? GetErrorNotificationMessage(bankSetupOfficesViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction<BankSetupOfficesController>(x => x.List(null));
            }
            return View(createEdit, bankSetupOfficesViewModel);
        }
        public virtual ActionResult Delete(string bankSetupOfficeIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankSetupOfficeIds))
            {
                status = _bankSetupOfficesAgent.DeleteBankSetupOffices(bankSetupOfficeIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankSetupOfficesController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankSetupOfficesController>(x => x.List(null));
        }
    }
}
