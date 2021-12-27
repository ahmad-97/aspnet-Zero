using Abp.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experts.First_Project.Testing
{
    [Audited]
  public  class TestEntity : Entity
    {
        [Required]
        [MaxLength(TestEntityConst.MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
