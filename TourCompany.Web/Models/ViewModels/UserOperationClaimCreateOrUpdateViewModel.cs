using Core.Entities.Concrete;
using Entities.Concrete;

namespace TourCompany.Web.Models.ViewModels
{
    public class UserOperationClaimCreateOrUpdateViewModel
    {
        public UserOperationClaimCreateOrUpdateViewModel() => Claims = new List<OperationClaim>();

        public int UserId { get; set; } 

        public string[] SelectedClaims { get; set; }

        public ICollection<OperationClaim> Claims { get; set; }
    }
}
