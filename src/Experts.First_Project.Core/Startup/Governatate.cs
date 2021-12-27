using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Experts.First_Project.Startup
{
    [Table("Governatates")]
    public class Governatate : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(GovernatateConsts.MaxcodeLength, MinimumLength = GovernatateConsts.MincodeLength)]
        public virtual string code { get; set; }

        [Required]
        [StringLength(GovernatateConsts.MaxNameLength, MinimumLength = GovernatateConsts.MinNameLength)]
        public virtual string Name { get; set; }

    }
}