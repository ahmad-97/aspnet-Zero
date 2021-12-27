using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}