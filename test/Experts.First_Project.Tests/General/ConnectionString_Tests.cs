using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace Experts.First_Project.Tests.General
{
    // ReSharper disable once InconsistentNaming
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=First_Project; Trusted_Connection=True;");
            csb["Database"].ShouldBe("First_Project");
        }
    }
}
