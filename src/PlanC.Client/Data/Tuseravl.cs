using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanC.Client.Data
{
    [Table("TUSERAVL")]
    public partial class Tuseravl
    {
        [Key]
        [Column("UID")]
        [StringLength(7)]
        public string Uid { get; set; }
        [Key]
        [Column("USER_AVL_SQNBR")]
        public int UserAvlSqnbr { get; set; }
        [Column("WEEKDAY_NBR")]
        public int WeekdayNbr { get; set; }
        [Column("AVL_STM")]
        public TimeSpan AvlStm { get; set; }
        [Column("AVL_NTM")]
        public TimeSpan AvlNtm { get; set; }
        [Column("RCD_CDTTM", TypeName = "datetime")]
        public DateTime? RcdCdttm { get; set; }

        [ForeignKey(nameof(Uid))]
        [InverseProperty(nameof(Tuser.Tuseravl))]
        public virtual Tuser U { get; set; }
    }
}
