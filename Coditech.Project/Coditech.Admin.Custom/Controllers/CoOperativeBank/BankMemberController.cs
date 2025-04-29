using Coditech.Admin.Agents;
using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.Common.Helper.Utilities;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Coditech.Admin.Controllers
{
    public class BankMemberController : BaseController
    {
        private readonly IBankMemberAgent _bankMemberAgent;
        private const string createEdit = "~/Views/CoOperativeBank/BankMember/CreateEdit.cshtml";
        private const string createEditMember = "~/Views/CoOperativeBank/BankMember/CreateEditMember.cshtml";

        public BankMemberController(IBankMemberAgent bankMemberAgent)
        {
            _bankMemberAgent = bankMemberAgent;
        }

        public virtual ActionResult List(DataTableViewModel dataTableViewModel)
        {
            BankMemberListViewModel list = new BankMemberListViewModel();
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
        public virtual ActionResult CreateBankMember(MemberCreateEditViewModel memberCreateEditViewModel)
        {
            if (ModelState.IsValid)
            {
                memberCreateEditViewModel = _bankMemberAgent.CreateBankMember(memberCreateEditViewModel);
                if (!memberCreateEditViewModel.HasError)
                {
                    SetNotificationMessage(GetSuccessNotificationMessage(GeneralResources.RecordAddedSuccessMessage));
                    // Redirect to the List action with selectedCentreCode and selectedDepartmentId
                    return RedirectToAction("UpdateMemberPersonalDetails", new { bankMemberId = memberCreateEditViewModel.EntityId, personId = memberCreateEditViewModel.PersonId });
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
        public virtual ActionResult GetMemberOtherDetail(int bankMemberId, long personId)
        {
            BankMemberViewModel bankMemberViewModel = _bankMemberAgent.GetBankMember(bankMemberId);
            return ActionView(createEdit, bankMemberViewModel);
        }

        [HttpPost]
        public virtual ActionResult UpdatMemberOtherDetail(BankMemberViewModel bankMemberViewModel)
        {
            if (ModelState.IsValid)
            {
                SetNotificationMessage(_bankMemberAgent.UpdateBankMember(bankMemberViewModel).HasError
                ? GetErrorNotificationMessage(GeneralResources.UpdateErrorMessage)
                : GetSuccessNotificationMessage(GeneralResources.UpdateMessage));
                return RedirectToAction("GetMemberOtherDetail", new { generalPersonAddressId = bankMemberViewModel.BankMemberId, personId = bankMemberViewModel.PersonId });
            }
            return View(createEdit, bankMemberViewModel);
        }
        #endregion

        #region Protected

        #endregion
    }
}





























//[HttpGet]
//public virtual ActionResult Create()
//{
//    BankMemberViewModel model = new BankMemberViewModel();
//    //{
//    //    BankMemberList = new List<BankMemberViewModel>
//    //    {
//    //        new BankMemberViewModel { AddressTypeEnum = AddressTypeEnum.PermanentAddress.ToString() },
//    //        new BankMemberViewModel { AddressTypeEnum = AddressTypeEnum.CorrespondanceAddress.ToString() },
//    //        new BankMemberViewModel { AddressTypeEnum = AddressTypeEnum.BusinessAddress.ToString() }
//    //    },
//    //    FirstName = "",
//    //    LastName = "",
//    //    GeneralPersonAddressId = 0
//    //};
//    return ActionView("~/Views/CoOperativeBank/BankMember/CreateEdit.cshtml", model);
//}