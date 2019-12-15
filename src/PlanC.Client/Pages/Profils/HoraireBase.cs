using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PlanC.EntityDataModel;
using PlanC.Client.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Blazor.Schedule;

namespace PlanC.Client.Pages.Profils
{
    public class HoraireBase : ComponentBase
    {
        [CascadingParameter]
        public AspNetUsers Utilisateur { get; set; }
        [Inject]
        public PCU001Context _context { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public EjsSchedule<RecurrenceData> schedule { get; set; }
        // jour de la semaine contenant les heures de disponibilités
        public List<RecurrenceData> ListDayTimeSpans { get; set; }
        // model pour la journée
        public class RecurrenceData : DisponibilitesUtilisateur
        {
            [Required]
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

            public DateTime? StartTime 
            {
                get {
                    return RcdCdttm.GetValueOrDefault(DateTime.Now.Date).Add(AvlStm);
                }
                set {
                    AvlStm = value.Value.TimeOfDay;
                }
            }
            public DateTime? EndTime
            {
                get {
                    return RcdCdttm.GetValueOrDefault(DateTime.Now.Date).Add(AvlNtm);
                }
                set {
                    AvlNtm = value.Value.TimeOfDay;
                }
            }
            // des valeurs de plus si jamais
            public string Subject { get; set; } = "Disponible";
            public Nullable<bool> IsAllDay { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string CategoryColor { get; set; }
            public Nullable<int> RecurrenceID { get; set; }
            public string RecurrenceException { get; set; }
            public string StartTimezone { get; set; }
            public string EndTimezone { get; set; }
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            RefreshDisponibilities();
        }

        public void SaveProgress()
        {
            try
            {
                _context.SaveChanges();
                StateHasChanged();
            }
            catch (Exception except)
            {
                Console.WriteLine($"Plan cadre liste error: {except.Message}");
            }
        }

        public void RefreshDisponibilities() 
        {
            var usName = Utilisateur.UserName;
            // get the user and the reference to its list of disponibilities
            Utilisateur = _context.AspNetUsers
                .Include(e => e.DisponibilitesUtilisateur).First(u => u.UserName == usName);
            ListDayTimeSpans = new List<RecurrenceData>();
            // reset the list to initial state
            foreach (var disponibility in Utilisateur.DisponibilitesUtilisateur) 
            {
                // ajoute à la liste la nouvelle disponibilité en ajoutant les valeurs manquante pour faire l'affichage
                ListDayTimeSpans.Add(disponibility as RecurrenceData);
                ListDayTimeSpans.Last().RecurrenceRule = RecurrenceData.GetRecurenceRule(disponibility.WeekdayNbr);
            }
        }
    }
}
