namespace Coditech.Common.API.Model
{
    public partial class BankFixedDepositAccountListModel : BaseListModel
    {
        public List<BankFixedDepositAccountModel> BankFixedDepositAccountList { get; set; }
        public BankFixedDepositAccountListModel()
        {
            BankFixedDepositAccountList = new List<BankFixedDepositAccountModel>();
        }
    }
}
