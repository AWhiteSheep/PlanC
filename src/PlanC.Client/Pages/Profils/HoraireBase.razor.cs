using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PlanC.EntityDataModel;
using PlanC.Client.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PlanC.Client.Pages.Profils
{
    public class HoraireBase : ComponentBase
    {
        [CascadingParameter]
        public Utilisateurs Utilisateur { get; set; }
        [Inject]
        public PCU001Context context { get; set; }
        public List<DisponibilitesUtilisateur> disponibilites;
        // jour de la semaine contenant les heures de disponibilités
        public List<InputDayModel> ListDayTimeSpans = new List<InputDayModel>() 
        {
            new InputDayModel(DayOfWeek.Sunday),
            new InputDayModel(DayOfWeek.Monday),
            new InputDayModel(DayOfWeek.Thursday),
            new InputDayModel(DayOfWeek.Wednesday),
            new InputDayModel(DayOfWeek.Thursday),
            new InputDayModel(DayOfWeek.Friday),
            new InputDayModel(DayOfWeek.Saturday),
        };
        // model pour la journée
        public class InputDayModel
        {
            public List<InputTimeSpanModel> timeSpans = new List<InputTimeSpanModel>();
            // validation pour un téléphone
            public DayOfWeek DayOfWeekInstanceDay { get; set; }
            public InputDayModel(DayOfWeek day) { DayOfWeekInstanceDay = day; }

        }
        public class InputTimeSpanModel
        {            
            // validation pour un téléphone
            public TimeSpan StartSpan { get; set; }
            // validation pour un téléphone
            public TimeSpan SoptSpan { get; set; }
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            disponibilites = context.DisponibilitesUtilisateur.Where(e => e.Uid == Utilisateur.UserName).ToList();
            foreach (var dayOfweekModel in ListDayTimeSpans) {
                disponibilites.Where(w => w.WeekdayNbr == ((int)dayOfweekModel.DayOfWeekInstanceDay)).ToList()
                    .ForEach(d => dayOfweekModel.timeSpans.Add(new InputTimeSpanModel() { StartSpan = d.AvlStm, SoptSpan = d.AvlNtm }));
            }
        }
    }
}
