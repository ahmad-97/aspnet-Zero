using Abp.Application.Services.Dto;
using System;

namespace Experts.First_Project.Startup.Dtos
{
    public class GetAllGovernatatesForExcelInput
    {
        public string Filter { get; set; }

        public string codeFilter { get; set; }

        public string NameFilter { get; set; }

    }
}