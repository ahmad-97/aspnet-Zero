using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Setup.Dtos
{
    public class GetCityForEditOutput
    {
        public CreateOrEditCityDto City { get; set; }

        public string GovernatateName { get; set; }

    }
}