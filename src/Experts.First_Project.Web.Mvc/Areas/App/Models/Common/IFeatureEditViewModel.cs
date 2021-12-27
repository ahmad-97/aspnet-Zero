using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Experts.First_Project.Editions.Dto;

namespace Experts.First_Project.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}