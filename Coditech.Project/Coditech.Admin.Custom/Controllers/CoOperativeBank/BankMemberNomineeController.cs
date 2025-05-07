using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankMemberNomineeController : BaseController
    {
        private readonly IBankMemberNomineeAgent _bankMemberNomineeAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankMemberNominee/CreateEdit.cshtml";
        private const string createEditMemberNominee = "~/Views/CoOperativeBank/BankMember/CreateEditMemberNominee.cshtml";


        public BankMemberNomineeController(IBankMemberNomineeAgent bankMemberNomineeAgent)
        {
            _bankMemberNomineeAgent = bankMemberNomineeAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankMemberNomineeListViewModel list = _bankMemberNomineeAgent.GetMemberNomineeList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankMemberNominee/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankMemberNominee/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankMemberNomineeViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankMemberNomineeViewModel bankMemberNomineeViewModel)
        {
            if (ModelState.IsValid)
            {
                bankMemberNomineeViewModel = _bankMemberNomineeAgent.CreateMemberNominee(bankMemberNomineeViewModel);
                if (!bankMemberNomineeViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankMemberNomineeViewModel.ErrorMessage));
            return View(createEdit, bankMemberNomineeViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(int bankMemberNomineeId)
        {
            BankMemberNomineeViewModel bankMemberNomineeViewModel = _bankMemberNomineeAgent.GetMemberNominee(bankMemberNomineeId);
            return ActionView(createEdit, bankMemberNomineeViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankMemberNomineeViewModel bankMemberNomineeViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberNomineeAgent.UpdateMemberNominee(bankMemberNomineeViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankMemberNomineeId = bankMemberNomineeViewModel.BankMemberNomineeId });
            }
            return View(createEdit, bankMemberNomineeViewModel);
        }

        public virtual ActionResult Delete(string BankMemberNomineeIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(BankMemberNomineeIds))
            {
                status = _bankMemberNomineeAgent.DeleteMemberNominee(BankMemberNomineeIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankMemberNomineeController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankMemberNomineeController>(x => x.List(null));
        }

        #region Protected

        #endregion
    }
}