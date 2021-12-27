using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Experts.First_Project.MultiTenancy.Accounting.Dto;

namespace Experts.First_Project.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
