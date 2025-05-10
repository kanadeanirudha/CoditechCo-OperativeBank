namespace Coditech.Common.API.Model
{
    public partial class BankSavingAccountIntrestPostingsListModel : BaseListModel
    {
        public List<BankSavingAccountIntrestPostingsModel> BankSavingAccountIntrestPostingsList { get; set; }
        public BankSavingAccountIntrestPostingsListModel()
        {
            BankSavingAccountIntrestPostingsList = new List<BankSavingAccountIntrestPostingsModel>();
        }
    }
}
