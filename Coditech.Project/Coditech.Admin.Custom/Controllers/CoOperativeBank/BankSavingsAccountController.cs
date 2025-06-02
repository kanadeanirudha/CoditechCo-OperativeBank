using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Common.Helper.Utilities;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankSavingsAccountController : BaseController
    {
        private readonly IBankSavingsAccountAgent _bankSavingsAccountAgent;
        private readonly IBankSavingAccountIntrestPostingsAgent _bankSavingAccountIntrestPostingsAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSavingsAccount/CreateEdit.cshtml";
        private const string BankSavingsAccountClosures = "~/Views/CoOperativeBank/BankSavingsAccount/BankSavingsAccountClosures.cshtml";
        private const string createEditBankSavingAccountIntrestPostings = "~/Views/CoOperativeBank/BankSavingAccountIntrestPostings/CreateEdit.cshtml";


        public BankSavingsAccountController(IBankSavingsAccountAgent bankSavingsAccountAgent, IBankSavingAccountIntrestPostingsAgent bankSavingAccountIntrestPostingsAgent)
        {
            _bankSavingsAccountAgent = bankSavingsAccountAgent;
            _bankSavingAccountIntrestPostingsAgent = bankSavingAccountIntrestPostingsAgent;
        }
        #region BankSavingAccount
        public virtual ActionResult List(DataTableViewModel dataTableModel)
        {
            BankSavingsAccountListViewModel list = _bankSavingsAccountAgent.GetBankSavingsAccountList(dataTableModel);
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankSavingsAccount/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankSavingsAccount/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankSavingsAccountViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankSavingsAccountViewModel bankSavingsAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingsAccountViewModel = _bankSavingsAccountAgent.CreateBankSavingsAccount(bankSavingsAccountViewModel);
                if (!bankSavingsAccountViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", CreateActionDataTable());
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSavingsAccountViewModel.ErrorMessage));
            return View(createEdit, bankSavingsAccountViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(long bankSavingsAccountId)
        {
            BankSavingsAccountViewModel bankSavingsAccountViewModel = _bankSavingsAccountAgent.GetBankSavingsAccount(bankSavingsAccountId);
            return ActionView(createEdit, bankSavingsAccountViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankSavingsAccountViewModel bankSavingsAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingsAccountViewModel = _bankSavingsAccountAgent.UpdateBankSavingsAccount(bankSavingsAccountViewModel);
                SetNotificationMessage(bankSavingsAccountViewModel.HasError
                ? GetErrorNotificationMessage(bankSavingsAccountViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction<BankSavingsAccountController>(x => x.List(null));
            }
            return View(createEdit, bankSavingsAccountViewModel);
        }
        public virtual ActionResult Delete(string bankSavingsAccountIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankSavingsAccountIds))
            {
                status = _bankSavingsAccountAgent.DeleteBankSavingsAccount(bankSavingsAccountIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankSavingsAccountController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankSavingsAccountController>(x => x.List(null));
        }
        //Get BankMember By CentreCode
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
        public ActionResult GetBankProductByCentreCode(string selectedCentreCode)
        {
            DropdownViewModel bankProductByCentreCodeDropdown = new DropdownViewModel()
            {
                DropdownType = DropdownCustomTypeEnum.BankProducts.ToString(),
                DropdownName = "BankProductId",
                Parameter = selectedCentreCode,
                IsCustomDropdown = true,

            };
            return PartialView("~/Views/Shared/Control/_DropdownList.cshtml", bankProductByCentreCodeDropdown);
        }
        #endregion
        #region BankAccountSavingClosures

        [HttpPost]
        public virtual ActionResult CreateBankSavingsAccountClosures(BankSavingsAccountClosuresViewModel bankSavingsAccountClosuresViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingsAccountClosuresViewModel = _bankSavingsAccountAgent.CreateBankSavingsAccountClosures(bankSavingsAccountClosuresViewModel);
                if (!bankSavingsAccountClosuresViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateSavingsAccountClosures", new { bankSavingsAccountId = bankSavingsAccountClosuresViewModel.BankSavingsAccountId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSavingsAccountClosuresViewModel.ErrorMessage));
            return View(BankSavingsAccountClosures, bankSavingsAccountClosuresViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateSavingsAccountClosures(long bankSavingsAccountId)
        {
            BankSavingsAccountClosuresViewModel bankSavingsAccountClosuresViewModel = _bankSavingsAccountAgent.GetBankSavingsAccountClosures(bankSavingsAccountId);
            return ActionView(BankSavingsAccountClosures, bankSavingsAccountClosuresViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateSavingsAccountClosures(BankSavingsAccountClosuresViewModel bankSavingsAccountClosuresViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankSavingsAccountAgent.UpdateBankSavingsAccountClosures(bankSavingsAccountClosuresViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateSavingsAccountClosures", new { bankSavingsAccountId = bankSavingsAccountClosuresViewModel.BankSavingsAccountId });
            }
            return View(BankSavingsAccountClosures, bankSavingsAccountClosuresViewModel);
        }
        #endregion

        #region BankSavingAccountIntrestPostings
        [HttpPost]
        public virtual ActionResult CreateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingAccountIntrestPostingsViewModel = _bankSavingAccountIntrestPostingsAgent.CreateBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsViewModel);
                if (!bankSavingAccountIntrestPostingsViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankSavingAccountIntrestPostings", new { bankSavingsAccountId = bankSavingAccountIntrestPostingsViewModel.BankSavingsAccountId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSavingAccountIntrestPostingsViewModel.ErrorMessage));
            return View(createEditBankSavingAccountIntrestPostings, bankSavingAccountIntrestPostingsViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankSavingAccountIntrestPostings(int bankSavingsAccountId)
        {
            BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel = _bankSavingAccountIntrestPostingsAgent.GetBankSavingAccountIntrestPostings(bankSavingsAccountId);
            return ActionView(createEditBankSavingAccountIntrestPostings, bankSavingAccountIntrestPostingsViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsViewModel bankSavingAccountIntrestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingAccountIntrestPostingsViewModel = _bankSavingAccountIntrestPostingsAgent.UpdateBankSavingAccountIntrestPostings(bankSavingAccountIntrestPostingsViewModel);
                SetNotificationMessage(bankSavingAccountIntrestPostingsViewModel.HasError
                ? GetErrorNotificationMessage(bankSavingAccountIntrestPostingsViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankSavingAccountIntrestPostings", new { bankSavingsAccountId = bankSavingAccountIntrestPostingsViewModel.BankSavingsAccountId });
            }
            return View(createEditBankSavingAccountIntrestPostings, bankSavingAccountIntrestPostingsViewModel);
        }

        #endregion
    }
}
