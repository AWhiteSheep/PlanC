using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class CategoriesProgrammes
    {
        public CategoriesProgrammes()
        {
            Programmes = new HashSet<Programmes>();
        }

        [Key]
        [Column("CategorieID")]
        [StringLength(2)]
        public string CategorieId { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Column("TRK_UID")]
        [StringLength(7)]
        public string TrkUid { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [InverseProperty("CodeTypeNavigation")]
        public virtual ICollection<Programmes> Programmes { get; set; }
    }
}
