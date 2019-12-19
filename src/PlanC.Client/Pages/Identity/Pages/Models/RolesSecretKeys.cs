using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Pages.Identity.Pages.Models
{
    public partial class RolesSecretKeys
    {
        [Key]
        public string Key { get; set; }
        [Required]
        [StringLength(450)]
        public string RoleId { get; set; }
        public int LifeSpan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateGenerated { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspNetRoles.RolesSecretKeys))]
        public virtual AspNetRoles Role { get; set; }
    }
}
