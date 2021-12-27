using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experts.First_Project.Testing
{
   public class TestCreationEntity : CreationAuditedEntity
    {
        public string Description { get; set; }
    }
}
