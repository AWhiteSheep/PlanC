﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Pages.Identity.Pages.Models
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            RolesSecretKeys = new HashSet<RolesSecretKeys>();
        }

        [Key]
        public string Id { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<RolesSecretKeys> RolesSecretKeys { get; set; }
    }
}
