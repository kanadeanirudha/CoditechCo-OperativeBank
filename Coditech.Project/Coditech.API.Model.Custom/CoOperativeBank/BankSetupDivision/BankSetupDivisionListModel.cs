namespace Coditech.Common.API.Model
{
    public partial class BankSetupDivisionListModel : BaseListModel
    {
        public List<BankSetupDivisionModel> BankSetupDivisionList { get; set; }
        public BankSetupDivisionListModel()
        {
            BankSetupDivisionList = new List<BankSetupDivisionModel>();
        }
    }
}
