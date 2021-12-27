using Abp.Application.Services.Dto;

namespace Experts.First_Project.Setup.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}