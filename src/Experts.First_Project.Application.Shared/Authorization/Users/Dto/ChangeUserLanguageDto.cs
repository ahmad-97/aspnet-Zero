using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
