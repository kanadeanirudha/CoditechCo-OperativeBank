namespace Coditech.Common.API.Model
{
    public partial class BankLoanScheduleListModel : BaseListModel
    {
        public List<BankLoanScheduleModel> BankLoanScheduleList { get; set; }
        public BankLoanScheduleListModel()
        {
            BankLoanScheduleList = new List<BankLoanScheduleModel>();
        }
    }
}
