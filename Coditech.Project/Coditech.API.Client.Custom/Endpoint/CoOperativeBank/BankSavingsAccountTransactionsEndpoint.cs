using Coditech.Admin.Utilities;
using Coditech.API.Client.Endpoint;
namespace Coditech.API.Endpoint
{
    public class BankSavingsAccountTransactionsEndpoint : BaseEndpoint
    {
        public string CreateBankSavingsAccountTransactionsAsync() =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccountTransactions/CreateBankSavingsAccountTransactions";

        public string GetBankSavingsAccountTransactionsAsync(long bankSavingsAccountId) =>
            $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccountTransactions/GetBankSavingsAccountTransactions?bankSavingsAccountId={bankSavingsAccountId}";

        public string UpdateBankSavingsAccountTransactionsAsync() =>
               $"{CoditechCustomAdminSettings.CoditechCoOperativeBankApiRootUri}/BankSavingsAccountTransactions/UpdateBankSavingsAccountTransactions";
    }
}