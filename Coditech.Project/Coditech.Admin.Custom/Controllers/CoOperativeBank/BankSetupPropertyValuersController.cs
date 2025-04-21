using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Common.Helper.Utilities;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankSetupPropertyValuersController : BaseController
    {
        private readonly IBankSetupPropertyValuersAgent _bankSetupPropertyValuersAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSetupPropertyValuers/CreateEdit.cshtml";

        public BankSetupPropertyValuersController(IBankSetupPropertyValuersAgent bankSetupPropertyValuersAgent)
        {
            _bankSetupPropertyValuersAgent = bankSetupPropertyValuersAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankSetupPropertyValuersListViewModel list = _bankSetupPropertyValuersAgent.GetPropertyValuersList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankSetupPropertyValuers/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankSetupPropertyValuers/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View("~/Views/CoOperativeBank/BankSetupPropertyValuers/CreateEdit.cshtml", new BankSetupPropertyValuersViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankSetupPropertyValuersViewModel bankSetupPropertyValuersViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSetupPropertyValuersViewModel = _bankSetupPropertyValuersAgent.CreatePropertyValuers(bankSetupPropertyValuersViewModel);
                if (!bankSetupPropertyValuersViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSetupPropertyValuersViewModel.ErrorMessage));
            return View(createEdit, bankSetupPropertyValuersViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(long generalPersonAddressId)
        {
            BankSetupPropertyValuersViewModel bankSetupPropertyValuersViewModel = _bankSetupPropertyValuersAgent.GetPropertyValuers(generalPersonAddressId);
            return ActionView(createEdit, bankSetupPropertyValuersViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankSetupPropertyValuersViewModel bankSetupPropertyValuersViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankSetupPropertyValuersAgent.UpdatePropertyValuers(bankSetupPropertyValuersViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { generalPersonAddressId = bankSetupPropertyValuersViewModel.GeneralPersonAddressId });
            }
            return View(createEdit, bankSetupPropertyValuersViewModel);
        }

        public virtual ActionResult Delete(string BankSetupPropertyValuersIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(BankSetupPropertyValuersIds))
            {
                status = _bankSetupPropertyValuersAgent.DeletePropertyValuers(BankSetupPropertyValuersIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankSetupPropertyValuersController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankSetupPropertyValuersController>(x => x.List(null));
        }

        #region Protected

        #endregion
    }
}





























//[HttpGet]
//public virtual ActionResult Create()
//{
//    BankSetupPropertyValuersViewModel model = new BankSetupPropertyValuersViewModel();
//    //{
//    //    BankSetupPropertyValuersList = new List<BankSetupPropertyValuersViewModel>
//    //    {
//    //        new BankSetupPropertyValuersViewModel { AddressTypeEnum = AddressTypeEnum.PermanentAddress.ToString() },
//    //        new BankSetupPropertyValuersViewModel { AddressTypeEnum = AddressTypeEnum.CorrespondanceAddress.ToString() },
//    //        new BankSetupPropertyValuersViewModel { AddressTypeEnum = AddressTypeEnum.BusinessAddress.ToString() }
//    //    },
//    //    FirstName = "",
//    //    LastName = "",
//    //    GeneralPersonAddressId = 0
//    //};
//    return ActionView("~/Views/CoOperativeBank/BankSetupPropertyValuers/CreateEdit.cshtml", model);
//}