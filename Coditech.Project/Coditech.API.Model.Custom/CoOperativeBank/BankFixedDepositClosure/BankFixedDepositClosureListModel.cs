namespace Coditech.Common.API.Model
{
    public partial class BankFixedDepositClosureListModel : BaseListModel
    {
        public List<BankFixedDepositClosureModel> BankFixedDepositClosureList { get; set; }
        public BankFixedDepositClosureListModel()
        {
            BankFixedDepositClosureList = new List<BankFixedDepositClosureModel>();
        }
    }
}
