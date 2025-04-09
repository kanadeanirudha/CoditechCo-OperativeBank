using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankInsurancePoliciesTypeController : BaseController
    {
        private readonly IBankInsurancePoliciesTypeAgent _bankInsurancePoliciesTypeAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankInsurancePoliciesType/CreateEdit.cshtml";

        public BankInsurancePoliciesTypeController(IBankInsurancePoliciesTypeAgent bankInsurancePoliciesTypeAgent)
        {
            _bankInsurancePoliciesTypeAgent = bankInsurancePoliciesTypeAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankInsurancePoliciesTypeListViewModel list = _bankInsurancePoliciesTypeAgent.GetBankInsurancePoliciesTypeList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankInsurancePoliciesType/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankInsurancePoliciesType/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankInsurancePoliciesTypeViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankInsurancePoliciesTypeViewModel bankInsurancePoliciesTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                bankInsurancePoliciesTypeViewModel = _bankInsurancePoliciesTypeAgent.CreateBankInsurancePoliciesType(bankInsurancePoliciesTypeViewModel);
                if (!bankInsurancePoliciesTypeViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankInsurancePoliciesTypeViewModel.ErrorMessage));
            return View(createEdit, bankInsurancePoliciesTypeViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankInsurancePoliciesTypeId)
        {
            BankInsurancePoliciesTypeViewModel bankInsurancePoliciesTypeViewModel = _bankInsurancePoliciesTypeAgent.GetBankInsurancePoliciesType(bankInsurancePoliciesTypeId);
            return ActionView(createEdit, bankInsurancePoliciesTypeViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankInsurancePoliciesTypeViewModel bankInsurancePoliciesTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                bankInsurancePoliciesTypeViewModel = _bankInsurancePoliciesTypeAgent.UpdateBankInsurancePoliciesType(bankInsurancePoliciesTypeViewModel);
                SetNotificationMessage(bankInsurancePoliciesTypeViewModel.HasError
                ? GetErrorNotificationMessage(bankInsurancePoliciesTypeViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankInsurancePoliciesTypeIds = bankInsurancePoliciesTypeViewModel.BankInsurancePoliciesTypeId });

            }
            return View(createEdit, bankInsurancePoliciesTypeViewModel);
        }
        public virtual ActionResult Delete(string bankInsurancePoliciesTypeIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankInsurancePoliciesTypeIds))
            {
                status = _bankInsurancePoliciesTypeAgent.DeleteBankInsurancePoliciesType(bankInsurancePoliciesTypeIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankInsurancePoliciesTypeController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<GeneralFinancialYearMasterController>(x => x.List(null));
        }
    }
}
