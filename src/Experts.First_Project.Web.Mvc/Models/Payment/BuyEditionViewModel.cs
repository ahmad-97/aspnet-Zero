using System.Collections.Generic;
using Experts.First_Project.Editions;
using Experts.First_Project.Editions.Dto;
using Experts.First_Project.MultiTenancy.Payments;
using Experts.First_Project.MultiTenancy.Payments.Dto;

namespace Experts.First_Project.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
