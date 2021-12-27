using Experts.First_Project.EntityFrameworkCore;

namespace Experts.First_Project.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly First_ProjectDbContext _context;

        public InitialHostDbBuilder(First_ProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new TestEntityDefultDataCreator(_context).CreateTestData();

            _context.SaveChanges();
        }
    }
}
