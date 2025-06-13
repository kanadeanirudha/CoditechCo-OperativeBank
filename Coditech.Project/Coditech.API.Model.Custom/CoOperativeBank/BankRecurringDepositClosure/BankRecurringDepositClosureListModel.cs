namespace Coditech.Common.API.Model
{
    public partial class BankRecurringDepositClosureListModel : BaseListModel
    {
        public List<BankRecurringDepositClosureModel> BankRecurringDepositClosureList { get; set; }
        public BankRecurringDepositClosureListModel()
        {
            BankRecurringDepositClosureList = new List<BankRecurringDepositClosureModel>();
        }
    }
}
