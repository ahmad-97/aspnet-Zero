using System;
using Abp.Application.Services.Dto;

namespace Experts.First_Project.Setup.Dtos
{
    public class CityDto : EntityDto
    {
        public string Name { get; set; }

        public int GovernatateId { get; set; }

    }
}