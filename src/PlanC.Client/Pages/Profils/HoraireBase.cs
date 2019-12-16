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
        public EjsSchedule<DisponibilitesUtilisateur> schedule { get; set; }
        // jour de la semaine contenant les heures de disponibilités
        public List<DisponibilitesUtilisateur> ListDayTimeSpans { get; set; }
        // model pour la journée
        protected override void OnInitialized()
        {
            base.OnInitialized();
            RefreshDisponibilities();
            StateHasChanged();
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
            ListDayTimeSpans = new List<DisponibilitesUtilisateur>();
            // reset the list to initial state
            foreach (var disponibility in Utilisateur.DisponibilitesUtilisateur) 
            {
                // ajoute à la liste la nouvelle disponibilité en ajoutant les valeurs manquante pour faire l'affichage
                ListDayTimeSpans.Add(disponibility);
                ListDayTimeSpans.Last().RecurrenceRule = DisponibilitesUtilisateur.GetRecurenceRule(disponibility.WeekdayNbr);
            }
        }
    }
}
