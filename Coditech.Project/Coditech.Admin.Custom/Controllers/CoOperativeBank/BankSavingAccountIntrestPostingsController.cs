using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankSavingAccountIntrestPostingsController : BaseController
    {
        private readonly IBankSavingAccountIntrestPostingsAgent _bankSavingAccountIntrestPostingsAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSavingAccountIntrestPostings/CreateEdit.cshtml";

        public BankSavingAccountIntrestPostingsController(IBankSavingAccountIntrestPostingsAgent bankSavingAccountIntrestPostingsAgent)
        {
            _bankSavingAccountIntrestPostingsAgent = bankSavingAccountIntrestPostingsAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankSavingAccountIntrestPostingsListViewModel list = _bankSavingAccountIntrestPostingsAgent.GetBankSavingAccountIntrestPostingsList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankSavingAccountIntrestPostings/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankSavingAccountIntrestPostings/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankSavingAccountIntrestPostingsViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingAccountIntrestPostingsViewModel = _bankSavingAccountIntrestPostingsAgent.CreateBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsViewModel);
                if (!bankSavingAccountIntrestPostingsViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSavingAccountIntrestPostingsViewModel.ErrorMessage));
            return View(createEdit, bankSavingAccountIntrestPostingsViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(int bankSavingAccountIntrestPostingsId)
        {
            BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel = _bankSavingAccountIntrestPostingsAgent.GetBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsId);
            return ActionView(createEdit, bankSavingAccountIntrestPostingsViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingAccountIntrestPostingsViewModel = _bankSavingAccountIntrestPostingsAgent.UpdateBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsViewModel);
                SetNotificationMessage(bankSavingAccountIntrestPostingsViewModel.HasError
                ? GetErrorNotificationMessage(bankSavingAccountIntrestPostingsViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction<BankInsurancePoliciesTypeController>(x => x.List(null));
            }
            return View(createEdit, bankSavingAccountIntrestPostingsViewModel);
        }
        public virtual ActionResult Delete(string bankSavingAccountIntrestPostingsIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankSavingAccountIntrestPostingsIds))
            {
                status = _bankSavingAccountIntrestPostingsAgent.DeleteBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankSavingAccountIntrestPostingsController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankSavingAccountIntrestPostingsController>(x => x.List(null));
        }
    }
}
