using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlanC.WebApi.Models;

namespace PlanC.EntityDataModel
{
    [Table("R_SKL_PGM")]
    public class SkillProgrammeRelation
    {
        [Key]
        [Column("PGM_ID")]
        [StringLength(6)]
        public string ProgrammeID { get; set; }
        [Key]
        [Column("DPTMNT_ID")]
        public int DepartmentID { get; set; }
        [Key]
        [Column("SKL_ID")]
        [StringLength(4)]
        public string SkillID { get; set; }

        [ForeignKey(nameof(SkillID))]
        [InverseProperty(nameof(Skill.Id))]
        public virtual Skill Skl { get; set; }
        [ForeignKey("ProgrammeID,DepartmentID")]
        [InverseProperty("SkillProgramRelation")]
        public virtual Tpgm Tpgm { get; set; }
    }
}
