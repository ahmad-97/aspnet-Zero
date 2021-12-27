using System.ComponentModel.DataAnnotations;

namespace Experts.First_Project.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}