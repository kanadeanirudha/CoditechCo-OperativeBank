using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Common.Helper.Utilities;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankRecurringDepositAccountController : BaseController
    {
        private readonly IBankRecurringDepositAccountAgent _bankRecurringDepositAccountAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankRecurringDepositAccount/CreateEdit.cshtml";
        private const string BankRecurringDepositInterestPosting = "~/Views/CoOperativeBank/BankRecurringDepositAccount/InterestPostingCreateEdit.cshtml";

        public BankRecurringDepositAccountController(IBankRecurringDepositAccountAgent bankRecurringDepositAccountAgent)
        {
            _bankRecurringDepositAccountAgent = bankRecurringDepositAccountAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankRecurringDepositAccountListViewModel list = _bankRecurringDepositAccountAgent.GetBankRecurringDepositAccountList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankRecurringDepositAccount/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankRecurringDepositAccount/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankRecurringDepositAccountViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankRecurringDepositAccountViewModel bankRecurringDepositAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankRecurringDepositAccountViewModel = _bankRecurringDepositAccountAgent.CreateBankRecurringDepositAccount(bankRecurringDepositAccountViewModel);
                if (!bankRecurringDepositAccountViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankRecurringDepositAccountViewModel.ErrorMessage));
            return View(createEdit, bankRecurringDepositAccountViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(int bankRecurringDepositAccountId)
        {
            BankRecurringDepositAccountViewModel bankRecurringDepositAccountViewModel = _bankRecurringDepositAccountAgent.GetBankRecurringDepositAccount(bankRecurringDepositAccountId);
            return ActionView(createEdit, bankRecurringDepositAccountViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankRecurringDepositAccountViewModel bankRecurringDepositAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankRecurringDepositAccountViewModel = _bankRecurringDepositAccountAgent.UpdateBankRecurringDepositAccount(bankRecurringDepositAccountViewModel);
                SetNotificationMessage(bankRecurringDepositAccountViewModel.HasError
                ? GetErrorNotificationMessage(bankRecurringDepositAccountViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction<BankRecurringDepositAccountController>(x => x.List(null));
            }
            return View(createEdit, bankRecurringDepositAccountViewModel);
        }
        public virtual ActionResult Delete(string bankRecurringDepositAccountIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankRecurringDepositAccountIds))
            {
                status = _bankRecurringDepositAccountAgent.DeleteBankRecurringDepositAccount(bankRecurringDepositAccountIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankRecurringDepositAccountController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankRecurringDepositAccountController>(x => x.List(null));
        }

        public ActionResult GetBankProductByCentreCode(string selectedCentreCode)
        {
            DropdownViewModel bankProductByCentreCodeDropdown = new DropdownViewModel()
            {
                DropdownType = DropdownCustomTypeEnum.BankProduct.ToString(),
                DropdownName = "BankProductId",
                Parameter = selectedCentreCode,
                IsCustomDropdown = true,

            };
            return PartialView("~/Views/Shared/Control/_DropdownList.cshtml", bankProductByCentreCodeDropdown);
        }
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

        #region BankRecurringDepositInterestPosting

        [HttpPost]
        public virtual ActionResult CreateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingViewModel bankRecurringDepositInterestPostingViewModel)
        {
            if (ModelState.IsValid)
            {
                bankRecurringDepositInterestPostingViewModel = _bankRecurringDepositAccountAgent.CreateBankRecurringDepositInterestPosting(bankRecurringDepositInterestPostingViewModel);
                if (!bankRecurringDepositInterestPostingViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankRecurringDepositInterestPosting", new { bankRecurringDepositAccountId = bankRecurringDepositInterestPostingViewModel.BankRecurringDepositAccountId });

                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankRecurringDepositInterestPostingViewModel.ErrorMessage));
            return View(BankRecurringDepositInterestPosting, bankRecurringDepositInterestPostingViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankRecurringDepositInterestPosting(int bankRecurringDepositAccountId)
        {
            BankRecurringDepositInterestPostingViewModel bankRecurringDepositInterestPostingViewModel = _bankRecurringDepositAccountAgent.GetBankRecurringDepositInterestPosting(bankRecurringDepositAccountId);
            return ActionView(BankRecurringDepositInterestPosting, bankRecurringDepositInterestPostingViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankRecurringDepositInterestPosting(BankRecurringDepositInterestPostingViewModel bankRecurringDepositInterestPostingViewModel)
        {
            if (ModelState.IsValid)
            {
                bankRecurringDepositInterestPostingViewModel = _bankRecurringDepositAccountAgent.UpdateBankRecurringDepositInterestPosting(bankRecurringDepositInterestPostingViewModel);
                SetNotificationMessage(bankRecurringDepositInterestPostingViewModel.HasError
                ? GetErrorNotificationMessage(bankRecurringDepositInterestPostingViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankRecurringDepositInterestPosting", new { bankRecurringDepositAccountId = bankRecurringDepositInterestPostingViewModel.BankRecurringDepositAccountId });

            }
            return View(BankRecurringDepositInterestPosting, bankRecurringDepositInterestPostingViewModel);
        }
        #endregion
    }
}
