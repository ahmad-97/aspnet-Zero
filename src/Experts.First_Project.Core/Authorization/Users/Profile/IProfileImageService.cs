using Abp;
using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Experts.First_Project.Authorization.Users.Profile
{
    public interface IProfileImageService : IDomainService
    {
        Task<string> GetProfilePictureContentForUser(UserIdentifier userIdentifier);
    }
}