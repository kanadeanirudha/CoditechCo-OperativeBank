namespace Coditech.Common.API.Model
{
    public partial class BankProductListModel : BaseListModel
    {
        public List<BankProductModel> BankProductList { get; set; }
        public BankProductListModel()
        {
            BankProductList = new List<BankProductModel>();
        }
    }
}
