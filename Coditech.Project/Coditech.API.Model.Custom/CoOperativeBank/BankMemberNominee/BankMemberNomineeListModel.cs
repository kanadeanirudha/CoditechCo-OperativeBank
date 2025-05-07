namespace Coditech.Common.API.Model
{
    public partial class BankMemberNomineeListModel : BaseListModel
    {
        public List<BankMemberNomineeModel> BankMemberNomineeList { get; set; }
        public BankMemberNomineeListModel()
        {
            BankMemberNomineeList = new List<BankMemberNomineeModel>();
        }

    }
}
