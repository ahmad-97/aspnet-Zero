using Experts.First_Project.MultiTenancy.Payments;

namespace Experts.First_Project.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}