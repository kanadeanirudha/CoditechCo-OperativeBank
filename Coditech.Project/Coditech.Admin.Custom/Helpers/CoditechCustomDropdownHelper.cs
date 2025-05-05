using Coditech.Admin.ViewModel;
using Coditech.API.Client;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.Helper.Utilities;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Coditech.Admin.Helpers
{
    public static class CoditechCustomDropdownHelper
    {
        public static DropdownViewModel GeneralDropdownList(DropdownViewModel dropdownViewModel)
        {
            List<SelectListItem> dropdownList = new List<SelectListItem>();
            if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankSetupDivision.ToString()))
            {
                GetBankSetupDivisionList(dropdownViewModel, dropdownList);
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

        private static void GetBankSetupDivisionList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            BankSetupDivisionListResponse response = new BankSetupDivisionClient().List(null, null, null, 1, int.MaxValue);
            if (dropdownViewModel.IsRequired)
                dropdownList.Add(new SelectListItem() { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem() { Value = "0", Text = GeneralResources.SelectLabel });

            BankSetupDivisionListModel list = new BankSetupDivisionListModel { BankSetupDivisionList = response.BankSetupDivisionList };
            foreach (var item in list.BankSetupDivisionList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = item.SetupDivision,
                    Value = Convert.ToString(item.BankSetupDivisionId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankSetupDivisionId)
                });
            }
        }
    }
}
