﻿using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankFixedDepositAccountService
    {
        BankFixedDepositAccountListModel GetBankFixedDepositAccountList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankFixedDepositAccountModel CreateBankFixedDepositAccount(BankFixedDepositAccountModel model);
        BankFixedDepositAccountModel GetBankFixedDepositAccount(short bankFixedDepositAccountId);
        bool UpdateBankFixedDepositAccount(BankFixedDepositAccountModel model);
        bool DeleteBankFixedDepositAccount(ParameterModel parameterModel);
    }
}
