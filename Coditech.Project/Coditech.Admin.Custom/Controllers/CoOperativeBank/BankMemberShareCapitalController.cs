using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankMemberShareCapitalController : BaseController
    {
        private readonly IBankMemberShareCapitalAgent _bankMemberShareCapitalAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankMemberShareCapital/CreateEdit.cshtml";

        public BankMemberShareCapitalController(IBankMemberShareCapitalAgent bankMemberShareCapitalAgent)
        {
            _bankMemberShareCapitalAgent = bankMemberShareCapitalAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankMemberShareCapitalListViewModel list = _bankMemberShareCapitalAgent.GetMemberShareCapitalList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankMemberShareCapital/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankMemberShareCapital/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankMemberShareCapitalViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel)
        {
            if (ModelState.IsValid)
            {
                bankMemberShareCapitalViewModel = _bankMemberShareCapitalAgent.CreateMemberShareCapital(bankMemberShareCapitalViewModel);
                if (!bankMemberShareCapitalViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankMemberShareCapitalViewModel.ErrorMessage));
            return View(createEdit, bankMemberShareCapitalViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(int bankMemberShareCapitalId)
        {
            BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel = _bankMemberShareCapitalAgent.GetMemberShareCapital(bankMemberShareCapitalId);
            return ActionView(createEdit, bankMemberShareCapitalViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberShareCapitalAgent.UpdateMemberShareCapital(bankMemberShareCapitalViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankMemberShareCapitalId = bankMemberShareCapitalViewModel.BankMemberShareCapitalId });
            }
            return View(createEdit, bankMemberShareCapitalViewModel);
        }

        public virtual ActionResult Delete(string BankMemberShareCapitalIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(BankMemberShareCapitalIds))
            {
                status = _bankMemberShareCapitalAgent.DeleteMemberShareCapital(BankMemberShareCapitalIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankMemberShareCapitalController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankMemberShareCapitalController>(x => x.List(null));
        }

        #region Protected

        #endregion
    }
}