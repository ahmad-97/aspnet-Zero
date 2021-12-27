using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Experts.First_Project.Configuration;
using Experts.First_Project.Web;

namespace Experts.First_Project.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class First_ProjectDbContextFactory : IDesignTimeDbContextFactory<First_ProjectDbContext>
    {
        public First_ProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<First_ProjectDbContext>();

            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            First_ProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(First_ProjectConsts.ConnectionStringName));

            return new First_ProjectDbContext(builder.Options);
        }
    }
}
