using System.Collections.Generic;
using MvvmHelpers;
using Experts.First_Project.Models.NavigationMenu;

namespace Experts.First_Project.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}