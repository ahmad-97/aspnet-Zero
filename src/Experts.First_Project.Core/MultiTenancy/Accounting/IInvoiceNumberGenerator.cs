using System.Threading.Tasks;
using Abp.Dependency;

namespace Experts.First_Project.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}