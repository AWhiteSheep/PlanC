using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.EntityDataModel
{
    public partial class DisponibilitesUtilisateur
    {
        [Key]
        [Column("UID")]
        [StringLength(7)]        
        public string Uid { get; set; } // id utilisateur
        [Key]
        [Column("USER_AVL_SQNBR")]
        public int UserAvlSqnbr { get; set; } // sqnbre de la disponibilité
        [Column("WEEKDAY_NBR")]
        public int WeekdayNbr { get; set; } //  week day specifier
        [Column("AVL_STM")]
        public TimeSpan AvlStm { get; set; } // time spam ? du start?
        [Column("AVL_NTM")]
        public TimeSpan AvlNtm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; } // date mis en charge
        [StringLength(50)]
        public string RecurrenceRule { get; set; }

        [ForeignKey(nameof(Uid))]
        [InverseProperty(nameof(AspNetUsers.DisponibilitesUtilisateur))]
        public virtual AspNetUsers U { get; set; }
    }
}
