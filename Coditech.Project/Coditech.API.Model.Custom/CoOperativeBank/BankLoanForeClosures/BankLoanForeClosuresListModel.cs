namespace Coditech.Common.API.Model
{
    public partial class BankLoanForeClosuresListModel : BaseListModel
    {
        public List<BankLoanForeClosuresModel> BankLoanForeClosuresList { get; set; }
        public BankLoanForeClosuresListModel()
        {
            BankLoanForeClosuresList = new List<BankLoanForeClosuresModel>();
        }
    }
}
