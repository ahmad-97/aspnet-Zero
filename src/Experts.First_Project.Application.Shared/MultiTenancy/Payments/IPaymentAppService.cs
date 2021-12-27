using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.MultiTenancy.Dto;
using Experts.First_Project.MultiTenancy.Payments.Dto;
using Abp.Application.Services.Dto;

namespace Experts.First_Project.MultiTenancy.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<PaymentInfoDto> GetPaymentInfo(PaymentInfoInput input);

        Task<long> CreatePayment(CreatePaymentDto input);

        Task CancelPayment(CancelPaymentDto input);

        Task<PagedResultDto<SubscriptionPaymentListDto>> GetPaymentHistory(GetPaymentHistoryInput input);

        List<PaymentGatewayModel> GetActiveGateways(GetActiveGatewaysInput input);

        Task<SubscriptionPaymentDto> GetPaymentAsync(long paymentId);

        Task<SubscriptionPaymentDto> GetLastCompletedPayment();

        Task BuyNowSucceed(long paymentId);

        Task NewRegistrationSucceed(long paymentId);

        Task UpgradeSucceed(long paymentId);

        Task ExtendSucceed(long paymentId);

        Task PaymentFailed(long paymentId);

        Task SwitchBetweenFreeEditions(int upgradeEditionId);

        Task UpgradeSubscriptionCostsLessThenMinAmount(int editionId);

        Task<bool> HasAnyPayment();
    }
}
