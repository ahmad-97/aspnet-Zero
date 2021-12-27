using Microsoft.Extensions.Configuration;

namespace Experts.First_Project.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
