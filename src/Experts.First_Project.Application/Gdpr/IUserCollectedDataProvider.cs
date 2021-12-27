using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Experts.First_Project.Dto;

namespace Experts.First_Project.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
