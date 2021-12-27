using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.MultiTenancy.Payments.Dto;
using Experts.First_Project.MultiTenancy.Payments.Stripe.Dto;

namespace Experts.First_Project.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}