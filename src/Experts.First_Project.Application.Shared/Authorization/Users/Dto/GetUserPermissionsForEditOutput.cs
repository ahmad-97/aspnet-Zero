using System.Collections.Generic;
using Experts.First_Project.Authorization.Permissions.Dto;

namespace Experts.First_Project.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}