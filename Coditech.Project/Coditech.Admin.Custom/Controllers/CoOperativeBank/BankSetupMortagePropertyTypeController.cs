using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankSetupMortagePropertyTypeController : BaseController
    {
        private readonly IBankSetupMortagePropertyTypeAgent _bankSetupMortagePropertyTypeAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSetupMortagePropertyType/CreateEdit.cshtml";

        public BankSetupMortagePropertyTypeController(IBankSetupMortagePropertyTypeAgent bankSetupMortagePropertyTypeAgent)
        {
            _bankSetupMortagePropertyTypeAgent = bankSetupMortagePropertyTypeAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankSetupMortagePropertyTypeListViewModel list = _bankSetupMortagePropertyTypeAgent.GetPropertyTypeList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankSetupMortagePropertyType/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankSetupMortagePropertyType/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankSetupMortagePropertyTypeViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankSetupMortagePropertyTypeViewModel bankSetupMortagePropertyTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSetupMortagePropertyTypeViewModel = _bankSetupMortagePropertyTypeAgent.CreatePropertyType(bankSetupMortagePropertyTypeViewModel);
                if (!bankSetupMortagePropertyTypeViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSetupMortagePropertyTypeViewModel.ErrorMessage));
            return View(createEdit, bankSetupMortagePropertyTypeViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankSetupMortagePropertyTypeId)
        {
            BankSetupMortagePropertyTypeViewModel bankSetupMortagePropertyTypeViewModel = _bankSetupMortagePropertyTypeAgent.GetPropertyType(bankSetupMortagePropertyTypeId);
            return ActionView(createEdit, bankSetupMortagePropertyTypeViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankSetupMortagePropertyTypeViewModel bankSetupMortagePropertyTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankSetupMortagePropertyTypeAgent.UpdatePropertyType(bankSetupMortagePropertyTypeViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankSetupMortagePropertyTypeId = bankSetupMortagePropertyTypeViewModel.BankSetupMortagePropertyTypeId });
            }
            return View(createEdit, bankSetupMortagePropertyTypeViewModel);
        }

        public virtual ActionResult Delete(string BankSetupMortagePropertyTypeIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(BankSetupMortagePropertyTypeIds))
            {
                status = _bankSetupMortagePropertyTypeAgent.DeletePropertyType(BankSetupMortagePropertyTypeIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankSetupMortagePropertyTypeController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankSetupMortagePropertyTypeController>(x => x.List(null));
        }

        #region Protected

        #endregion
    }
}