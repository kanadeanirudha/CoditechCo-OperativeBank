namespace Coditech.Common.API.Model
{
    public partial class BankMemberListModel : BaseListModel
    {
        public List<BankMemberModel> BankMemberList { get; set; }
        public BankMemberListModel()
        {
            BankMemberList = new List<BankMemberModel>();
        }
    }
}
