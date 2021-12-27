using Experts.First_Project.Editions;
using Experts.First_Project.Editions.Dto;
using Experts.First_Project.MultiTenancy.Payments;
using Experts.First_Project.Security;
using Experts.First_Project.MultiTenancy.Payments.Dto;

namespace Experts.First_Project.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
