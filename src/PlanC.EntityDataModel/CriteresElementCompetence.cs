﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CriteresElementCompetence
    {
        public CriteresElementCompetence()
        {
            CoursCompetenceElements = new HashSet<CoursCompetenceElements>();
        }

        [Key]
        public int IdentityKey { get; set; }
        [Required]
        [StringLength(100)]
        public string ElementCompetenceId { get; set; }
        [Column("CritereElementCompetenceSQNBR")]
        public int CritereElementCompetenceSqnbr { get; set; }
        public string DescriptionCritere { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime RcdCdttm { get; set; }
        [Required]
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey(nameof(ElementCompetenceId))]
        [InverseProperty(nameof(ElementsCompetence.CriteresElementCompetence))]
        public virtual ElementsCompetence ElementCompetence { get; set; }
        [InverseProperty("IdentityCritereElementCompetenceNavigation")]
        public virtual ICollection<CoursCompetenceElements> CoursCompetenceElements { get; set; }
    }
}