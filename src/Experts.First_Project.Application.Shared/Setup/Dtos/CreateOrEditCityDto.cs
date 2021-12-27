using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Setup.Dtos
{
    public class CreateOrEditCityDto : EntityDto<int?>
    {

        [Required]
        [StringLength(CityConsts.MaxNameLength, MinimumLength = CityConsts.MinNameLength)]
        public string Name { get; set; }

        public int GovernatateId { get; set; }

    }
}