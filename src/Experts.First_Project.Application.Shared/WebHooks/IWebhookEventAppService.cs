using System.Threading.Tasks;
using Abp.Webhooks;

namespace Experts.First_Project.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
