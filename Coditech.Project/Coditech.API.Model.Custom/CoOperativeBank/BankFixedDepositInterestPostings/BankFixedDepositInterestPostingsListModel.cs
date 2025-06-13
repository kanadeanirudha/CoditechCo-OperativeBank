namespace Coditech.Common.API.Model
{
    public partial class BankFixedDepositInterestPostingsListModel : BaseListModel
    {
        public List<BankFixedDepositInterestPostingsModel> BankFixedDepositInterestPostingsList { get; set; }
        public BankFixedDepositInterestPostingsListModel()
        {
            BankFixedDepositInterestPostingsList = new List<BankFixedDepositInterestPostingsModel>();
        }
    }
}
