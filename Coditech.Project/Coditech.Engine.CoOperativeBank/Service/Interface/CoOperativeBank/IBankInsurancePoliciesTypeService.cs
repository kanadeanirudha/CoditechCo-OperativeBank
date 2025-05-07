﻿using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankInsurancePoliciesTypeService
    {
        BankInsurancePoliciesTypeListModel GetBankInsurancePoliciesTypeList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankInsurancePoliciesTypeModel CreateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel model);
        BankInsurancePoliciesTypeModel GetBankInsurancePoliciesType(short bankInsurancePoliciesTypeId);
        bool UpdateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel model);
        bool DeleteBankInsurancePoliciesType(ParameterModel parameterModel);
    }
}
