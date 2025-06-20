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
        private readonly IBankLoanScheduleAgent _bankLoanScheduleAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankPostingLoanAccount/CreateEdit.cshtml";
        private const string BankLoanSchedulecreateEdit = "~/Views/CoOperativeBank/BankLoanSchedule/CreateEdit.cshtml";
        private const string BankLoanForeClosures = "~/Views/CoOperativeBank/BankPostingLoanAccount/BankLoanForeClosures.cshtml";
        private const string createEditRepayment = "~/Views/CoOperativeBank/BankLoanRepayment/CreateEdit.cshtml";

        public BankPostingLoanAccountController(IBankPostingLoanAccountAgent bankPostingLoanAccountAgent, IBankLoanScheduleAgent bankLoanScheduleAgent)
        {
            _bankPostingLoanAccountAgent = bankPostingLoanAccountAgent;
            _bankLoanScheduleAgent = bankLoanScheduleAgent;
        }      
        public virtual ActionResult List(string centreCode, int bankMemberId)
        {
            BankPostingLoanAccountListViewModel list = new BankPostingLoanAccountListViewModel();
            if (!string.IsNullOrEmpty(centreCode) && bankMemberId > 0)
            {
                list = _bankPostingLoanAccountAgent.GetBankPostingLoanAccountList(centreCode, bankMemberId);
            }           
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
                return RedirectToAction("UpdatePostingLoanAccount", new { bankPostingLoanAccountId = bankPostingLoanAccountViewModel.BankPostingLoanAccountId });
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
                return RedirectToAction("List");
            }
            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction("List");
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
                DropdownType = DropdownCustomTypeEnum.BankProducts.ToString(),
                DropdownName = "BankProductId",
                Parameter = selectedCentreCode,
                IsCustomDropdown = true
            };
            return PartialView("~/Views/Shared/Control/_DropdownList.cshtml", productDropdown);
        }
        #region BankLoanForeClosures

        [HttpPost]
        public virtual ActionResult CreateBankLoanForeClosures(BankLoanForeClosuresViewModel bankLoanForeClosuresViewModel)
        {
            if (ModelState.IsValid)
            {
                bankLoanForeClosuresViewModel = _bankPostingLoanAccountAgent.CreateBankLoanForeClosures(bankLoanForeClosuresViewModel);
                if (!bankLoanForeClosuresViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankLoanForeClosures", new { bankPostingLoanAccountId = bankLoanForeClosuresViewModel.BankPostingLoanAccountId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankLoanForeClosuresViewModel.ErrorMessage));
            return View(BankLoanForeClosures, bankLoanForeClosuresViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankLoanForeClosures(int bankPostingLoanAccountId)
        {
            BankLoanForeClosuresViewModel bankLoanForeClosuresViewModel = _bankPostingLoanAccountAgent.GetBankLoanForeClosures(bankPostingLoanAccountId);
            return ActionView(BankLoanForeClosures, bankLoanForeClosuresViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankLoanForeClosures(BankLoanForeClosuresViewModel bankLoanForeClosuresViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankPostingLoanAccountAgent.UpdateBankLoanForeClosures(bankLoanForeClosuresViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankLoanForeClosures", new { bankPostingLoanAccountId = bankLoanForeClosuresViewModel.BankPostingLoanAccountId });
            }
            return View(BankLoanForeClosures, bankLoanForeClosuresViewModel);
        }
        #endregion

        #region Loan Repayment
        [HttpGet]
        public virtual ActionResult UpdateLoanRepayment(int bankPostingLoanAccountId)
        {
            BankLoanRepaymentViewModel bankLoanRepaymentViewModel = _bankPostingLoanAccountAgent.GetLoanRepayment(bankPostingLoanAccountId);
            return ActionView(createEditRepayment, bankLoanRepaymentViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateLoanRepayment(BankLoanRepaymentViewModel bankLoanRepaymentViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankPostingLoanAccountAgent.UpdateLoanRepayment(bankLoanRepaymentViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateLoanRepayment", new { bankPostingLoanAccountId = bankLoanRepaymentViewModel.BankPostingLoanAccountId });
            }
            return View(createEditRepayment, bankLoanRepaymentViewModel);
        }
        #endregion

        #region BankLoanSchedule

        [HttpPost]
        public virtual ActionResult CreateBankLoanSchedule(BankLoanScheduleViewModel bankLoanScheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                bankLoanScheduleViewModel = _bankLoanScheduleAgent.CreateBankLoanSchedule(bankLoanScheduleViewModel);
                if (!bankLoanScheduleViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankLoanSchedule", new { bankPostingLoanAccountId = bankLoanScheduleViewModel.BankPostingLoanAccountId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankLoanScheduleViewModel.ErrorMessage));
            return View(BankLoanSchedulecreateEdit, bankLoanScheduleViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankLoanSchedule(int bankPostingLoanAccountId)
        {
            BankLoanScheduleViewModel bankLoanScheduleViewModel = _bankLoanScheduleAgent.GetBankLoanSchedule(bankPostingLoanAccountId);
            return ActionView(BankLoanSchedulecreateEdit, bankLoanScheduleViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankLoanSchedule(BankLoanScheduleViewModel bankLoanScheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankLoanScheduleAgent.UpdateBankLoanSchedule(bankLoanScheduleViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankLoanSchedule", new { bankPostingLoanAccountId = bankLoanScheduleViewModel.BankPostingLoanAccountId });
            }
            return View(BankLoanSchedulecreateEdit, bankLoanScheduleViewModel);
        }
        #endregion
    }
}

