using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace Experts.First_Project.Testing
{
   public class TestAuditedEntity: AuditedEntity
    {
        public string Descrtipeion { get; set; }
    }
}
