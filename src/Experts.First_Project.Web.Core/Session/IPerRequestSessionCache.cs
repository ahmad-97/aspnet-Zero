using System.Threading.Tasks;
using Experts.First_Project.Sessions.Dto;

namespace Experts.First_Project.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
