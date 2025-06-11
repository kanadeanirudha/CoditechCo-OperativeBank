namespace Coditech.Common.API.Model
{
    public partial class BankRecurringDepositInterestPostingListModel : BaseListModel
    {
        public List<BankRecurringDepositInterestPostingModel> BankRecurringDepositInterestPostingList { get; set; }
        public BankRecurringDepositInterestPostingListModel()
        {
            BankRecurringDepositInterestPostingList = new List<BankRecurringDepositInterestPostingModel>();
        }
    }
}
