using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Startup.Dtos
{
    public class GetGovernatateForEditOutput
    {
        public CreateOrEditGovernatateDto Governatate { get; set; }

    }
}