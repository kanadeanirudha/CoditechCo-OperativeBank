using System.ComponentModel.DataAnnotations;

namespace Coditech.Common.API.Model
{
    public class CoOperativeUIModel : BaseModel
    {
        public CoOperativeUIModel()
        {
        }
        public int AccSetupBalanceSheetId { get; set; }
        public int BankMemberId { get; set; }
        public int NavbarEnumId { get; set; }
        public short BankProductId { get; set; }
        //public string SelectedCentreCode { get; set; }
        public string CentreCode { get; set; }
        public short GeneralFinancialYearId { get; set; }
        public long PersonId { get; set; }
        public GeneralFinancialYearModel GeneralFinancialYearModel { get; set; }
    }
}
