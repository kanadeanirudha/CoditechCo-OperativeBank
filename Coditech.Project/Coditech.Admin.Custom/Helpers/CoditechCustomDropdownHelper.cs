using Coditech.Admin.Utilities;
using Coditech.Admin.ViewModel;
using Coditech.API.Client;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Helper.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Coditech.Admin.Helpers
{
    public static class CoditechCustomDropdownHelper
    {
        public static List<UserAccessibleCentreModel> AccessibleCentreList()
        {
            return SessionHelper.GetDataFromSession<UserModel>(AdminConstants.UserDataSession)?.AccessibleCentreList;
        }

        public static DropdownViewModel GeneralDropdownList(DropdownViewModel dropdownViewModel)
        {
            List<SelectListItem> dropdownList = new List<SelectListItem>();
            if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.PropertyName.ToString()))
            {
                GetPropertyTypeList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankMember.ToString()))
            {
                GetBankMemberList(dropdownViewModel, dropdownList);
            }
            dropdownViewModel.DropdownList = dropdownList;
            return dropdownViewModel;
        }

        private static void GetPropertyTypeList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            BankSetupMortagePropertyTypeListResponse response = new BankSetupMortagePropertyTypeClient().List(null, null, null, 1, int.MaxValue);
            //if (response?.BankSetupMortagePropertyTypeList?.Count != 1)
            dropdownList.Add(new SelectListItem() { Text = "-------Select Mortage Property Type-------" });

            BankSetupMortagePropertyTypeListModel list = new BankSetupMortagePropertyTypeListModel { BankSetupMortagePropertyTypeList = response.BankSetupMortagePropertyTypeList };
            foreach (var item in list.BankSetupMortagePropertyTypeList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = string.Concat(item.PropertyName, " (", item.PropertyCode, ")"),
                    Value = Convert.ToString(item.BankSetupMortagePropertyTypeId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankSetupMortagePropertyTypeId)
                });
            }
        }
        private static void GetBankMemberList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            BankMemberListResponse response = new BankMemberClient().List(null, null, null, 1, int.MaxValue);
            if (response?.BankMemberList?.Count != 1)
                dropdownList.Add(new SelectListItem() { Text = "-------Select Member-------" });

            BankMemberListModel list = new BankMemberListModel { BankMemberList = response?.BankMemberList };
            foreach (var item in list.BankMemberList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = item.FirstName,
                    Value = Convert.ToString(item.BankMemberId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankMemberId)
                });
            }
        }

        private static string SpiltCentreCode(string centreCode)
        {
            centreCode = !string.IsNullOrEmpty(centreCode) && centreCode.Contains(":") ? centreCode.Split(':')[0] : centreCode;
            return centreCode;
        }
    }
}






