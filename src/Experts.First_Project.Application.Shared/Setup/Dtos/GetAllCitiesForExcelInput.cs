﻿using Abp.Application.Services.Dto;
using System;

namespace Experts.First_Project.Setup.Dtos
{
    public class GetAllCitiesForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string GovernatateNameFilter { get; set; }

    }
}