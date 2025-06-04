using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankFixedDepositAccountController : BaseController
    {
        private readonly IBankFixedDepositAccountAgent _bankFixedDepositAccountAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankFixedDepositAccount/CreateEdit.cshtml";
        private const string BankFixedDepositClosure = "~/Views/CoOperativeBank/BankFixedDepositAccount/BankFixedDepositClosure.cshtml";
        private const string BankFixedDepositInterestPostings = "~/Views/CoOperativeBank/BankFixedDepositAccount/BankFixedDepositInterestPostings.cshtml";

        public BankFixedDepositAccountController(IBankFixedDepositAccountAgent bankFixedDepositAccountAgent)
        {
            _bankFixedDepositAccountAgent = bankFixedDepositAccountAgent;
        }
        #region BankFixedDepositAccount
        public virtual ActionResult List(DataTableViewModel dataTableViewModel)
        {
            BankFixedDepositAccountListViewModel list = new BankFixedDepositAccountListViewModel();
            GetListOnlyIfSingleCentre(dataTableViewModel);
            if (!string.IsNullOrEmpty(dataTableViewModel.SelectedCentreCode))
            {
                list = _bankFixedDepositAccountAgent.GetBankFixedDepositAccountList(dataTableViewModel);
            }
            list.SelectedCentreCode = dataTableViewModel.SelectedCentreCode;
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankFixedDepositAccount/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankFixedDepositAccount/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(createEdit, new BankFixedDepositAccountViewModel());
        }

        [HttpPost]
        public virtual ActionResult Create(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositAccountViewModel = _bankFixedDepositAccountAgent.CreateBankFixedDepositAccount(bankFixedDepositAccountViewModel);
                if (!bankFixedDepositAccountViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("List", new DataTableViewModel { SelectedCentreCode = bankFixedDepositAccountViewModel.CentreCode });

                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankFixedDepositAccountViewModel.ErrorMessage));
            return View(createEdit, bankFixedDepositAccountViewModel);
        }

        [HttpGet]
        public virtual ActionResult Edit(short bankFixedDepositAccountId)
        {
            BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel = _bankFixedDepositAccountAgent.GetBankFixedDepositAccount(bankFixedDepositAccountId);
            return ActionView(createEdit, bankFixedDepositAccountViewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(BankFixedDepositAccountViewModel bankFixedDepositAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositAccountViewModel = _bankFixedDepositAccountAgent.UpdateBankFixedDepositAccount(bankFixedDepositAccountViewModel);
                SetNotificationMessage(bankFixedDepositAccountViewModel.HasError
                ? GetErrorNotificationMessage(bankFixedDepositAccountViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("Edit", new { bankFixedDepositAccountId = bankFixedDepositAccountViewModel.BankFixedDepositAccountId });
            }
            return View(createEdit, bankFixedDepositAccountViewModel);
        }
        public virtual ActionResult Delete(string bankFixedDepositAccountIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(bankFixedDepositAccountIds))
            {
                status = _bankFixedDepositAccountAgent.DeleteBankFixedDepositAccount(bankFixedDepositAccountIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankFixedDepositAccountController>(x => x.List(null));
            }

            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankFixedDepositAccountController>(x => x.List(null));
        }
        public virtual ActionResult Cancel(string SelectedCentreCode)
        {
            DataTableViewModel dataTableViewModel = new DataTableViewModel() { SelectedCentreCode = SelectedCentreCode};
            return RedirectToAction("List", dataTableViewModel);
        }
        #endregion
        #region BankFixedDepositClosure

        [HttpPost]
        public virtual ActionResult CreateBankFixedDepositClosure(BankFixedDepositClosureViewModel bankFixedDepositClosureViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositClosureViewModel = _bankFixedDepositAccountAgent.CreateBankFixedDepositClosure(bankFixedDepositClosureViewModel);
                if (!bankFixedDepositClosureViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankFixedDepositClosure", new { bankFixedDepositAccountId = bankFixedDepositClosureViewModel.BankFixedDepositAccountId });

                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankFixedDepositClosureViewModel.ErrorMessage));
            return View(createEdit, bankFixedDepositClosureViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankFixedDepositClosure(short bankFixedDepositAccountId)
        {
            BankFixedDepositClosureViewModel bankFixedDepositClosureViewModel = _bankFixedDepositAccountAgent.GetBankFixedDepositClosure(bankFixedDepositAccountId);
            return ActionView(BankFixedDepositClosure, bankFixedDepositClosureViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankFixedDepositClosure(BankFixedDepositClosureViewModel bankFixedDepositClosureViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositClosureViewModel = _bankFixedDepositAccountAgent.UpdateBankFixedDepositClosure(bankFixedDepositClosureViewModel);
                SetNotificationMessage(bankFixedDepositClosureViewModel.HasError
                ? GetErrorNotificationMessage(bankFixedDepositClosureViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankFixedDepositClosure", new { bankFixedDepositAccountId = bankFixedDepositClosureViewModel.BankFixedDepositAccountId });

            }
            return View(BankFixedDepositClosure, bankFixedDepositClosureViewModel);
        }

        #endregion
        #region BankFixedDepositInterestPostings

        [HttpPost]
        public virtual ActionResult CreateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsViewModel bankFixedDepositInterestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositInterestPostingsViewModel = _bankFixedDepositAccountAgent.CreateBankFixedDepositInterestPostings(bankFixedDepositInterestPostingsViewModel);
                if (!bankFixedDepositInterestPostingsViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankFixedDepositInterestPostings", new { bankFixedDepositAccountId = bankFixedDepositInterestPostingsViewModel.BankFixedDepositAccountId });

                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankFixedDepositInterestPostingsViewModel.ErrorMessage));
            return View(BankFixedDepositInterestPostings, bankFixedDepositInterestPostingsViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankFixedDepositInterestPostings(short bankFixedDepositAccountId)
        {
            BankFixedDepositInterestPostingsViewModel bankFixedDepositInterestPostingsViewModel = _bankFixedDepositAccountAgent.GetBankFixedDepositInterestPostings(bankFixedDepositAccountId);
            return ActionView(BankFixedDepositInterestPostings, bankFixedDepositInterestPostingsViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsViewModel bankFixedDepositInterestPostingsViewModel)
        {
            if (ModelState.IsValid)
            {
                bankFixedDepositInterestPostingsViewModel = _bankFixedDepositAccountAgent.UpdateBankFixedDepositInterestPostings(bankFixedDepositInterestPostingsViewModel);
                SetNotificationMessage(bankFixedDepositInterestPostingsViewModel.HasError
                ? GetErrorNotificationMessage(bankFixedDepositInterestPostingsViewModel.ErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankFixedDepositInterestPostings", new { bankFixedDepositAccountId = bankFixedDepositInterestPostingsViewModel.BankFixedDepositAccountId });

            }
            return View(BankFixedDepositInterestPostings, bankFixedDepositInterestPostingsViewModel);
        }

        #endregion
    }
}
