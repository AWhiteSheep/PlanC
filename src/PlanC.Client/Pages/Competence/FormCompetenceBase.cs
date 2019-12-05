using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PlanC.Client.Data;
using PlanC.EntityDataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace PlanC.Client.Pages.Competence
{
    public class FormCompetenceBase : ComponentBase
    {
        [Inject]
        protected PCU001Context context { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        // paramètre de l'url
        [Parameter]
        public int departementId { get; set; }
        [Parameter]
        public string competenceId { get; set; }
        [Parameter]
        public int CurrentStep { get; set; } = 1;

        // si la compétence à déjà été créé certaine étape peuvent être sauté comme certaine vérification
        public bool isEditing = false;

        // programme pour lequel nous formaton la nouvelle compétence
        public PlanC.EntityDataModel.Departements departement;

        // form context
        public IReadOnlyDictionary<string, object> inputCompetenceAttributes = new Dictionary<string, object>();
        public EditContext CompetenceForm;
        public EditFormCompetence formCompetence;
        public EditFormContextRealisation formRealisation;
        public EditFormElement formElement;
        public EditContext EditConContext;

        // discipline disponible pour le context doit être initialisé pour le dropdown
        public List<EntityDataModel.Departements> departements;

        // les valeurs devant être initialisés pour créer un nouvelle compétence
        public Competences skill = new Competences();
        public List<CompetenceContextes> contextRealisationsCache;
        public List<ElementsCompetence> skElements;

        public string StatusMessage;
        public string infoMessage;

        // lorsque le component initiaalise
        protected override void OnInitialized()
        {
            departements = context.Departements.ToList();
            // vérifi si le département dans le GET:/{departementId} existe bel et bien
            departement = departements.First(e => e.Id == departementId);
            if (departement == null)
                NavigationManager.NavigateTo("/error");

            // si non null nous continuons la création d'une compétence ou nous la modification
            if (!string.IsNullOrEmpty(competenceId))
            {
                // La compétence n'est pas null donc on fait la recherche pour vérifier
                // si une combinaison du id de compétence et de département existe déjà
                var vcompetence = context.Competences
                    .Include(e => e.CompetenceContextes)
                    .Include(p => p.ElementsCompetence)
                    .First(d => d.CompetenceId == competenceId
                    && d.DisciplineId == departementId);
                if (vcompetence == null)
                {
                    // si la compétence n'existe pas nous affichons un message d'erreur
                    // sort une erreur si la compétence n'existe pas
                    NavigationManager.NavigateTo("/error");
                }
                isEditing = true;
                // lecture seul
                inputCompetenceAttributes.Append(new KeyValuePair<string, object>("readonly", "readonly"));
                skill = vcompetence;
                // continuation de la modification
                CompetenceForm = new EditContext(skill);
            }
            else
            {
                // la compétence n'existe pas alors nous lui associons un département
                skill.DisciplineId = departement.Id;
                skill.NombreParties = 1;
                CompetenceForm = new EditContext(skill);
                // faire du premier choix de la discpline à la discipline du département du programme.
                departements = context.Departements.ToList();
            }
        }
        public void SaveChanges()
        {
            try
            {
                Console.WriteLine($"SQL return code: {context.SaveChanges()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message} -- {e.InnerException}");
                StatusMessage = "Une erreur est survenue, si cela persiste veuillez contacter votre administrateur.";
                StateHasChanged();
            }
        }

    }
}
