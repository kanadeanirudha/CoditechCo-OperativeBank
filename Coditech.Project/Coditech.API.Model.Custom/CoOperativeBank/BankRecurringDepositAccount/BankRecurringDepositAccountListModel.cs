namespace Coditech.Common.API.Model
{
    public partial class BankRecurringDepositAccountListModel : BaseListModel
    {
        public List<BankRecurringDepositAccountModel> BankRecurringDepositAccountList { get; set; }
        public BankRecurringDepositAccountListModel()
        {
            BankRecurringDepositAccountList = new List<BankRecurringDepositAccountModel>();
        }
        public string SelectedCentreCode { get; set; }
    }
}
