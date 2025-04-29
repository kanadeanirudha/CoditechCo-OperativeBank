using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankMemberService
    {
        BankMemberListModel GetBankMemberList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankMemberModel CreateBankMember(BankMemberModel model);
        BankMemberModel GetBankMember(int bankMemberId);
        bool UpdateBankMember(BankMemberModel model);
        bool DeleteBankMember(ParameterModel parameterModel);
    }
}
