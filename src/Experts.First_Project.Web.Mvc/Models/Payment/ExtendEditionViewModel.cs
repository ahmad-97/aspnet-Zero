using System.Collections.Generic;
using Experts.First_Project.Editions.Dto;
using Experts.First_Project.MultiTenancy.Payments;

namespace Experts.First_Project.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}