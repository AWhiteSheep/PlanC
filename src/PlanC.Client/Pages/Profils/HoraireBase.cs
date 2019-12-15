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
        public EjsSchedule<InputDayModel> schedule { get; set; }
        public List<DisponibilitesUtilisateur> UserDisponibilities;
        // jour de la semaine contenant les heures de disponibilités
        public List<InputDayModel> ListDayTimeSpans = new List<InputDayModel>();
        // model pour la journée
        public class InputDayModel : RecurrenceData
        {                        
            public int UserAvlSqnbr { get; set; }
            // validation pour un téléphone
            [Required]
            public int DayOfWeekInstanceDay { get; set; }

            public string DayOfWeekString 
            {
                get {
                    return DayOfWeekInstanceDay.ToString();
                }
                set {
                    DayOfWeekInstanceDay = int.Parse(value);
                }
            }
            public string DayOfWeekHumanLangageFR
            {
                get
                {
                    switch (DayOfWeekInstanceDay)
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
        }
        public class RecurrenceData
        {
            public string Subject { get; set; } = "Disponible";
            [Required]
            public DateTime? StartTime { get; set; }
            [Required]
            public DateTime? EndTime { get; set; }
            [Required]
            public DateTime? DateOfValidaty { get; set; }
            public Nullable<bool> IsAllDay { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string RecurrenceRule { get; set; } = "FREQ=WEEKLY;INTERVAL=1;BYDAY=MO";
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
            Utilisateur = _context.AspNetUsers.Include(e => e.DisponibilitesUtilisateur).First(u => u.UserName == usName);
            UserDisponibilities = Utilisateur.DisponibilitesUtilisateur.ToList();
            ListDayTimeSpans = new List<InputDayModel>(); // reset the list to initial state
            foreach (var disponibility in UserDisponibilities)
            {
                var userDayOfWeek = disponibility.RcdCdttm.GetValueOrDefault(DateTime.Today);
                if (!(userDayOfWeek.DayOfWeek == (DayOfWeek)disponibility.WeekdayNbr))
                {
                    var weekDay = (int)userDayOfWeek.DayOfWeek;
                    weekDay -= disponibility.WeekdayNbr;
                    userDayOfWeek.AddDays(Math.Abs(weekDay));
                }
                ListDayTimeSpans.Add(new InputDayModel()
                {
                    RecurrenceRule = disponibility.RecurrenceRule,
                    UserAvlSqnbr = disponibility.UserAvlSqnbr,
                    DayOfWeekInstanceDay = disponibility.WeekdayNbr,
                    StartTime = userDayOfWeek.Add(disponibility.AvlStm),
                    EndTime = userDayOfWeek.Add(disponibility.AvlNtm),
                });
            }
        }
    }
}
