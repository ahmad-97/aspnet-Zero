using System;
using Abp.Application.Services.Dto;

namespace Experts.First_Project.Setup.Dtos
{
    public class CountryDto : EntityDto
    {
        public string Code { get; set; }

        public string Desc { get; set; }

    }
}