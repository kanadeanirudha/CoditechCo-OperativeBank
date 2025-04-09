using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankVehicleModelController : BaseController
    {
        private readonly IBankVehicleModelAgent _bankVehicleModelAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankVehicleModel/CreateEdit.cshtml";

        public BankVehicleModelController(IBankVehicleModelAgent bankVehicleModelAgent)
        {
            _bankVehicleModelAgent = bankVehicleModelAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankVehicleModelListViewModel list = _bankVehicleModelAgent.GetVehicleModelList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankVehicleModel/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankVehicleModel/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankVehicleModelViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankVehicleModelViewModel bankVehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                bankVehicleModelViewModel = _bankVehicleModelAgent.CreateVehicleModel(bankVehicleModelViewModel);
                if (!bankVehicleModelViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankVehicleModelViewModel.ErrorMessage));
            return View(createEdit, bankVehicleModelViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankVehicleModelId)
        {
            BankVehicleModelViewModel bankVehicleModelViewModel = _bankVehicleModelAgent.GetVehicleModel(bankVehicleModelId);
            return ActionView(createEdit, bankVehicleModelViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankVehicleModelViewModel bankVehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankVehicleModelAgent.UpdateVehicleModel(bankVehicleModelViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankVehicleModelId = bankVehicleModelViewModel.BankVehicleModelId });
            }
            return View(createEdit, bankVehicleModelViewModel);
        }

        public virtual ActionResult Delete(string BankVehicleModelIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(BankVehicleModelIds))
            {
                status = _bankVehicleModelAgent.DeleteVehicleModel(BankVehicleModelIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankVehicleModelController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankVehicleModelController>(x => x.List(null));
        }

        #region Protected

        #endregion
    }
}