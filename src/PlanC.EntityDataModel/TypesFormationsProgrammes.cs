using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class TypesFormationsProgrammes
    {
        public TypesFormationsProgrammes()
        {
            Programmes = new HashSet<Programmes>();
        }

        [Key]
        [Column("ID")]
        [StringLength(3)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(60)]
        public string Designation { get; set; }

        [InverseProperty("TypeDegreFormationNavigation")]
        public virtual ICollection<Programmes> Programmes { get; set; }
    }
}
