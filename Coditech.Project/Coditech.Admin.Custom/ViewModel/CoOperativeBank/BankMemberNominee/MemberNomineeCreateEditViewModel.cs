using Coditech.Resources;
using System.ComponentModel.DataAnnotations;

namespace Coditech.Admin.ViewModel
{
    public class MemberNomineeCreateEditViewModel : GeneralPersonViewModel
    {
        public MemberNomineeCreateEditViewModel()
        {
        }
        
        public int BankMemberNomineeId { get; set; }
    }
}
