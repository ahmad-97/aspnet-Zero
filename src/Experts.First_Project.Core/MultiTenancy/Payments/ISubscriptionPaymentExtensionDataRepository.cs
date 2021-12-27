using System.Threading.Tasks;

namespace Experts.First_Project.MultiTenancy.Payments
{
    public interface ISubscriptionPaymentExtensionDataRepository
    {
        Task<string> GetExtensionDataAsync(long subscriptionPaymentId, string key);

        Task SetExtensionDataAsync(long subscriptionPaymentId, string key, string value);

        Task<long?> GetPaymentIdOrNullAsync(string key, string value);
    }
}
