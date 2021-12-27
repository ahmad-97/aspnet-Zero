using System.Threading.Tasks;
using Experts.First_Project.Authorization.Users;

namespace Experts.First_Project.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
