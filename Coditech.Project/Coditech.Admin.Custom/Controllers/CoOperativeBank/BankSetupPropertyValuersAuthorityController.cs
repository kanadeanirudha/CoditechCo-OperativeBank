using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankSetupPropertyValuersAuthorityController : BaseController
    {
        private readonly IBankSetupPropertyValuersAuthorityAgent _bankSetupPropertyValuersAuthorityAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSetupPropertyValuersAuthority/CreateEdit.cshtml";

        public BankSetupPropertyValuersAuthorityController(IBankSetupPropertyValuersAuthorityAgent bankSetupPropertyValuersAuthorityAgent)
        {
            _bankSetupPropertyValuersAuthorityAgent = bankSetupPropertyValuersAuthorityAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankSetupPropertyValuersAuthorityListViewModel list = _bankSetupPropertyValuersAuthorityAgent.GetPropertyValuersAuthorityList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankSetupPropertyValuersAuthority/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankSetupPropertyValuersAuthority/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankSetupPropertyValuersAuthorityViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankSetupPropertyValuersAuthorityViewModel bankSetupPropertyValuersAuthorityViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSetupPropertyValuersAuthorityViewModel = _bankSetupPropertyValuersAuthorityAgent.CreatePropertyValuersAuthority(bankSetupPropertyValuersAuthorityViewModel);
                if (!bankSetupPropertyValuersAuthorityViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSetupPropertyValuersAuthorityViewModel.ErrorMessage));
            return View(createEdit, bankSetupPropertyValuersAuthorityViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankSetupPropertyValuersAuthorityId)
        {
            BankSetupPropertyValuersAuthorityViewModel bankSetupPropertyValuersViewModel = _bankSetupPropertyValuersAuthorityAgent.GetPropertyValuersAuthority(bankSetupPropertyValuersAuthorityId);
            return ActionView(createEdit, bankSetupPropertyValuersViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankSetupPropertyValuersAuthorityViewModel bankSetupPropertyValuersAuthorityViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankSetupPropertyValuersAuthorityAgent.UpdatePropertyValuersAuthority(bankSetupPropertyValuersAuthorityViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankSetupPropertyValuersAuthorityId = bankSetupPropertyValuersAuthorityViewModel.BankSetupPropertyValuersAuthorityId });
            }
            return View(createEdit, bankSetupPropertyValuersAuthorityViewModel);
        }

        public virtual ActionResult Delete(string BankSetupPropertyValuersAuthorityIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(BankSetupPropertyValuersAuthorityIds))
            {
                status = _bankSetupPropertyValuersAuthorityAgent.DeletePropertyValuersAuthority(BankSetupPropertyValuersAuthorityIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankSetupPropertyValuersAuthorityController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankSetupPropertyValuersAuthorityController>(x => x.List(null));
        }

        #region Protected

        #endregion
    }
}