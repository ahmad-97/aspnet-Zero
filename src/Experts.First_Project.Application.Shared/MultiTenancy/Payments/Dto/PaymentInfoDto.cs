using Experts.First_Project.Editions.Dto;

namespace Experts.First_Project.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < First_ProjectConsts.MinimumUpgradePaymentAmount;
        }
    }
}
