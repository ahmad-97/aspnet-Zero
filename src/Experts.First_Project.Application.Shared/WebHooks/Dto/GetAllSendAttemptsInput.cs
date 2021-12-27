using Experts.First_Project.Dto;

namespace Experts.First_Project.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}
