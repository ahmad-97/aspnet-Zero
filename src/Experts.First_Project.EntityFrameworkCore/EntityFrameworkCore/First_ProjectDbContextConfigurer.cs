using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Experts.First_Project.EntityFrameworkCore
{
    public static class First_ProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<First_ProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<First_ProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}