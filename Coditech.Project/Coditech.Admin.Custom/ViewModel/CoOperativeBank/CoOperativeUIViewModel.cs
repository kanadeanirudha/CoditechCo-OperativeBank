using Coditech.Common.API.Model;
using System.ComponentModel.DataAnnotations;

namespace Coditech.Admin.ViewModel
{
    public class CoOperativeUIViewModel
    {
        public CoOperativeUIViewModel()
        {
            NavbarList = new List<GeneralEnumaratorModel>();
        }
        public List<GeneralEnumaratorModel> NavbarList { get; set; }
        [Display(Name = "Balance Sheet")]
        public int AccSetupBalanceSheetId { get; set; }
        [Display(Name = "Bank Member")]
        public int BankMemberId { get; set; }
        [Display(Name = "Bank Product")]
        public short BankProductId { get; set; }
        // public string SelectedCentreCode { get; set; }
        public string CentreCode { get; set; }
        public short GeneralFinancialYearId { get; set; }
        public GeneralFinancialYearModel GeneralFinancialYearModel { get; set; }
        public int NavbarEnumId { get; set; }
        public long PersonId { get; set; }
    }
}






























//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace MVC5FullCalandarPlugin.Models
//{
//    public class PublicHoliday
//    {
//        public int Sr { get; set; }
//        public string Title { get; set; }
//        public string Desc { get; set; }
//        public string Start_Date { get; set; }
//        public string End_Date { get; set; }
//    }
//}
