using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Experts.First_Project.Authorization.Permissions.Dto;

namespace Experts.First_Project.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
