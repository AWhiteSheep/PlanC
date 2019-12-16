using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlanC.EntityDataModel
{
    public partial class DisponibilitesUtilisateur : RecurrenceData
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

        [IgnoreDataMember]
        [ForeignKey(nameof(Uid))]
        [InverseProperty(nameof(AspNetUsers.DisponibilitesUtilisateur))]
        public virtual AspNetUsers U { get; set; }

        public DateTime? StartTime
        {
            get
            {
                return RcdCdttm.GetValueOrDefault(DateTime.Now.Date).Add(AvlStm);
            }
            set
            {
                if (value != null)
                    AvlStm = value.Value.TimeOfDay;
            }
        }

        public DateTime? EndTime
        {
            get
            {
                return RcdCdttm.GetValueOrDefault(DateTime.Now.Date).Add(AvlNtm);
            }
            set
            {
                if(value != null)
                    AvlNtm = value.Value.TimeOfDay;
            }
        }

        [NotMapped]
        public string DayOfWeekString
        {
            get
            {
                return WeekdayNbr.ToString();
            }
            set
            {
                WeekdayNbr = int.Parse(value);
            }
        }

        [NotMapped]
        public string DayOfWeekHumanLangageFR
        {
            get
            {
                switch (WeekdayNbr)
                {
                    case 0:
                        return "Dimanche";
                    case 1:
                        return "Lundi";
                    case 2:
                        return "Mardi";
                    case 3:
                        return "Mercredi";
                    case 4:
                        return "Jeudi";
                    case 5:
                        return "Vendredi";
                    default:
                        return "Samedi";
                }
            }
        }
    }
    public class RecurrenceData
    {
        public static string GetRecurenceRule(int DayNumber)
        {
            var recurenceRules = "FREQ=WEEKLY;INTERVAL=1;BYDAY=";
            switch (DayNumber)
            {
                case 0:
                    return recurenceRules += "SU";
                case 1:
                    return recurenceRules += "MO";
                case 2:
                    return recurenceRules += "TU";
                case 3:
                    return recurenceRules += "WE";
                case 4:
                    return recurenceRules += "TH";
                case 5:
                    return recurenceRules += "FR";
                default:
                    return recurenceRules += "SA";
            }
        }

        // des valeurs de plus si jamais
        public string Subject { get; set; } = "Disponible";
        public string Location { get; set; }
        public string Description { get; set; }
    }

}
