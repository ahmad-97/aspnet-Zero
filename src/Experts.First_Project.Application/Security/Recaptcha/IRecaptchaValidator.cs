using System.Threading.Tasks;

namespace Experts.First_Project.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}