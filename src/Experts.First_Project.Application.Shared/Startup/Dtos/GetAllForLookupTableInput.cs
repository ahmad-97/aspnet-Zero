using Abp.Application.Services.Dto;

namespace Experts.First_Project.Startup.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}