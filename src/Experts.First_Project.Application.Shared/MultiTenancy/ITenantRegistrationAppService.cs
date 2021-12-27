using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.Editions.Dto;
using Experts.First_Project.MultiTenancy.Dto;

namespace Experts.First_Project.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}