using Coditech.Admin.Agents;
using Coditech.Admin.Helpers;
using Coditech.Admin.ViewModel;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
using Coditech.Admin.Utilities;
using Microsoft.AspNetCore.Mvc;
using Coditech.Resources;
namespace Coditech.Admin.Controllers
{
    public class CoOperativeUIController : BaseController
    {
        private readonly ICoOperativeUIAgent _coOperativeUIAgent;
        private readonly IBankMemberAgent _bankMemberAgent;

        public CoOperativeUIController(ICoOperativeUIAgent coOperativeUIAgent, IBankMemberAgent bankMemberAgent)
        {
            _coOperativeUIAgent = coOperativeUIAgent;
            _bankMemberAgent = bankMemberAgent;
        }

        [HttpGet]
        public IActionResult Index(int bankMemberId, string selectedcentreCode = null, int accSetupBalanceSheetId = 0)
        {
            if (!AdminGeneralHelper.IsBalanceSheetAssociated())
            {
                SetNotificationMessage(GetErrorNotificationMessage("Balance Sheet Not Associated."));
                return View("~/Views/Shared/BalanceSheetAssociated.cshtml");
            }
            GeneralFinancialYearModel generalFinancialYearModel = _coOperativeUIAgent.GetCurrentFinancialYear();
            if (generalFinancialYearModel?.GeneralFinancialYearId <= 0)
            {
                SetNotificationMessage(GetErrorNotificationMessage("Current Financial Year Not Set For Selected Balance Sheet."));
            }
            CoOperativeUIViewModel coOperativeViewModel = new CoOperativeUIViewModel();
            coOperativeViewModel.GeneralFinancialYearModel = generalFinancialYearModel;
            coOperativeViewModel.GeneralFinancialYearId = generalFinancialYearModel.GeneralFinancialYearId;
            if (accSetupBalanceSheetId > 0)
            {
                coOperativeViewModel = _coOperativeUIAgent.GetCoOperativeUIDetails(selectedcentreCode, bankMemberId, accSetupBalanceSheetId);
                coOperativeViewModel.CentreCode = selectedcentreCode;
                coOperativeViewModel.BankMemberId = bankMemberId;
                coOperativeViewModel.AccSetupBalanceSheetId = accSetupBalanceSheetId;
            }
            return View("~/Views/CoOperativeBank/CoOperativeUI/CoOperativeUI.cshtml", coOperativeViewModel);
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

        #region Member Personal Detail
        [HttpGet]
        public virtual ActionResult LoadCoOperativeUIPartial(string centreCode, int bankMemberId)
        {
            MemberCreateEditViewModel model = _coOperativeUIAgent.GetCoOperativeUI(centreCode, bankMemberId);
            return ActionView("~/Views/CoOperativeBank/BankMember/CreateEditMember.cshtml", model);
        }
        [HttpPost]
        public virtual ActionResult LoadCoOperativeUIPartial(MemberCreateEditViewModel memberCreateEditViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberAgent.UpdateMemberPersonalDetails(memberCreateEditViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("LoadCoOperativeUIPartial", new { centreCode = memberCreateEditViewModel.SelectedCentreCode, bankMemberId = memberCreateEditViewModel.BankMemberId });
            }
            return View("~/Views/CoOperativeBank/BankMember/CreateEditMember.cshtml", memberCreateEditViewModel);
        }
        #endregion
        #region Member Other Detail
        [HttpGet]
        public virtual ActionResult UpdatMemberOtherDetail(int bankMemberId)
        {
            BankMemberViewModel bankMemberViewModel = _bankMemberAgent.GetMemberOtherDetail(bankMemberId);
            return ActionView("~/Views/CoOperativeBank/BankMember/CreateEdit.cshtml", bankMemberViewModel);
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
            return View("~/Views/CoOperativeBank/BankMember/CreateEdit.cshtml", bankMemberViewModel);
        }
        #endregion
    }
}
