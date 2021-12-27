using Experts.First_Project.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experts.First_Project.Migrations.Seed.Host
{
  public  class TestEntityDefultDataCreator
    {
        private readonly First_ProjectDbContext _context;
        public TestEntityDefultDataCreator (First_ProjectDbContext context)
        {
            _context = context;
        }

        public void CreateTestData()
        {
            if(_context.TestEntities.Where(x=>x.Description == "InitialData").Count() == 0)
            {
                _context.TestEntities.Add(new Testing.TestEntity() { Description = "InitialData" });
                }
        }

    }
}
