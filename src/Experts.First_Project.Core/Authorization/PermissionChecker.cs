using Abp.Authorization;
using Experts.First_Project.Authorization.Roles;
using Experts.First_Project.Authorization.Users;

namespace Experts.First_Project.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
