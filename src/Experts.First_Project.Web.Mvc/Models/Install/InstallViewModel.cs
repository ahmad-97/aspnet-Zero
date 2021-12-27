using System.Collections.Generic;
using Abp.Localization;
using Experts.First_Project.Install.Dto;

namespace Experts.First_Project.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
