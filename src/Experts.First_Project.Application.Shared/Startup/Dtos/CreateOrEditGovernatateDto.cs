using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Startup.Dtos
{
    public class CreateOrEditGovernatateDto : EntityDto<int?>
    {

        [Required]
        [StringLength(GovernatateConsts.MaxcodeLength, MinimumLength = GovernatateConsts.MincodeLength)]
        public string code { get; set; }

        [Required]
        [StringLength(GovernatateConsts.MaxNameLength, MinimumLength = GovernatateConsts.MinNameLength)]
        public string Name { get; set; }

    }
}