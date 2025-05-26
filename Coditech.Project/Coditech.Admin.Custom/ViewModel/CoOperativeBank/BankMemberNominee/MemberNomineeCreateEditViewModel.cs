using Coditech.Resources;
using System.ComponentModel.DataAnnotations;

namespace Coditech.Admin.ViewModel
{
    public class MemberNomineeCreateEditViewModel : GeneralPersonViewModel
    {
        public MemberNomineeCreateEditViewModel()
        {
        }
        [Required]
        [Display(Name = "LabelCentre", ResourceType = typeof(AdminResources))]
        public string SelectedCentreCode { get; set; }
        public int BankMemberNomineeId { get; set; }
    }
}
