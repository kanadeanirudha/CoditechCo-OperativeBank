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
        private static void GetBankMemberList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            //if (dropdownViewModel.IsRequired)
            //    dropdownList.Add(new SelectListItem() { Value = "", Text = GeneralResources.SelectLabel });
            //else
            //    dropdownList.Add(new SelectListItem() { Value = "0", Text = GeneralResources.SelectLabel });
            //if (!string.IsNullOrEmpty(dropdownViewModel.Parameter))
            //{
            //    FilterCollection filters = new FilterCollection();
            //    filters.Add(FilterKeys.SelectedCentreCode, ProcedureFilterOperators.Equals, dropdownViewModel.Parameter);

                BankMemberListResponse response = new BankMemberClient().List(null, null, null, 1, int.MaxValue);

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
            //}
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
        private static void GetAccsetupGLList(DropdownViewModel dropdownViewModel, List<SelectListItem> dropdownList)
        {
            AccSetupGLListResponse response = new BankProductClient().GetAccSetupGLList(dropdownViewModel.DropdownType);
            dropdownList.Add(new SelectListItem() { Text = "-------Select City-------" });
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
    }
}
