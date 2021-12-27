using Abp.AspNetCore.Mvc.Authorization;
using Experts.First_Project.Authorization;
using Experts.First_Project.Storage;
using Abp.BackgroundJobs;

namespace Experts.First_Project.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}