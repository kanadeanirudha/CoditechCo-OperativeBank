using Coditech.Resources;
using System.ComponentModel.DataAnnotations;

namespace Coditech.Admin.ViewModel
{
    public class MemberCreateEditViewModel : GeneralPersonViewModel
    {
        public MemberCreateEditViewModel()
        {
        }
        [Required]
        [Display(Name = "LabelCentre", ResourceType = typeof(AdminResources))]
        public string SelectedCentreCode { get; set; }
        public int BankMemberId { get; set; }
    }
}
