using System.Collections.Generic;
using Experts.First_Project.Authorization.Permissions.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}