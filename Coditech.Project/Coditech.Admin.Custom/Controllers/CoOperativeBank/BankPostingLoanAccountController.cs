using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Common.Helper.Utilities;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankPostingLoanAccountController : BaseController
    {
        private readonly IBankPostingLoanAccountAgent _bankPostingLoanAccountAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankPostingLoanAccount/CreateEdit.cshtml";

        public BankPostingLoanAccountController(IBankPostingLoanAccountAgent bankPostingLoanAccountAgent)
        {
            _bankPostingLoanAccountAgent = bankPostingLoanAccountAgent;
        }
        public virtual ActionResult List(DataTableViewModel dataTableViewModel)
        {
            BankPostingLoanAccountListViewModel list = new BankPostingLoanAccountListViewModel();
            if (!string.IsNullOrEmpty(dataTableViewModel.SelectedCentreCode) && !string.IsNullOrEmpty(dataTableViewModel.SelectedParameter1))
            {
                list = _bankPostingLoanAccountAgent.GetBankPostingLoanAccountList(dataTableViewModel);
            }
            list.SelectedCentreCode = dataTableViewModel.SelectedCentreCode;
            list.SelectedParameter1 = dataTableViewModel.SelectedParameter1;
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankPostingLoanAccount/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankPostingLoanAccount/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult CreatePostingLoanAccount()
        {
            return View(createEdit, new BankPostingLoanAccountViewModel());
        }

        [HttpPost]
        public virtual ActionResult CreatePostingLoanAccount(BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankPostingLoanAccountViewModel = _bankPostingLoanAccountAgent.CreatePostingLoanAccount(bankPostingLoanAccountViewModel);
                if (!bankPostingLoanAccountViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    // Redirect to the List action with selectedCentreCode 
                    return RedirectToAction("List", new { SelectedParameter1 = bankPostingLoanAccountViewModel.BankMemberId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankPostingLoanAccountViewModel.ErrorMessage));
            return View(createEdit, bankPostingLoanAccountViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdatePostingLoanAccount(int bankPostingLoanAccountId)
        {
            BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel = _bankPostingLoanAccountAgent.GetPostingLoanAccount(bankPostingLoanAccountId);
            return ActionView(createEdit, bankPostingLoanAccountViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdatePostingLoanAccount(BankPostingLoanAccountViewModel bankPostingLoanAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankPostingLoanAccountAgent.UpdatePostingLoanAccount(bankPostingLoanAccountViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdatePostingLoanAccount", new { bankPostingLoanAccountId = bankPostingLoanAccountViewModel.BankPostingLoanAccountId});
            }
            return View(createEdit, bankPostingLoanAccountViewModel);
        }

        public virtual ActionResult Delete(string bankPostingLoanAccountIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankPostingLoanAccountIds))
            {
                status = _bankPostingLoanAccountAgent.DeletePostingLoanAccount(bankPostingLoanAccountIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankPostingLoanAccountController>(x => x.List(null));
            }
            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankPostingLoanAccountController>(x => x.List(null));
        }

        //Get BankMember By CentreCode
        [HttpGet]
        public ActionResult GetBankMemberByCentreCode(string selectedCentreCode)
        {
            DropdownViewModel bankMemberByCentreCodeDropdown = new DropdownViewModel()
            {
                DropdownType = DropdownCustomTypeEnum.BankMembers.ToString(),
                DropdownName = "BankMemberId",
                Parameter = selectedCentreCode,
                IsCustomDropdown = true,

            };
            return PartialView("~/Views/Shared/Control/_DropdownList.cshtml", bankMemberByCentreCodeDropdown);
        }

        [HttpGet]
        public virtual ActionResult GetBankProductByCentreCode(string selectedCentreCode)
        {
            DropdownViewModel productDropdown = new DropdownViewModel()
            {
                DropdownType = DropdownCustomTypeEnum.BankProduct.ToString(),
                DropdownName = "BankProductId",
                Parameter = selectedCentreCode,
                IsCustomDropdown = true
            };
            return PartialView("~/Views/Shared/Control/_DropdownList.cshtml", productDropdown);
        }
    }
}





























//[HttpGet]
//public virtual ActionResult Create()
//{
//    BankPostingLoanAccountViewModel model = new BankPostingLoanAccountViewModel();
//    //{
//    //    BankPostingLoanAccountList = new List<BankPostingLoanAccountViewModel>
//    //    {
//    //        new BankPostingLoanAccountViewModel { AddressTypeEnum = AddressTypeEnum.PermanentAddress.ToString() },
//    //        new BankPostingLoanAccountViewModel { AddressTypeEnum = AddressTypeEnum.CorrespondanceAddress.ToString() },
//    //        new BankPostingLoanAccountViewModel { AddressTypeEnum = AddressTypeEnum.BusinessAddress.ToString() }
//    //    },
//    //    FirstName = "",
//    //    LastName = "",
//    //    GeneralPersonAddressId = 0
//    //};
//    return ActionView("~/Views/CoOperativeBank/BankPostingLoanAccount/CreateEdit.cshtml", model);
//}