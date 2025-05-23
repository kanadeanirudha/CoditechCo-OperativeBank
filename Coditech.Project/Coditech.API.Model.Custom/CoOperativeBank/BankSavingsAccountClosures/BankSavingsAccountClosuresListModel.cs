namespace Coditech.Common.API.Model
{
    public partial class BankSavingsAccountClosuresListModel : BaseListModel
    {
        public List<BankSavingsAccountClosuresModel> BankSavingsAccountClosuresList { get; set; }
        public BankSavingsAccountClosuresListModel()
        {
            BankSavingsAccountClosuresList = new List<BankSavingsAccountClosuresModel>();
        }
    }
}
