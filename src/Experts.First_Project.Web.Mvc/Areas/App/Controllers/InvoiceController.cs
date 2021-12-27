using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Experts.First_Project.MultiTenancy.Accounting;
using Experts.First_Project.Web.Areas.App.Models.Accounting;
using Experts.First_Project.Web.Controllers;

namespace Experts.First_Project.Web.Areas.App.Controllers
{
    [Area("App")]
    public class InvoiceController : First_ProjectControllerBase
    {
        private readonly IInvoiceAppService _invoiceAppService;

        public InvoiceController(IInvoiceAppService invoiceAppService)
        {
            _invoiceAppService = invoiceAppService;
        }


        [HttpGet]
        public async Task<ActionResult> Index(long paymentId)
        {
            var invoice = await _invoiceAppService.GetInvoiceInfo(new EntityDto<long>(paymentId));
            var model = new InvoiceViewModel
            {
                Invoice = invoice
            };

            return View(model);
        }
    }
}