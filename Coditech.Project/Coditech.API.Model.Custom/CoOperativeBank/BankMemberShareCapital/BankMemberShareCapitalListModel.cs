namespace Coditech.Common.API.Model
{
    public partial class BankMemberShareCapitalListModel : BaseListModel
    {
        public List<BankMemberShareCapitalModel> BankMemberShareCapitalList { get; set; }
        public BankMemberShareCapitalListModel()
        {
            BankMemberShareCapitalList = new List<BankMemberShareCapitalModel>();
        }

    }
}
