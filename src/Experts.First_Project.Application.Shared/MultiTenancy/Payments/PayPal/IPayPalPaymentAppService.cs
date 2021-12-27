using System.Threading.Tasks;
using Abp.Application.Services;
using Experts.First_Project.MultiTenancy.Payments.PayPal.Dto;

namespace Experts.First_Project.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
