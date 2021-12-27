using Experts.First_Project.Startup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Experts.First_Project.Setup
{
    [Table("Cities")]
    public class City : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(CityConsts.MaxNameLength, MinimumLength = CityConsts.MinNameLength)]
        public virtual string Name { get; set; }

        public virtual int GovernatateId { get; set; }

        [ForeignKey("GovernatateId")]
        public Governatate GovernatateFk { get; set; }

    }
}