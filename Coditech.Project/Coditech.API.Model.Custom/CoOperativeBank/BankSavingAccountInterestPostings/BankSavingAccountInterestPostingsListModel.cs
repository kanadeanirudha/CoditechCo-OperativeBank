namespace Coditech.Common.API.Model
{
    public partial class BankSavingAccountInterestPostingsListModel : BaseListModel
    {
        public List<BankSavingAccountInterestPostingsModel> BankSavingAccountInterestPostingsList { get; set; }
        public BankSavingAccountInterestPostingsListModel()
        {
            BankSavingAccountInterestPostingsList = new List<BankSavingAccountInterestPostingsModel>();
        }
    }
}
