using Abp.Application.Services.Dto;
using System;

namespace Experts.First_Project.Setup.Dtos
{
    public class GetAllCountriesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string CodeFilter { get; set; }

        public string DescFilter { get; set; }

    }
}