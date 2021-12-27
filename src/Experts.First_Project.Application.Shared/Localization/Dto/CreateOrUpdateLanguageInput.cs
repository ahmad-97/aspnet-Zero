using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}