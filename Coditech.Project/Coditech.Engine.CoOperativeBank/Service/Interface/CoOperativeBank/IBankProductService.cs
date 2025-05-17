using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankProductService
    {
        BankProductListModel GetBankProductList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankProductModel CreateBankProduct(BankProductModel model);
        BankProductModel GetBankProduct(short bankProductId);
        bool UpdateBankProduct(BankProductModel model);
        bool DeleteBankProduct(ParameterModel parameterModel);
        AccSetupGLListModel GetAccSetupGLList(string DropdownType);
    }
}
