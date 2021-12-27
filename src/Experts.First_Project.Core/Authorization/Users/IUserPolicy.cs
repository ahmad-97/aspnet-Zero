using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Experts.First_Project.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
