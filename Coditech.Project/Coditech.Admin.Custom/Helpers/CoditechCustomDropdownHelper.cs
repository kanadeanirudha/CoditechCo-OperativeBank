using Coditech.Admin.ViewModel;
using Coditech.API.Client;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Coditech.Common.Helper.Utilities
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

            dropdownViewModel.DropdownList = dropdownList;
            return dropdownViewModel;
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
