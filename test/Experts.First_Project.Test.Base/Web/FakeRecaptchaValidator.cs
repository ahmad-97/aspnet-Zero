using System.Threading.Tasks;
using Experts.First_Project.Security.Recaptcha;

namespace Experts.First_Project.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
