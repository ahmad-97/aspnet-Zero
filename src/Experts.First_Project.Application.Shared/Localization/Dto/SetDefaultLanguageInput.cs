using System.ComponentModel.DataAnnotations;
using Abp.Localization;

namespace Experts.First_Project.Localization.Dto
{
    public class SetDefaultLanguageInput
    {
        [Required]
        [StringLength(ApplicationLanguage.MaxNameLength)]
        public virtual string Name { get; set; }
    }
}