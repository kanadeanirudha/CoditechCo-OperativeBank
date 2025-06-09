using Coditech.Common.API.Model;
namespace Coditech.API.Service
{
    public interface IBankLoanScheduleService
    {
        BankLoanScheduleModel CreateBankLoanSchedule(BankLoanScheduleModel model);
        BankLoanScheduleModel GetBankLoanSchedule(int bankPostingLoanAccountId);
        bool UpdateBankLoanSchedule(BankLoanScheduleModel model);
    }
}
