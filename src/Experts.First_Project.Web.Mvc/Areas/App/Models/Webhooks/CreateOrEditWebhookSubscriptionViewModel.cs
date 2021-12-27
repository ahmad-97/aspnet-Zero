using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Experts.First_Project.WebHooks.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
