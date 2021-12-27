using System;
using Abp.Application.Services.Dto;

namespace Experts.First_Project.Startup.Dtos
{
    public class GovernatateDto : EntityDto
    {
        public string code { get; set; }

        public string Name { get; set; }

    }
}