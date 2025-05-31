using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankMemberNomineeService
    {
        BankMemberNomineeListModel GetMemberNomineeList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankMemberNomineeModel CreateMemberNominee(BankMemberNomineeModel model);
        BankMemberNomineeModel GetMemberNominee(int bankMemberId);
        bool UpdateMemberNominee(BankMemberNomineeModel model);
        bool DeleteMemberNominee(ParameterModel parameterModel);
    }
}
