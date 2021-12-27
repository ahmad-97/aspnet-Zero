using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.Sessions.Dto;

namespace Experts.First_Project.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
