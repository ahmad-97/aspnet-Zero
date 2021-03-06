using System.Threading.Tasks;
using Abp.Authorization.Users;
using Experts.First_Project.Authorization.Users;

namespace Experts.First_Project.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
