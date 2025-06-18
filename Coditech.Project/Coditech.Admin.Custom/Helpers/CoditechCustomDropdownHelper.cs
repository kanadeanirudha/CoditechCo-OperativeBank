using Coditech.Admin.Utilities;
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
        public static List<UserAccessibleCentreModel> AccessibleCentreList()
        {
            return SessionHelper.GetDataFromSession<UserModel>(AdminConstants.UserDataSession)?.AccessibleCentreList;
        }
        public static List<UserBalanceSheetModel> BindAccountBalanceSheetIdByCentreCodeList()
        {
            return SessionHelper.GetDataFromSession<UserModel>(AdminConstants.UserDataSession)?.BalanceSheetList;
        }
        public static DropdownViewModel GeneralDropdownList(DropdownViewModel dropdownViewModel)
        {
            List<SelectListItem> dropdownList = new List<SelectListItem>();
            if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankSetupDivision.ToString()))
            {
                GetBankSetupDivisionList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankMembers.ToString()))
            {
                GetBankMemberListByCentreCode(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankSavingsAccount.ToString()))
            {
                GetBankSavingsAccountList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankMemberNominee.ToString()))
            {
                GetBankMemberNomineeList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.GetAccSetupGL.ToString()))
            {
                GetAccsetupList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.InteresetPayableGLAccount.ToString()))
            {
                GetAccInteresetPayableGLAccountList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.InteresetReceivableGLAccount.ToString()))
            {
                GetAccInteresetReceivableGLAccountList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankProduct.ToString()))
            {
                GetBankProductList(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.TenureMonths.ToString()))
            {
                GetTenureMonthsDropdown(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.TenureYears.ToString()))
            {
                GetTenureYearsDropdown(dropdownViewModel, dropdownList);
            }
            else if (Equals(dropdownViewModel.DropdownType, DropdownCustomTypeEnum.BankProducts.ToString()))
            {
                GetBankproductList(dropdownViewModel, dropdownList);
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
        private static void GetBankMemberListByCentreCode(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            if (dropdownViewModel.IsRequired)
                dropdownList.Add(new SelectListItem() { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem() { Value = "0", Text = GeneralResources.SelectLabel });
            if (!string.IsNullOrEmpty(dropdownViewModel.Parameter))
            {
                FilterCollection filters = new FilterCollection();
                filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dropdownViewModel.Parameter);

                BankMemberListResponse response = new BankMemberClient().List(null, filters, null, 1, int.MaxValue);

                BankMemberListModel list = new BankMemberListModel { BankMemberList = response?.BankMemberList };
                foreach (var item in list?.BankMemberList)
                {
                    dropdownList.Add(new SelectListItem()
                    {
                        Text = $"{item.FirstName} {item.LastName}",
                        Value = item.BankMemberId.ToString(),
                        Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankMemberId)
                    });
                }
            }
        }         
        private static void GetBankProductList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            if (dropdownViewModel.IsRequired)
                dropdownList.Add(new SelectListItem() { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem() { Value = "0", Text = GeneralResources.SelectLabel });
            if (!string.IsNullOrEmpty(dropdownViewModel.Parameter))
            {
                FilterCollection filters = new FilterCollection();
                filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dropdownViewModel.Parameter);
                filters.Add("AccountTypeEnumId", ProcedureFilterOperators.Equals, "263");
                BankProductListResponse response = new BankProductClient().List(null, filters, null, 1, int.MaxValue);
                BankProductListModel list = new BankProductListModel { BankProductList = response.BankProductList };
                foreach (var item in list.BankProductList)
                {
                    dropdownList.Add(new SelectListItem()
                    {
                        Text = item.ProductName,
                        Value = Convert.ToString(item.BankProductId),
                        Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankProductId)
                    });
                }
            }
        }
        private static void GetBankSavingsAccountList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            BankSavingsAccountListResponse response = new BankSavingsAccountClient().List(null, null, null, 1, int.MaxValue);
            if (dropdownViewModel.IsRequired)
                dropdownList.Add(new SelectListItem() { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem() { Value = "0", Text = GeneralResources.SelectLabel });

            BankSavingsAccountListModel list = new BankSavingsAccountListModel { BankSavingsAccountList = response.BankSavingsAccountList };
            foreach (var item in list.BankSavingsAccountList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = item.SavingAccountNumber,
                    Value = Convert.ToString(item.BankSavingsAccountId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankSavingsAccountId)
                });
            }
        }
        private static void GetBankMemberNomineeList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            BankMemberNomineeListResponse response = new BankMemberNomineeClient().List(null, null, null, 1, int.MaxValue);
            if (dropdownViewModel.IsRequired)
                dropdownList.Add(new SelectListItem() { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem() { Value = "0", Text = GeneralResources.SelectLabel });

            BankMemberNomineeListModel list = new BankMemberNomineeListModel { BankMemberNomineeList = response.BankMemberNomineeList };
            foreach (var item in list.BankMemberNomineeList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = $"{item.FirstName} {item.LastName}",
                    Value = Convert.ToString(item.BankMemberNomineeId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankMemberNomineeId)
                });
            }
        }
        private static void GetAccsetupList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            AccSetupGLListResponse response = new BankProductClient().GetAccSetupGLList(dropdownViewModel.DropdownType);
            dropdownList.Add(new SelectListItem() { Text = "-------Select GL Mapper Account-------" });
            AccSetupGLListModel list = new AccSetupGLListModel { AccSetupGLList = response?.AccSetupGLList };
            foreach (var item in list.AccSetupGLList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = item.GLName,
                    Value = Convert.ToString(item.AccSetupGLId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.AccSetupGLId)
                });
            }
        }
        private static void GetAccInteresetPayableGLAccountList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            AccSetupGLListResponse response = new BankProductClient().GetAccSetupGLList(dropdownViewModel.DropdownType);
            dropdownList.Add(new SelectListItem() { Text = "-------Select Payable GL Account-------" });
            AccSetupGLListModel list = new AccSetupGLListModel { AccSetupGLList = response?.AccSetupGLList };
            foreach (var item in list.AccSetupGLList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = item.GLName,
                    Value = Convert.ToString(item.AccSetupGLId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.AccSetupGLId)
                });
            }
        }
        private static void GetAccInteresetReceivableGLAccountList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            AccSetupGLListResponse response = new BankProductClient().GetAccSetupGLList(dropdownViewModel.DropdownType);
            dropdownList.Add(new SelectListItem() { Text = "-------Select Receivable GL Account-------" });
            AccSetupGLListModel list = new AccSetupGLListModel { AccSetupGLList = response?.AccSetupGLList };
            foreach (var item in list.AccSetupGLList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = item.GLName,
                    Value = Convert.ToString(item.AccSetupGLId),
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.AccSetupGLId)
                });
            }
        }
        public static void GetTenureMonthsDropdown(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            bool isRequired = true;
            if (isRequired)
                dropdownList.Add(new SelectListItem { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem { Value = "0", Text = GeneralResources.SelectLabel });

            for (int i = 0; i <= 11; i++)
            {
                dropdownList.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i + " Month" + (i != 1 ? "s" : ""),
                    Selected = dropdownViewModel.DropdownSelectedValue == i.ToString()  
                });
            }
        }
        public static void GetTenureYearsDropdown(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            bool isRequired = true;
            if (isRequired)
                dropdownList.Add(new SelectListItem { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem { Value = "0", Text = GeneralResources.SelectLabel });

            for (int i = 1; i <= 40; i++)
            {
                dropdownList.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i + " Year" + (i != 1 ? "s" : ""),
                    Selected = dropdownViewModel.DropdownSelectedValue == i.ToString() 
                });
            }
        }
        private static void GetBankproductList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            if (dropdownViewModel.IsRequired)
                dropdownList.Add(new SelectListItem() { Value = "", Text = GeneralResources.SelectLabel });
            else
                dropdownList.Add(new SelectListItem() { Value = "0", Text = GeneralResources.SelectLabel });
            if (!string.IsNullOrEmpty(dropdownViewModel.Parameter))
            {
                FilterCollection filters = new FilterCollection();
                filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dropdownViewModel.Parameter);

                BankProductListResponse response = new BankProductClient().List(null, filters, null, 1, int.MaxValue);

                BankProductListModel list = new BankProductListModel { BankProductList = response.BankProductList };
                foreach (var item in list.BankProductList)
                {
                    dropdownList.Add(new SelectListItem()
                    {
                        Text = item.ProductName,
                        Value = Convert.ToString(item.BankProductId),
                        Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.BankProductId)
                    });
                }
            }
        }
        private static void GetAccessibleCentreList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            List<UserAccessibleCentreModel> accessibleCentreList = AccessibleCentreList();
            if (accessibleCentreList?.Count == 1)
                dropdownViewModel.DropdownSelectedValue = accessibleCentreList.FirstOrDefault().CentreCode;
            else
                dropdownList.Add(new SelectListItem() { Text = "-------Select Centre-------", Value = "" });

            foreach (var item in accessibleCentreList)
            {
                dropdownList.Add(new SelectListItem()
                {
                    Text = item.CentreName,
                    Value = item.CentreCode,
                    Selected = dropdownViewModel.DropdownSelectedValue == Convert.ToString(item.CentreCode)
                });
            }
        }
    }  
    
}
