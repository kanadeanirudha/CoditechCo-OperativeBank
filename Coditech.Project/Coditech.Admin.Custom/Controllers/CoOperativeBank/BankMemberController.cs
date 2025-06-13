using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankMemberController : BaseController
    {
        private readonly IBankMemberAgent _bankMemberAgent;
        private readonly IBankMemberNomineeAgent _bankMemberNomineeAgent;
        private readonly IBankMemberShareCapitalAgent _bankMemberShareCapitalAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankMember/CreateEdit.cshtml";
        private const string createEditMember = "~/Views/CoOperativeBank/BankMember/CreateEditMember.cshtml";
        private const string createEditNominee = "~/Views/CoOperativeBank/BankMemberNominee/CreateEdit.cshtml";
        private const string createEditBankMemberShareCapital = "~/Views/CoOperativeBank/BankMemberShareCapital/CreateEdit.cshtml";

        public BankMemberController(IBankMemberAgent bankMemberAgent, IBankMemberNomineeAgent bankMemberNomineeAgent, IBankMemberShareCapitalAgent bankMemberShareCapitalAgent)
        {
            _bankMemberAgent = bankMemberAgent;
            _bankMemberNomineeAgent = bankMemberNomineeAgent;
            _bankMemberShareCapitalAgent = bankMemberShareCapitalAgent;
        }
        public virtual ActionResult List(DataTableViewModel dataTableViewModel)
        {
            BankMemberListViewModel list = new BankMemberListViewModel();
            GetListOnlyIfSingleCentre(dataTableViewModel);
            if (!string.IsNullOrEmpty(dataTableViewModel.SelectedCentreCode))
            {
                list = _bankMemberAgent.GetBankMemberList(dataTableViewModel);
            }
            list.SelectedCentreCode = dataTableViewModel.SelectedCentreCode;
            if (AjaxHelper.IsAjaxRequest)
            {
                return PartialView("~/Views/CoOperativeBank/BankMember/_List.cshtml", list);
            }
            return View($"~/Views/CoOperativeBank/BankMember/List.cshtml", list);
        }

        [HttpGet]
        public virtual ActionResult CreateBankMember()
        {
            return View(createEditMember, new MemberCreateEditViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult CreateBankMember(MemberCreateEditViewModel memberCreateEditViewModel)
        {
            if (ModelState.IsValid)
            {
                memberCreateEditViewModel = _bankMemberAgent.CreateBankMember(memberCreateEditViewModel);
                if (!memberCreateEditViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    // Redirect to the List action with selectedCentreCode 
                    return RedirectToAction("List", new { selectedCentreCode = memberCreateEditViewModel.SelectedCentreCode });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(memberCreateEditViewModel.ErrorMessage));
            return View(createEditMember, memberCreateEditViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateMemberPersonalDetails(int bankMemberId, long personId)
        {
            MemberCreateEditViewModel memberCreateEditViewModel = _bankMemberAgent.GetMemberPersonalDetails(bankMemberId, personId);
            return ActionView(createEditMember, memberCreateEditViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateMemberPersonalDetails(MemberCreateEditViewModel memberCreateEditViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberAgent.UpdateMemberPersonalDetails(memberCreateEditViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateMemberPersonalDetails", new { bankMemberId = memberCreateEditViewModel.BankMemberId, personId = memberCreateEditViewModel.PersonId });
            }
            return View(createEditMember, memberCreateEditViewModel);
        }

        public virtual ActionResult Delete(string BankMemberIds)
        {
            string message = string.Empty;
            bool status = false;
            if (!string.IsNullOrEmpty(BankMemberIds))
            {
                status = _bankMemberAgent.DeleteBankMember(BankMemberIds, out message);
                SetNotificationMessage(!status
                ? GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.DeleteMessage));
                return RedirectToAction<BankMemberController>(x => x.List(null));
            }
            SetNotificationMessage(GetErrorNotificationMessage(GeneralResources.DeleteErrorMessage));
            return RedirectToAction<BankMemberController>(x => x.List(null));
        }

        #region Member Other Detail
        [HttpGet]
        public virtual ActionResult UpdatMemberOtherDetail(int bankMemberId)
        {
            BankMemberViewModel bankMemberViewModel = _bankMemberAgent.GetMemberOtherDetail(bankMemberId);
            return ActionView(createEdit, bankMemberViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdatMemberOtherDetail(BankMemberViewModel bankMemberViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberAgent.UpdateMemberOtherDetail(bankMemberViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdatMemberOtherDetail", new { bankMemberId = bankMemberViewModel.BankMemberId });
            }
            return View(createEdit, bankMemberViewModel);
        }
        public virtual ActionResult Cancel(string SelectedCentreCode)
        {
            DataTableViewModel dataTableViewModel = new DataTableViewModel() { SelectedCentreCode = SelectedCentreCode};
            return RedirectToAction("List", dataTableViewModel);
        }
        #endregion
        #region Bank Member Nominee

        [HttpPost]
        public virtual ActionResult CreateMemberNominee(BankMemberNomineeViewModel bankMemberNomineeViewModel)
        {
            if (ModelState.IsValid)
            {
                bankMemberNomineeViewModel = _bankMemberNomineeAgent.CreateMemberNominee(bankMemberNomineeViewModel);
                if (!bankMemberNomineeViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("GetMemberNominee", new { bankMemberId = bankMemberNomineeViewModel.BankMemberId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankMemberNomineeViewModel.ErrorMessage));
            return View(createEditNominee, bankMemberNomineeViewModel);
        }

        [HttpGet]
        public virtual ActionResult GetMemberNominee(int bankMemberId )
        {
            BankMemberNomineeViewModel bankMemberNomineeViewModel = _bankMemberNomineeAgent.GetMemberNominee(bankMemberId);
            return ActionView(createEditNominee, bankMemberNomineeViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateMemberNominee(BankMemberNomineeViewModel bankMemberNomineeViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberNomineeAgent.UpdateMemberNominee(bankMemberNomineeViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("GetMemberNominee", new { bankMemberId = bankMemberNomineeViewModel.BankMemberId });
            }
            return View(createEditNominee, bankMemberNomineeViewModel);
        }
        #endregion
        #region BankMemberShareCapital

        [HttpPost]
        public virtual ActionResult CreateBankMemberShareCapital(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel)
        {
            if (ModelState.IsValid)
            {
                bankMemberShareCapitalViewModel = _bankMemberShareCapitalAgent.CreateMemberShareCapital(bankMemberShareCapitalViewModel);
                if (!bankMemberShareCapitalViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    return RedirectToAction("UpdateBankMemberShareCapital", new { bankMemberId = bankMemberShareCapitalViewModel.BankMemberId });
                }
            }
            SetNotificationMessage(GetErrorNotificationMessage(bankMemberShareCapitalViewModel.ErrorMessage));
            return View(createEditBankMemberShareCapital, bankMemberShareCapitalViewModel);
        }

        [HttpGet]
        public virtual ActionResult UpdateBankMemberShareCapital(int bankMemberId)
        {
            BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel = _bankMemberShareCapitalAgent.GetMemberShareCapital(bankMemberId);
            return ActionView(createEditBankMemberShareCapital, bankMemberShareCapitalViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdateBankMemberShareCapital(BankMemberShareCapitalViewModel bankMemberShareCapitalViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberShareCapitalAgent.UpdateMemberShareCapital(bankMemberShareCapitalViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("UpdateBankMemberShareCapital", new { bankMemberId = bankMemberShareCapitalViewModel.BankMemberId });
            }
            return View(createEditBankMemberShareCapital, bankMemberShareCapitalViewModel);
        }
        #endregion
    }
}
