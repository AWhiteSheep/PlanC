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
        [Column("CompetenceID")]
        [StringLength(4)]
        public string CompetenceId { get; set; }
        [Key]
        [Column("ElementCompetenceSQNBR")]
        public byte ElementCompetenceSqnbr { get; set; }
        [Key]
        [Column("CritereElementCompetenceSQNBR")]
        public byte CritereElementCompetenceSqnbr { get; set; }
        public string DescriptionCritere { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime RcdCdttm { get; set; }
        [Required]
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }

        [ForeignKey("CompetenceId,ElementCompetenceSqnbr")]
        [InverseProperty("CriteresElementCompetence")]
        public virtual ElementsCompetence ElementsCompetence { get; set; }
        [InverseProperty("CriteresElementCompetence")]
        public virtual ICollection<CoursCompetenceElements> CoursCompetenceElements { get; set; }
    }
}