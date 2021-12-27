using System.Collections.Generic;
using Experts.First_Project.Authorization.Delegation;
using Experts.First_Project.Authorization.Users.Delegation.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
