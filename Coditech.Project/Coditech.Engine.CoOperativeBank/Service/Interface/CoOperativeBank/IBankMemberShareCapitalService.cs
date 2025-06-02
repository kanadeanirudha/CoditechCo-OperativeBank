using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankMemberShareCapitalService
    {
        BankMemberShareCapitalListModel GetMemberShareCapitalList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankMemberShareCapitalModel CreateMemberShareCapital(BankMemberShareCapitalModel model);
        BankMemberShareCapitalModel GetMemberShareCapital(int bankMemberId);
        bool UpdateMemberShareCapital(BankMemberShareCapitalModel model);
        bool DeleteMemberShareCapital(ParameterModel parameterModel);
    }
}
