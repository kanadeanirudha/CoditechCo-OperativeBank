using Coditech.Admin.Agents;
using Coditech.Admin.Custom.Agents.Interface.CoOperativeBank;
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
        private readonly IBankSavingAccountInterestPostingsAgent _bankSavingAccountInterestPostingsAgent;
        private readonly IBankSavingsAccountTransactionsAgent _bankSavingsAccountTransactionsAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankSavingsAccount/CreateEdit.cshtml";
        private const string BankSavingsAccountClosures = "~/Views/CoOperativeBank/BankSavingsAccount/BankSavingsAccountClosures.cshtml";
        private const string createEditBankSavingAccountInterestPostings = "~/Views/CoOperativeBank/BankSavingAccountInterestPostings/CreateEdit.cshtml";
        private const string createEditBankSavingsAccountTransactions = "~/Views/CoOperativeBank/BankSavingsAccountTransactions/CreateEdit.cshtml";
        public BankSavingsAccountController(IBankSavingsAccountAgent bankSavingsAccountAgent, IBankSavingAccountInterestPostingsAgent bankSavingAccountInterestPostingsAgent, IBankSavingsAccountTransactionsAgent bankSavingsAccountTransactionsAgent)
        {
            _bankSavingsAccountAgent = bankSavingsAccountAgent;
            _bankSavingAccountInterestPostingsAgent = bankSavingAccountInterestPostingsAgent;
            _bankSavingsAccountTransactionsAgent = bankSavingsAccountTransactionsAgent;
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

        #region BankSavingAccountInterestPostings
        [HttpPost]
        public virtual ActionResult CreateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsViewModel bankSavingAccountInterestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingAccountInterestPostingsViewModel = _bankSavingAccountInterestPostingsAgent.CreateBankSavingAccountInterestPostings(bankSavingAccountInterestPostingsViewModel);
                if (!bankSavingAccountInterestPostingsViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankSavingAccountInterestPostings", new { bankSavingsAccountId = bankSavingAccountInterestPostingsViewModel.BankSavingsAccountId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSavingAccountInterestPostingsViewModel.ErrorMessage));
            return View(createEditBankSavingAccountInterestPostings, bankSavingAccountInterestPostingsViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankSavingAccountInterestPostings(int bankSavingsAccountId)
        {
            BankSavingAccountInterestPostingsViewModel bankSavingAccountInterestPostingsViewModel = _bankSavingAccountInterestPostingsAgent.GetBankSavingAccountInterestPostings(bankSavingsAccountId);
            return ActionView(createEditBankSavingAccountInterestPostings, bankSavingAccountInterestPostingsViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankSavingAccountInterestPostings(BankSavingAccountInterestPostingsViewModel bankSavingAccountInterestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingAccountInterestPostingsViewModel = _bankSavingAccountInterestPostingsAgent.UpdateBankSavingAccountInterestPostings(bankSavingAccountInterestPostingsViewModel);
                SetNotificationMessage(bankSavingAccountInterestPostingsViewModel.HasError
                ? GetErrorNotificationMessage(bankSavingAccountInterestPostingsViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankSavingAccountInterestPostings", new { bankSavingsAccountId = bankSavingAccountInterestPostingsViewModel.BankSavingsAccountId });
            }
            return View(createEditBankSavingAccountInterestPostings, bankSavingAccountInterestPostingsViewModel);
        }
        #endregion

        #region BankSavingsAccountTransactions

        [HttpPost]
        public virtual ActionResult CreateBankSavingsAccountTransactions(BankSavingsAccountTransactionsViewModel bankSavingsAccountTransactionsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingsAccountTransactionsViewModel = _bankSavingsAccountTransactionsAgent.CreateBankSavingsAccountTransactions(bankSavingsAccountTransactionsViewModel);
                if (!bankSavingsAccountTransactionsViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankSavingsAccountTransactions", new { bankSavingsAccountId = bankSavingsAccountTransactionsViewModel.BankSavingsAccountId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankSavingsAccountTransactionsViewModel.ErrorMessage));
            return View(createEditBankSavingsAccountTransactions, bankSavingsAccountTransactionsViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankSavingsAccountTransactions(long bankSavingsAccountId)
        {
            BankSavingsAccountTransactionsViewModel bankSavingsAccountTransactionsViewModel = _bankSavingsAccountTransactionsAgent.GetBankSavingsAccountTransactions(bankSavingsAccountId);
            return ActionView(createEditBankSavingsAccountTransactions, bankSavingsAccountTransactionsViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankSavingsAccountTransactions(BankSavingsAccountTransactionsViewModel bankSavingsAccountTransactionsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankSavingsAccountTransactionsViewModel = _bankSavingsAccountTransactionsAgent.UpdateBankSavingsAccountTransactions(bankSavingsAccountTransactionsViewModel);
                SetNotificationMessage(bankSavingsAccountTransactionsViewModel.HasError
                ? GetErrorNotificationMessage(bankSavingsAccountTransactionsViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankSavingsAccountTransactions", new { bankSavingsAccountId = bankSavingsAccountTransactionsViewModel.BankSavingsAccountId });
            }
            return View(createEditBankSavingsAccountTransactions, bankSavingsAccountTransactionsViewModel);
        }

        #endregion
    }
}
