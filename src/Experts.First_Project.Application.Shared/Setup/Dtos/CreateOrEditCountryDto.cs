using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Setup.Dtos
{
    public class CreateOrEditCountryDto : EntityDto<int?>
    {

        [Required]
        [StringLength(CountryConsts.MaxCodeLength, MinimumLength = CountryConsts.MinCodeLength)]
        public string Code { get; set; }

        [Required]
        public string Desc { get; set; }

    }
}